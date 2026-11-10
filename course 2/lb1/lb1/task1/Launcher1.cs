using lb1.task1.models;
using System;
using System.Collections.Generic;
using System.Text;
using lb1.task1.models;

namespace lb1.task1
{
    public static class Launcher1
    {
        public static void Run()
        {
            ProductCatalog catalog = new ProductCatalog();

            Product p1 = new Product("Телефон");
            p1.AddStore("Rozetka", 12000);
            p1.AddStore("Comfy", 11500);
            p1.AddStore("Foxtrot", 12500);

            Product p2 = new Product("Ноутбук");
            p2.AddStore("Rozetka", 25000);
            p2.AddStore("Comfy", 24000);
            p2.AddStore("Foxtrot", 26000);

            Product p3 = new Product("Навушники");
            p3.AddStore("Rozetka", 1500);
            p3.AddStore("Comfy", 1700);
            p3.AddStore("Foxtrot", 1400);

            catalog.AddProduct(p1);
            catalog.AddProduct(p2);
            catalog.AddProduct(p3);

            int choice;

            do
            {
                Console.WriteLine("\nКАТАЛОГ ТОВАРІВ");
                Console.WriteLine("1. Показати всі товари");
                Console.WriteLine("2. Додати товар");
                Console.WriteLine("3. Видалити товар");
                Console.WriteLine("4. Редагувати назву товару");
                Console.WriteLine("5. Знайти магазини за ціною");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Помилка введення.");
                    choice = -1;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        catalog.DisplayAll();
                        break;

                    case 2:
                        AddProduct(catalog);
                        break;

                    case 3:
                        Console.Write("Введіть індекс товару: ");

                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            catalog.RemoveProduct(index);
                        }
                        else
                        {
                            Console.WriteLine("Некоректний індекс.");
                        }
                        break;

                    case 4:
                        EditProduct(catalog);
                        break;

                    case 5:
                        FindStores(catalog);
                        break;

                    case 0:
                        Console.WriteLine("Завершення програми.");
                        break;

                    default:
                        Console.WriteLine("Невірний пункт меню.");
                        break;
                }

            } while (choice != 0);
        }

        private static void AddProduct(ProductCatalog catalog)
        {
            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Назва товару не може бути порожньою.");
                return;
            }

            Console.Write("Введіть кількість магазинів: ");

            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Некоректна кількість магазинів.");
                return;
            }

            Product product = new Product(name);

            for (int i = 0; i < count; i++)
            {
                Console.Write($"\nНазва магазину {i + 1}: ");
                string storeName = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(storeName))
                {
                    Console.WriteLine("Назва магазину не може бути порожньою.");
                    i--;
                    continue;
                }

                Console.Write("Ціна товару: ");

                if (!double.TryParse(Console.ReadLine(), out double price) ||
                    price < 0)
                {
                    Console.WriteLine("Некоректна ціна.");
                    i--;
                    continue;
                }

                product.AddStore(storeName, price);
            }

            catalog.AddProduct(product);
            Console.WriteLine("Товар успішно додано.");
        }

        private static void EditProduct(ProductCatalog catalog)
        {
            Console.Write("Введіть індекс товару: ");

            if (!int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine("Некоректний індекс.");
                return;
            }

            Console.Write("Введіть нову назву товару: ");
            string newName = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Назва товару не може бути порожньою.");
                return;
            }

            catalog.EditProduct(index, newName);
        }

        private static void FindStores(ProductCatalog catalog)
        {
            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Введіть максимальну ціну: ");

            if (!double.TryParse(Console.ReadLine(), out double maxPrice) || maxPrice < 0)
            {
                Console.WriteLine("Некоректна ціна.");
                return;
            }

            Console.WriteLine("\nМагазини, що відповідають умові:");

            catalog.FindStores(name, maxPrice);
        }
    }

}
    

