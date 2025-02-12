﻿using LINQRevision;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static LINQRevision.ListGenerators;
namespace LINQBigTask
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("LINQ - Restriction Operators ");
            //LINQ - Restriction Operators "Deferred execution"
            var OutOfStock = ProductList.Where(p => p.UnitsInStock == 0).ToList();
            foreach (var Product in OutOfStock) { Console.WriteLine(Product); }
            Console.WriteLine("-----------------------------------------------------");
            var InStock = ProductList.Where(p => (p.UnitPrice > 3.00M) && (p.UnitsInStock > 0)).Select(p => new { Name = p.ProductName, Price = p.UnitPrice });
            foreach (var Product in InStock) { Console.WriteLine(Product); }
            Console.WriteLine("-----------------------------------------------------");

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = Arr.Select((p, i) => new { Current = p, LenghOfCurrent = i }).Where(p => p.Current.Length < p.LenghOfCurrent).Select(p => p.Current);
            Console.WriteLine(string.Join(" ,", result));
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("LINQ - Element Operators ");

            //LINQ - Element Operators "Immediate execution"
            var FirstOutOfStock = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine(FirstOutOfStock);
            Console.WriteLine("-----------------------------------------------------");

            var FirstProductPrice = ProductList.FirstOrDefault(i => i.UnitPrice > 1000);
            Console.WriteLine(FirstProductPrice);
            Console.WriteLine("-----------------------------------------------------");

            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result2 = Arr2.Where(p => p > 5).OrderBy(p => p).Skip(1).FirstOrDefault();
            Console.WriteLine(result2);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("LINQ - Set Operators");

            //LINQ - Set Operators
            var UniqueCategory = ProductList.DistinctBy(p => p.Category).Select(p => p.Category);
            Console.WriteLine(string.Join(" ,", UniqueCategory));
            Console.WriteLine("-----------------------------------------------------");
            var UniqueLetters = ProductList.Select(i => i.ProductName[0]).Concat(CustomerList.Select(p => p.CompanyName[0])).Distinct();
            Console.WriteLine(string.Join(" ,", UniqueLetters));
            //var UniqueLetters1 = ProductList.Zip(CustomerList, (i, p) =>  new { ProductFirstLetter= i.ProductName[0], CompanyFirstLetter =p.CompanyName[0]}).DistinctBy(p => new { p.ProductFirstLetter, p.CompanyFirstLetter });
            //foreach (var item in UniqueLetters1)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("-----------------------------------------------------");
            var CommonLetters = ProductList.Select(i => i.ProductName[0]).Intersect(CustomerList.Select(p => p.CompanyName[0])).Distinct();
            Console.WriteLine(string.Join(" ,", CommonLetters));
            Console.WriteLine("-----------------------------------------------------");
            var ExceptLetters = ProductList.Select(i => i.ProductName[0]).Except(CustomerList.Select(p => p.CompanyName[0])).Distinct();
            Console.WriteLine(string.Join(" ,", ExceptLetters));
            Console.WriteLine("-----------------------------------------------------");
            var LastThree = ProductList.Select(p => p.ProductName.Length > 3 ? p.ProductName[^3..] : p.ProductName).Concat(CustomerList.Select(p => p.CompanyName[^3..]));
            Console.WriteLine(string.Join(" ,", LastThree));

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("LINQ - Aggregate Operators");
            //LINQ - Aggregate Operators
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int result3 = Arr3.Count(p => p % 2 == 1);
            Console.WriteLine(result3);
            Console.WriteLine("-----------------------------------------------------");
            var CustLst = CustomerList.Select(p => new { Name = p.CompanyName, Orders = p.Orders?.Count() ?? 0 });
            foreach (var item in CustLst) { Console.WriteLine(item); }
            Console.WriteLine("-----------------------------------------------------");
            var categoryCounts = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Count = g.Count() }).ToList();
            foreach (var item in categoryCounts) { Console.WriteLine(item); }
            Console.WriteLine("-----------------------------------------------------");
            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result4 = Arr4.Select(p => p);
            var result5 = Arr4.Sum();
            Console.WriteLine(string.Join(" ,", result4));
            Console.WriteLine(result5);
            Console.WriteLine("-----------------------------------------------------");


            //StreamReader sr = new("dictionary_english.txt");
            //string content = sr.ReadToEnd();
            //{
            //    var totalChars = content
            //                      .Split([Environment.NewLine], StringSplitOptions.None)
            //                      .Sum(word => word.Length);
            //    Console.WriteLine($"Total characters: {totalChars}");
            //}
            string[] Total = File.ReadAllLines("dictionary_english.txt");
            int total = Total.Sum(c => c.Length);
            Console.WriteLine(total);
            Console.WriteLine("-----------------------------------------------------");
            var UnitsInStock = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, TotalInStock = g.Sum(p => p.UnitsInStock) });
            foreach (var item in UnitsInStock) { Console.WriteLine(item); }
            Console.WriteLine("-----------------------------------------------------");

            //var ShortestWord = content.Split([Environment.NewLine], StringSplitOptions.None).Select(word => word.Length).Min();
            //Console.WriteLine($"Shortest Word: {ShortestWord}");
            string[] shortest = File.ReadAllLines("dictionary_english.txt");
            int shortt = shortest.Min(c => c.Length);
            Console.WriteLine(shortt);
            Console.WriteLine("-----------------------------------------------------");
            var MinPrice = ProductList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, MinPrice = g.Min(p => p.UnitPrice) });
            foreach (var item in MinPrice)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------");
            var MinPriceLet = from p in ProductList
                              group p by p.Category into g
                              let minPrice = g.Min(p => p.UnitPrice)
                              select new { Category = g.Key, MinPrice = minPrice };
            foreach (var item in MinPriceLet) { Console.WriteLine(item); }
            Console.WriteLine("-----------------------------------------------------");
            string[] characters = File.ReadAllLines("dictionary_english.txt");
            int LongestWord = characters.Max(c => c.Length);
            Console.WriteLine(LongestWord);
            Console.WriteLine("-----------------------------------------------------");
            var MaxPrice = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, MaxPrice = g.Max(p => p.UnitPrice) });
            foreach (var item in MaxPrice)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------");

          var MaxPriceProduct = ProductList.GroupBy(p => p.Category).Select(g => new { g.Key, MaxPrice = g.Max(p => p.UnitPrice), Products = g.Where(p => p.UnitPrice == g.Max(g => g.UnitPrice)) });
            foreach (var item in MaxPriceProduct)
            {
                Console.WriteLine(item.Key);
                foreach (var prd in item.Products)
                {
                    Console.WriteLine($"....{prd.ProductName} = {prd.UnitPrice:C}");
                }
            }
            Console.WriteLine("-----------------------------------------------------");
            string[] AvgLength = File.ReadAllLines("dictionary_english.txt");
            double Avg = AvgLength.Average(c => c.Length);
            Console.WriteLine($"Avg Lenght : {Avg}");
            Console.WriteLine("-----------------------------------------------------");
            var AvgForEachCategory = ProductList.GroupBy(p => p.Category).Select(g=> new {g.Key, AvgPrice = g.Average(p=>p.UnitPrice)});
            foreach (var item in AvgForEachCategory)
            {
                Console.WriteLine($"{item.Key} Avg Price : {item.AvgPrice:C}");

            }
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-----------------------------------------------------");
            //LINQ - Ordering Operators
            Console.WriteLine("LINQ - Ordering Operators");
            var PList = ProductList.Select(p => p.ProductName).OrderDescending();
            Console.WriteLine(string.Join(" \n",PList));
            Console.WriteLine("-----------------------------------------------------");
            string[] Arr6 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords = Arr6.OrderBy(p => p, new CaseInSenstive());
            foreach (var item in Arr6)
            { Console.WriteLine(item); }
            Console.WriteLine("-----------------------------------------------------");
            var UISHTL = ProductList.Where(p => p.UnitsInStock > 0).Select(p => p.ProductName).OrderDescending();
            foreach (var item in UISHTL) { Console.WriteLine(item); }
            Console.WriteLine("-----------------------------------------------------");
            string[] Arr7 = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight","nine"];
            var ArrOrdering = Arr7.OrderDescending().OrderBy(p => p.Length).ThenBy(p => p);
            foreach (var item in ArrOrdering)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------");
            string[] Arr8 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var ArrOrdering2 = Arr8.OrderBy(p=>p.Length).ThenBy(p=>p,new CaseInSenstive());
            foreach (var item in ArrOrdering2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
