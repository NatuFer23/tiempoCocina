//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static List<Product> productCatalog = new List<Product>();

        private static List<Equipment> equipmentCatalog = new List<Equipment>();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con lusing System;\nusing System.Threading;\n\nnamespace Full_GRASP_And_SOLID\n{\n    class Program\n    {\n        static void Main(string[] args)\n        {\n            // Crea una receta\n            Recipe recipe = new Recipe();\n            Product productoFinal = new Product() { Description = \"Tarta\" };\n            recipe.FinalProduct = productoFinal;\n\n            // Agrega pasos a la receta\n            Product harina = new Product() { Description = \"Harina\" };\n            Equipment horno = new Equipment() { Description = \"Horno\" };\n            recipe.AddStep(harina, 200, horno, 3000); // 3 segundos\n            recipe.AddStep(\"Dejar reposar\", 2000);    // 2 segundos\n\n            // Verifica el estado inicial\n            Console.WriteLine($\"Cooked: {recipe.Cooked}\"); // Debe ser false\n\n            // Inicia la cocción\n            recipe.Cook();\n\n            // Simula un pequeño tiempo de espera\n            Thread.Sleep(1000); // 1 segundo\n            Console.WriteLine($\"Cooked después de 1s: {recipe.Cooked}\"); // Debe seguir siendo false\n\n            // Espera el tiempo total de cocción\n            Thread.Sleep(recipe.GetCookTime()); // Tiempo total (3s + 2s = 5s)\n            Console.WriteLine($\"Cooked después de completar la cocción: {recipe.Cooked}\"); // Debe ser true\n        }\n    }\n}\neche");
            recipe.AddStep(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120);
            recipe.AddStep(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60);
            recipe.AddStep("Dejar enfriar", 60);

            IPrinter printer;
            printer = new ConsolePrinter();
            printer.PrintRecipe(recipe);
            printer = new FilePrinter();
            printer.PrintRecipe(recipe);
            
            Console.WriteLine($"Cooked: {recipe.Cooked}");
            recipe.Cook();
            Thread.Sleep(500); // 0.5 segundos
            Console.WriteLine($"Cooked: {recipe.Cooked}");
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
        
       
    }
}
