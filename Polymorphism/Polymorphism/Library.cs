using Polymorphism.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    internal class Library
    {
        // Umumi mehsullarim
        public Product[] products=new Product[0];

        // Mehsul elave eden metodum
        public Product[] AddProduct(Product product)
        {
           products =products.Add(product); // Add extentions
            return products;
        }

        // Jurnallarin sayini qaytran metodum
        public int GetJournalsCount()
        {
            if (products.Length == 0)
            {
                throw new EmptyLibraryException("Kitabxanada mehsul yoxdur");
            }
            int count = 0;
            foreach (var item in products)
            {
                if (item is Journal)
                {
                    count++;
                }
            }
            return count;
        }

        // Kitablarin sayini qaytran metodum
        public int GetBooksCount()
        {
            if (products.Length==0)
            {
                throw new EmptyLibraryException("Kitabxanada mehsul yoxdur");
            }
            int count = 0;
            foreach (var item in products)
            {
                if (item is Book)
                {
                    count++;
                }
            }
            return count;
        }

        // Serte esasen kitab veya jurnal siyahisi qaytaran metodum
        public Product[] GetProducts(bool isBook)
        {
            Product[] newProducts = new Product[0];
            if (isBook)
            {
               
                return IsBook(newProducts); ;
            }
            else
            {
               return IsJournal(newProducts);
            }
            

        }
        // Kitabdirmi oldugun yoxlayan metod
        public Product[] IsBook(Product[] arr)
        {
            foreach (var item in products)
            {
                if (item is Book)
                {
                    arr=arr.Add(item);

                }
            }
            if (arr.Length==0)
            {
                throw new BookNotFoundException("Mehsullar arasinda kitab yoxdur");
            }
            return arr;
        }


        // Jurnaldirmi oldugunu yoxlayan metod
        public Product[] IsJournal(Product[] arr)
        {
            foreach (var item in products)
            {
                if (item is Journal)
                {
                    arr =arr.Add(item);

                }
            }
            if (arr.Length == 0)
            {
                throw new BookNotFoundException("Mehsullar arasinda jurnal yoxdur");
            }
            return arr;
        }
    }
}
