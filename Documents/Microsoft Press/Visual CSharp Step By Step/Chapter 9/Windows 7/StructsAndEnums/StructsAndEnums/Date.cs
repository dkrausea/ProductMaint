using System;

namespace StructsAndEnums
{
   struct Date  // Declares my own structure of type Date. The body of the structure is enclosed in {}
   {
      
      // private instance fields for this structure.  
      //In a structure they cannot be initialized.
      private int year;
      private Month month;
      private int day;


      public void AdvanceMonth()
      {
         this.month++;
         if (this.month == Month.December + 1)
         {
            this.month = Month.January;
            this.year++;
         }
      }

      // Constructor for the Date structure
      // All intsance fields must be initialized here
      public Date( int ccyy, Month mm, int dd )
      {
         this.year = ccyy -1900;
         this.month = mm;
         this.day = dd - 1;
      }
          // Overriding the ToString method to add 1 to the day, 1900 to the year, and format the whole date.
          //Formatted date example:  May 28, 2010
          public override string ToString()
          {
             string data = String.Format("{0} {1}, {2}", this.month, this.day +1, this.year + 1900);
             return data;
          }
      }
   }