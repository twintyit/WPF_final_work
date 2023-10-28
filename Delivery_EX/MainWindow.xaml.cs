using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Delivery_EX
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RecordManager rm;
        Window1 Win2;
        Window2 Win3;
        Window3 Win4;

        public MainWindow()
        {
            InitializeComponent();
            rm = new RecordManager();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            List<Record> l = rm.GetRecords();
            listBox.ItemsSource = l;
        }

        private void createRecordBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int weight = int.Parse(weightTextBox.Text);
                int width = int.Parse(widthTextBox.Text);
                int height = int.Parse(heightTextBox.Text);
                int length = int.Parse(lengthTextBox.Text);

                Package p = new Package { Weight = weight, Width = width, Height = height, Length = length };

                Record r = new Record
                {
                    Id = rm.currentId,
                    Name = nameTextBox.Text,
                    Lastame = lastnameTextBox.Text,
                    Surname = surnameTextBox.Text,
                    Status = "В обработке",
                    From = fromTextBox.Text,
                    To = toTextBox.Text,
                    MobNum = mobNumTextBox.Text,
                    Package = p
                };

                DeliveryCalculation dc = new DeliveryCalculation(length, width, height, weight, r.From, r.To);

                string price = dc.CalculateDelivery().ToString();
                string date = dc.CalculateDateDelivery().ToString();

                r.DeliveryDate = date;

                Win2 = new Window1();
                Win2.SetTextBox(price, date);

                Win2.ShowDialog();
                ClearTextBox();
                rm.AddRecord(r);
                MessageBox.Show("Готово", "Оформление посылки");
                
            }
            catch (FormatException fe)
            {
                MessageBox.Show($"Некоректные данные", "Ошибка");
            }
            catch (ArgumentNullException ne)
            {
                MessageBox.Show($"Некоректные данные", "Ошибка");
            }
            catch (OverflowException oe)
            {
                MessageBox.Show($"Слишком большое число", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка", "Ошибка");
            }
        }

        private void ClearTextBox()
        {
            lastnameTextBox.Text = null;
            nameTextBox.Text = null;
            surnameTextBox.Text = null;
            mobNumTextBox.Text = null;
            fromTextBox.Text = null;
            toTextBox.Text = null;
            heightTextBox.Text = null;
            lengthTextBox.Text = null;
            widthTextBox.Text = null;
            weightTextBox.Text = null;
        }
        private void giveAwayButton_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(giveTextBox.Text, out long id) && id.ToString().Length == 11 )
            {
                try
                {
                    Record r = rm.GetDataItemById(id);
                   
                    Win4 = new Window3();
                    Win4.SetTextBox(r.Status, r.Name, r.MobNum, r.Lastame, r.Surname);
                    Win4.ShowDialog();

                    if (r.Status == "Доставлено")
                    {
                        if (rm.RemoveDataItemById(id))
                        {
                            MessageBox.Show("Готово", "Отдать посылку");
                            giveTextBox.Text = null;
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Ничего не найдено", "Отслеживание");
                }
            }
            else
            {
                MessageBox.Show("Ничего не найдено", "Отслеживание");
            }
        }

        private void calculationBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int length = int.Parse(lengthСalculationTextBox.Text);
                int width = int.Parse(widthСalculationTextBox.Text);
                int height = int.Parse(heightСalculationTextBox.Text);
                int weight = int.Parse(weightСalculationTextBox.Text);

                string city1 = fromСalculationTextBox.Text;
                string city2 = toСalculationTextBox.Text;

                DeliveryCalculation dc = new DeliveryCalculation(length, width, height, weight, city1, city2);

                string price = dc.CalculateDelivery().ToString();
                string date = dc.CalculateDateDelivery().ToString();

                Win2 = new Window1();
                Win2.SetTextBox(price, date);

                Win2.ShowDialog();
            }
            catch (FormatException fe)
            {
                MessageBox.Show($"Некоректные данные", "Ошибка");
            }
            catch (ArgumentNullException ne)
            {
                MessageBox.Show($"Некоректные данные", "Ошибка");
            }
            catch (OverflowException oe)
            {
                MessageBox.Show($"Слишком большое число", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка", "Ошибка");
            }
            lengthСalculationTextBox.Text = null;
            widthСalculationTextBox.Text = null;
            heightСalculationTextBox.Text = null;
            weightСalculationTextBox.Text = null;
            fromСalculationTextBox.Text = null;
            toСalculationTextBox.Text = null;
        }
        private void numericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void letterTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1) )
            {
                e.Handled = true;
            }
        }

        private void numericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string numericText = new string(textBox.Text.Where(char.IsDigit).ToArray());

                if (numericText.Length > 11)
                {
                    numericText = numericText.Substring(0, 11);
                }

                textBox.Text = numericText;
                textBox.CaretIndex = numericText.Length;
            }
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                rm.WhriteCurrentId();
            }
        }

        private void mobNumTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Focus();
            textBox.CaretIndex = 3;
            e.Handled = true;
        }

        private void searchButton_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (long.TryParse(searchTextBox.Text, out long id))
            {
                try
                {
                    Record r = rm.GetDataItemById(id);
                    Win3 = new Window2();
                    Win3.SetTextBox(r.Status, r.DeliveryDate);
                    Win3.ShowDialog();
                    searchTextBox.Text = null;
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Ничего не найдено", "Отслеживание");
                }
            }
        }
    }
}
