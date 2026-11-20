using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace lb6.Task1
{
    public partial class Calculator : UserControl
    {
        private decimal firstNumber = 0;
        private string operation = "";
        private bool newNumber = true;
        public Calculator()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string value = ((Button)sender).Tag.ToString();
            if (value.Length == 1 && char.IsDigit(value[0]))
            {
                AddDigit(value);
            }
            else
            {
                switch (value)
                {
                    case ".":
                        AddPoint();
                        break;

                    case "+" or "-" or "*" or "/":
                        SetOperation(value);
                        break;

                    case "=":
                        Calculate();
                        break;

                    case "CE":
                        DisplayBox.Text = "0";
                        newNumber = true;
                        break;

                    case "C":
                        ClearAll();
                        break;

                    case "BACK":
                        DeleteLastSymbol();
                        break;
                }
            }
        }
        private void AddDigit(string digit)
        {
            if (newNumber)
            {
                DisplayBox.Text = digit;
                newNumber = false;
            }
            else if (DisplayBox.Text == "0")
            {
                DisplayBox.Text = digit;
            }
            else
            {
                DisplayBox.Text += digit;
            }
        }
        private void AddPoint()
        {
            if (newNumber)
            {
                DisplayBox.Text = "0.";
                newNumber = false;
            }
            else if (!DisplayBox.Text.Contains("."))
            {
                DisplayBox.Text += ".";
            }
        }
        private void SetOperation(string selectedOperation)
        {
            if (operation != "" && !newNumber)
            {
                Calculate();
            }

            firstNumber = GetCurrentNumber();
            operation = selectedOperation;
            HistoryBox.Text = FormatNumber(firstNumber) + " " + operation;
            newNumber = true;
        }
        private void Calculate()
        {
            if (operation == "" || newNumber)
            {
                return;
            }

            decimal secondNumber = GetCurrentNumber();
            decimal result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("На нуль ділити не можна!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }
            HistoryBox.Text = FormatNumber(firstNumber) + " " + operation + " " + FormatNumber(secondNumber) + " =";
            DisplayBox.Text = FormatNumber(result);
            firstNumber = result;
            operation = "";
            newNumber = true;
        }
        private decimal GetCurrentNumber()
        {
            decimal.TryParse(DisplayBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number);
            return number;
        }
        private string FormatNumber(decimal number)
        {
            return number.ToString("G", CultureInfo.InvariantCulture);
        }
        private void ClearAll()
        {
            DisplayBox.Text = "0";
            HistoryBox.Text = "";
            firstNumber = 0;
            operation = "";
            newNumber = true;
        }
        private void DeleteLastSymbol()
        {
            if (newNumber)
            {
                return;
            }

            if (DisplayBox.Text.Length > 1)
            {
                DisplayBox.Text = DisplayBox.Text.Substring(0, DisplayBox.Text.Length - 1);
                if (DisplayBox.Text == "-")
                {
                    DisplayBox.Text = "0";
                    newNumber = true;
                }
            }
            else
            {
                DisplayBox.Text = "0";
                newNumber = true;
            }
        }
    }
}
