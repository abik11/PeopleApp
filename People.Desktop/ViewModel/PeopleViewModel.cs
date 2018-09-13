using People.Desktop.Base;
using People.Desktop.Infrastructure;
using People.Desktop.Model;
using People.Desktop.PeopleService;
using People.Logic;
using People.Utility.Service;
using People.Utility.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System;
using People.Resources.Strings;

namespace People.Desktop.ViewModel
{
   public class PeopleViewModel : NotifyPropertyChanged
   {

      #region Fields
      private PeopleLogic peopleLogic;
      private List<PersonDto> people;
      private string path;
      private bool isModified;
      private IMessageBoxService messageBox;
      #endregion

      #region Properties

      public bool IsModified
      {
         get { return this.isModified; }
         set
         {
            this.isModified = value;
            OnPropertyChanged(nameof(IsModified));
         }
      }

      public ObservableCollection<Person> People { get; set; }

      #endregion

      #region Constructors

      public PeopleViewModel(IMessageBoxService messageBox)
      {
         IsModified = false;
         People = new ObservableCollection<Person>();
         this.peopleLogic = new PeopleLogic();
         this.path = CurrentUserHelper.GetCurrentUserDirectory() + "\\people.xml";
         this.messageBox = messageBox;
      }

      #endregion

      #region Methods

      public void LoadPeople()
      {
         People.Clear();

         ServiceManager<PeopleServiceClient> svcManager 
            = new ServiceManager<PeopleServiceClient>(ShowServiceErrorMessage);

         this.people = svcManager.Client.GetPeople();
         svcManager.Client.Close();
     
         foreach (PersonDto p in this.people)
            People.Add(AutoMapper.Mapper.Map<Person>(p));
      }

      private void OnSave()
      {
         ServiceManager<PeopleServiceClient> svcManager 
            = new ServiceManager<PeopleServiceClient>(ShowServiceErrorMessage);

         foreach (Person person in People)
         {
            PersonDto p = AutoMapper.Mapper.Map<PersonDto>(person);
            if (person.Id == 0)
               svcManager.Client.AddPerson(p);
            else
               svcManager.Client.EditPerson(p, person.Id);
         }

         for (int i = 0; i < people.Count; i++)
         {
            if (!People.Any(x => x.Id == people[i].Id))
            {
               svcManager.Client.DeletePerson(people[i].Id);
               this.people.RemoveAt(i);
            }
         }

         string xml = svcManager.Client.GetPeopleXML();
         File.WriteAllText(this.path, xml);

         svcManager.Client.Close();
      }

      private void OnCancel()
      {
         LoadPeople();
         IsModified = false;
      }

      private void OnEdit()
      {
         IsModified = true;
      }

      private void ShowServiceErrorMessage(Exception e)
      {
         this.messageBox.Show(Strings.ServiceConnectionProblem, Strings.Error);
      }

      #endregion

      #region Commands

      public Command SaveCommand { get { return new Command(OnSave); } }

      public Command CancelCommand { get { return new Command(OnCancel); } }

      public Command EditCommand { get { return new Command(OnEdit); } }

      #endregion

   }
}