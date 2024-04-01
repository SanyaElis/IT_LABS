using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using laba_1.models;

namespace laba_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Set<int> MySet;
        public MainWindow()
        {
            InitializeComponent();
            MySet = new Set<int>();
        }
        private void UpdateDisplay()
        {
            SetData.Items.Clear();
            
            foreach (int value in MySet.GetValues())
            {
                SetData.Items.Add(value);
            }

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MySet.Clear();
            UpdateDisplay();
        }

        private void AddButtton_Click(object sender, RoutedEventArgs e)
        {
            int newItem;
            if (int.TryParse(ValueToAdd.Text, out newItem))
            {
                MySet.Add(newItem);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Введите корректное число типа integer");
            }
            UpdateDisplay();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int removeItem;
            if (int.TryParse(ValueToRemove.Text, out removeItem))
            {
                MySet.Remove(removeItem);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Введите корректное число типа integer");
            }
            UpdateDisplay();
        }

        private void ContainsButton_Click(object sender, RoutedEventArgs e)
        {
            int checkItem;
            if (int.TryParse(ValueToCheck.Text, out checkItem))
            {
                ContainsResult.Content = MySet.Contains(checkItem);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Введите корректное число типа integer");
            }
            UpdateDisplay();
        }
    }
}
