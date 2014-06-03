using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Collections101.WebForms
{
   public class Product
   {
      public int ProductId { get; set; }
      public string ProductName { get; set; }
      public string ProductType { get; set; }
      public decimal Price { get; set; }
      public string Image { get; set; }
      public bool IsOnSpecial { get; set; }
   }

   public class ProductCollection : List<Product>
   {
      #region Constructor

      public ProductCollection()
      {
         this.BuildCollection();
      }

      #endregion

      public ObservableCollection<Product> DataCollection { get; set; }

      public ObservableCollection<Product> BuildCollection()
      {
         DataCollection = new ObservableCollection<Product>();

         string fileName;

         fileName = GetCurrentDirectory() +
           @"App_Data\Product.xml";

         if (File.Exists(fileName))
            this.DataCollection = ProductCollection.GetProducts(fileName);

         return this.DataCollection;
      }

      public static ObservableCollection<Product> GetProducts(string fileName)
      {
         XElement elem = XElement.Load(fileName);

         var items = 
            from prod in elem.Descendants("Product")
               select new Product
               {
                  ProductId = Convert.ToInt32(prod.Element("ProductId").Value),
                  ProductName = prod.Element("ProductName").Value,
                  ProductType = prod.Element("ProductType").Value,
                  Price = Convert.ToDecimal(prod.Element("Price").Value),
                  Image = prod.Element("Image").Value,
                  IsOnSpecial = Convert.ToBoolean(prod.Element("IsOnSpecial").Value)
               };

         return new ObservableCollection<Product>(items);
      }

      public static string GetCurrentDirectory()
      {
         string result =
            HttpContext.Current.Server.MapPath("~");

         return result;
      }
   }
}
