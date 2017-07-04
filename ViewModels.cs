using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype2
{
    public class MainViewModel
    {
        public MainViewModel()
        {

        }
        RepresentativeViewModel RepresentativeVM = new RepresentativeViewModel();
        RepContactsViewModel RepContactsVM = new RepContactsViewModel();

        ContactViewModel ContactVM = new ContactViewModel();

        public ObservableCollection<Representative> Representatives {
            get { return RepresentativeVM.Representatives; }
            set { RepresentativeVM.Representatives = value; }
        }
        public ObservableCollection<RepContacts> RepContact
        {
            get { return RepContactsVM.RepContact; }
            set { RepContactsVM.RepContact = value; }
        }

        public ObservableCollection<Contacts> Contact
        {
            get { return ContactVM.Contact; }
            set { ContactVM.Contact = value; }
        }
    }

    public class RepresentativeViewModel : ViewModelEntity
    {
        public RepresentativeViewModel()
        {

        }
        protected ObservableCollection<Representative> representatives =
            new ObservableCollection<Representative>();

        protected Representative selectedRepresentative = null;

        public ObservableCollection<Representative> Representatives
        {
            get { return representatives; }
            set { representatives = value; }
        }

        public Representative SelectedRepresentative
        {
            get { return selectedRepresentative; }
            set
            {
                if (selectedRepresentative != value)
                {
                    selectedRepresentative = value;
                    NotifyPropertyChanged("SelectedRepresentative");
                }
            }
        }
    }

    public class RepContactsViewModel : ViewModelEntity
    {
        public RepContactsViewModel()
        {

        }
        protected ObservableCollection<RepContacts> repcontact =
            new ObservableCollection<RepContacts>();

        protected RepContacts selectedRepContact = null;

        public ObservableCollection<RepContacts> RepContact
        {
            get { return repcontact; }
            set { repcontact = value; }
        }

        public RepContacts SelectedRepContact
        {
            get { return selectedRepContact; }
            set
            {
                if (selectedRepContact != value)
                {
                    selectedRepContact = value;
                    NotifyPropertyChanged("SelectedRepContact");
                }
            }
        }
    }

    public class ContactViewModel : ViewModelEntity
    {
        public ContactViewModel()
        {

        }
        protected ObservableCollection<Contacts> contact =
            new ObservableCollection<Contacts>();

        protected RepContacts selectedContact = null;

        public ObservableCollection<Contacts> Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public RepContacts SelectedContact
        {
            get { return selectedContact; }
            set
            {
                if (selectedContact != value)
                {
                    selectedContact = value;
                    NotifyPropertyChanged("SelectedContact");
                }
            }
        }
    }
}
