using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public DateTime DateOfManufacture { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string CountryOfManufacture { get; set; }

    public Product(string name, string brand, DateTime dateOfManufacture, decimal price, bool isAvailable, string countryOfManufacture)
    {
        Name = name;
        Brand = brand;
        DateOfManufacture = dateOfManufacture;
        Price = price;
        IsAvailable = isAvailable;
        CountryOfManufacture = countryOfManufacture;
    }

    public int GetAgeInYears()
    {
        return DateTime.Now.Year - DateOfManufacture.Year;
    }

    public decimal ConvertToKrona(decimal price)
    {
        // 1 Krona = 0.12 USD (Just for demonstration, not actual conversion rate)
        return price * 0.12m;
    }
}

class Program
{
    static List<Product> products = new List<Product>();

    static void Main()
    {
        Console.WriteLine("Asset Tracking App");
        Console.WriteLine("Enter product details or type 'D' to display data:");

        while (true)
        {
            Console.Write("Enter product name (or 'D' to display data): ");
            string input = Console.ReadLine().Trim();

            if (input.Equals("D", StringComparison.OrdinalIgnoreCase))
            {
                DisplayProductData();
                break;
            }

            Console.Write("Enter product brand: ");
            string brand = Console.ReadLine().Trim();

            Console.Write("Enter date of manufacture (yyyy-mm-dd): ");
            DateTime dateOfManufacture = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter price (USD): ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Is it available? (true/false): ");
            bool isAvailable = bool.Parse(Console.ReadLine());

            Console.Write("Enter country of manufacture: ");
            string countryOfManufacture = Console.ReadLine().Trim();

            products.Add(new Product(input, brand, dateOfManufacture, price, isAvailable, countryOfManufacture));
            Console.WriteLine("Product added successfully!");
        }
    }

    static void DisplayProductData()
    {
        Console.WriteLine("\nProduct Data:");
        Console.WriteLine("Name\tBrand\tManufactured In\tAvailable\tPrice (Krona)\tAge");

        foreach (var product in products)
        {
            decimal priceInKrona = product.ConvertToKrona(product.Price);
            int ageInYears = product.GetAgeInYears();

            Console.ForegroundColor = ConsoleColor.White;
            if (ageInYears > 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (ageInYears > 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine($"{product.Name}\t{product.Brand}\t{product.CountryOfManufacture}\t{product.IsAvailable}\t{priceInKrona}\t{ageInYears} years");
            Console.ResetColor();
        }
    }
}