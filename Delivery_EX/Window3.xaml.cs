using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Delivery_EX
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        public void SetTextBox(string statys, string name, string mobNum, string lastName, string surname)
        {
            lastnameTextBox.Text = lastName;
            nameTextBox.Text = name;
            surnameTextBox.Text = surname;
            mobNumTextBox.Text = mobNum;
            statysTextBox.Text = statys;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
