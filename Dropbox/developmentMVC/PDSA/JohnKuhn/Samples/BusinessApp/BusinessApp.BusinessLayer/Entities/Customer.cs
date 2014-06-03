using System.ComponentModel.DataAnnotations;

namespace BusinessApp.BusinessLayer
{
   public class Customer
   {
      /// <summary>
      /// Customer name property with data annotations
      /// </summary>
      [Display(Name = "Customer Name")]
      [Required(ErrorMessage = "Customer name is required.")]
      public string CustomerName { get; set; }

      /// <summary>
      /// Credit limit property with data annotations
      /// </summary>
      [Display(Name = "Credit Limit")]
      [Required(ErrorMessage = "Credit limit is required.")]
      [DataType(DataType.Currency, ErrorMessage = "Credit limit must be currency.")]
      public double CreditLimit { get; set; }

      public int CustomerId { get; set; }

      public string CompanyName { get; set; }

      public string WebsiteURL { get; set; }

      public short ConcurrencyValue { get; set; }

      public System.DateTime InsertDate { get; set; }

      public string InsertName { get; set; }

      public System.DateTime UpdateDate { get; set; }

      public string UpdateName { get; set; }
   }
}
