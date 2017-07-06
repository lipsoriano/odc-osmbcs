using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype2
{
    public class MainViewModel : ViewModelEntity
    {
        public MainViewModel()
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
            set { SetProperty(ref selectedRepresentative, value); }
        }

        protected ObservableCollection<Contact> custcontact = new ObservableCollection<Contact>();

        protected Contact selectedContact = null;

        public ObservableCollection<Contact> CustContacts
        {
            get { return custcontact; }
            set { custcontact = value; }
        }

        public Contact SelectedCustContact
        {
            get { return selectedContact; }
            set { SetProperty(ref selectedContact, value); }
        }

        protected List<ObservableCollection<Contact>> contactOfRep = new List<ObservableCollection<Contact>>();

        public List<ObservableCollection<Contact>> ContactOfRep
        {
            get { return contactOfRep; }
            set { contactOfRep = value; }
        }

        protected ObservableCollection<Contact> repcontact =
            new ObservableCollection<Contact>();

        protected Contact selectedRepContact = null;

        public ObservableCollection<Contact> RepContacts
        {
            get { return repcontact; }
            set { repcontact = value; }
        }

        public Contact SelectedRepContact
        {
            get { return selectedRepContact; }
            set { SetProperty(ref selectedRepContact, value); }
        }
    }
}
