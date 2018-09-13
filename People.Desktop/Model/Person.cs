using People.Desktop.Base;
using System;

namespace People.Desktop.Model
{
   public class Person : NotifyPropertyChanged
   {
      public Person()
      {
         this.address = new Address();
      }

      private int id;
      public int Id {
         get { return this.id; }
         set
         {
            this.id = value;
            OnPropertyChanged(nameof(Id));
         }
      }

      private string firstName;
      public string FirstName {
         get { return this.firstName;  }
         set
         {
            this.firstName = value;
            OnPropertyChanged(nameof(FirstName));
         }
      }

      private string lastName;
      public string LastName {
         get { return this.lastName;  }
         set
         {
            this.lastName = value;
            OnPropertyChanged(nameof(LastName));
         }
      }

      private string phoneNumber;
      public string PhoneNumber {
         get { return this.phoneNumber; }
         set
         {
            this.phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
         }
      }

      private DateTime birthday;
      public DateTime Birthday {
         get { return this.birthday; }
         set
         {
            this.birthday = value;
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Birthday));
         }
      }

      public int Age {
         get { return DateTime.Now.Year - this.birthday.Year; }
      }

      private Address address;
      public Address Address {
         get { return this.address; }
         set
         {
            this.address = value;
            OnPropertyChanged(nameof(Address));
         }
      }
   }
}