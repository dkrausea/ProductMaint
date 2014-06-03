#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace StructsAndEnums
{
   class Program
   {
      static void doWork()
      {
         //Month First = Month.December;
         //Console.WriteLine(First);
         //First++;
         //Console.WriteLine(First);

         //   Date defaultDate = new Date();
         //   Console.WriteLine(defaultDate);

         Date weddingAnniversary = new Date(2010, Month.May, 28);
         Console.WriteLine("Our Wedding Anniversary:  {0}", weddingAnniversary);

         //   Date birthdayBia = new Date(1978, Month.January, 3);
         //   Console.WriteLine("Bia's birthdate:  {0}", birthdayBia);


         Date weddingAnniversaryCopy = weddingAnniversary;
         Console.WriteLine("Value of copy is {0}", weddingAnniversaryCopy);

         weddingAnniversary.AdvanceMonth();
         Console.WriteLine("New value of weddingAnniversary is {0}", weddingAnniversary);
         Console.WriteLine("Value of copy is still {0}", weddingAnniversaryCopy);  
      }

      static void Main()
      {
         try
         {
            doWork();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }
      }
   }
}
