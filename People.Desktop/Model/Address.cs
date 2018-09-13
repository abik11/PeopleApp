using People.Desktop.Base;

namespace People.Desktop.Model
{
   public class Address : NotifyPropertyChanged
   {
      private string street;
      public string Street
      {
         get { return this.street; }
         set
         {
            this.street = value;
            OnPropertyChanged(nameof(Street));
         }
      }

      private string houseNumber;
      public string HouseNumber {
         get { return this.houseNumber;  }
         set
         {
            this.houseNumber = value;
            OnPropertyChanged(nameof(HouseNumber));
         }
      }

      private string appartmentNuber;
      public string AppartmentNumber {
         get { return this.appartmentNuber; }
         set
         {
            this.appartmentNuber = value;
            OnPropertyChanged(nameof(AppartmentNumber));
         }
      }

      private string postalCode;
      public string PostalCode {
         get { return this.postalCode; }
         set
         {
            this.postalCode = value;
            OnPropertyChanged(nameof(PostalCode));
         }
      }
   }
}