using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace lb6.Task2
{
    public partial class BestOil : UserControl
    {
        public static decimal DailyRevenue { get; private set; } = 0;
        private decimal fuelPrice = 60.50m;
        public BestOil()
        {
            InitializeComponent();
            UpdateFuelPrice();
            UpdateMode();
            UpdateRevenue();
        }
        private void FuelCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelCombo.SelectedIndex < 0 || FuelPriceText == null)
            {
                return;
            }
            UpdateFuelPrice();
        }
        private void UpdateFuelPrice()
        {
            switch (FuelCombo.SelectedIndex)
            {
                case 0:
                    fuelPrice = 60.50m;
                    break;

                case 1:
                    fuelPrice = 57.80m;
                    break;

                case 2:
                    fuelPrice = 58.90m;
                    break;
            }
            FuelPriceText.Text = fuelPrice.ToString("F2");
        }
        private void Mode_Checked(object sender, RoutedEventArgs e)
        {
            if (LitersBox == null || MoneyBox == null || FuelResultGroup == null)
            {
                return;
            }
            UpdateMode();
        }
        private void UpdateMode()
        {
            if (LitersMode.IsChecked == true)
            {
                LitersBox.IsEnabled = true;
                MoneyBox.IsEnabled = false;
                FuelResultGroup.Header = "До оплати";
                FuelUnit.Text = "грн";
            }
            else
            {
                LitersBox.IsEnabled = false;
                MoneyBox.IsEnabled = true;
                FuelResultGroup.Header = "До видачі";
                FuelUnit.Text = "л";
            }
            FuelResult.Text = "0.00";
        }
        private void Product_Checked(object sender, RoutedEventArgs e)
        {
            CoffeeCount.IsEnabled = CoffeeCheck.IsChecked == true;
            HotDogCount.IsEnabled = HotDogCheck.IsChecked == true;
            SandwichCount.IsEnabled = SandwichCheck.IsChecked == true;
            WaterCount.IsEnabled = WaterCheck.IsChecked == true;
        }
        private decimal GetNumber(string value)
        {
            value = value.Replace(',', '.');
            if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number))
            {
                return number;
            }
            return -1;
        }
        private decimal GetItemSum(CheckBox check, TextBox priceBox, TextBox countBox)
        {
            if (check.IsChecked != true)
            {
                return 0;
            }
            decimal count = GetNumber(countBox.Text);
            if (count <= 0 || count != decimal.Truncate(count))
            {
                return -1;
            }
            return GetNumber(priceBox.Text) * count;
        }
        private decimal GetCafePrice()
        {
            decimal coffee = GetItemSum(CoffeeCheck, CoffeePrice, CoffeeCount);
            decimal hotDog = GetItemSum(HotDogCheck, HotDogPrice, HotDogCount);
            decimal sandwich = GetItemSum(SandwichCheck, SandwichPrice, SandwichCount);
            decimal water = GetItemSum(WaterCheck, WaterPrice, WaterCount);

            if (coffee < 0 || hotDog < 0 || sandwich < 0 || water < 0)
            {
                return -1;
            }
            return coffee + hotDog + sandwich + water;
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            decimal input;
            if (LitersMode.IsChecked == true)
            {
                input = GetNumber(LitersBox.Text);
            }
            else
            {
                input = GetNumber(MoneyBox.Text);
            }
            if (input <= 0)
            {
                MessageBox.Show("Введіть правильну кількість або суму грошей!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            decimal cafeTotal = GetCafePrice();
            if (cafeTotal < 0)
            {
                MessageBox.Show("Перевірте кількість обраних товарів!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            decimal fuelTotal;
            if (LitersMode.IsChecked == true)
            {
                fuelTotal = input * fuelPrice;
                FuelResult.Text = fuelTotal.ToString("F2");
            }
            else
            {
                fuelTotal = input;
                decimal liters = input / fuelPrice;
                FuelResult.Text = liters.ToString("F2");
            }
            decimal total = fuelTotal + cafeTotal;
            CafeResult.Text = cafeTotal.ToString("F2");
            GrandTotal.Text = total.ToString("F2");
            DailyRevenue += total;
            UpdateRevenue();
            MessageBox.Show("Розрахунок успішно виконано!\n\n" + "Вартість пального: " + fuelTotal.ToString("F2") + " грн\n" +
                "Вартість товарів: " + cafeTotal.ToString("F2") + " грн\n" + "До сплати: " + total.ToString("F2") + " грн", "BestOil",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        private void UpdateRevenue()
        {
            RevenueText.Text = "Виручка за день: " + DailyRevenue.ToString("F2") + " грн";
        }
    }
}