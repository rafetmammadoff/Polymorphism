using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    internal static class Extentions
    {
        public static Product[] Add(this Product[] arr,Product product)
        {
            if (arr != null)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length - 1] = product;
                return arr;
            }                              
            else
                return null;
        }
    }
}
