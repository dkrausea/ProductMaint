using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Collections101.BusinessLayer;

namespace Collections101.BusinessLayer.Entities
{
   /// <summary>
   /// A simple business object class for demonstration purposes
   /// </summary>
   public class Product
   {
      public Product(int id, string color)
      {
         this.ProductId = id;
         this.ProductColor = color;
      }

      public int ProductId { get; set; }
      
      public string ProductColor { get; set; }

      public decimal Price { get; set; }
   }

   #region Supporting Classes
   
   public class ProductHelper
   {
      static ProductCollection _products;

      public static ProductCollection GetProductList()
      {
         string[] colors;

         if (_products == null)
         {
            _products = new ProductCollection();
            colors = Enum.GetNames(typeof(System.Drawing.KnownColor));
            for (int i = 0; i < colors.Length - 1; i++)
            {
               _products.Add(new Product(i, colors[i]));
            }
         }

         return _products;
      }
   }

   #endregion
}
