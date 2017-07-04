using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype2
{
    public class Representative:ViewModelEntity
    {
        public Representative()
        {

        }
        protected string firstname;
        protected string middlename;
        protected string lastname;

        public string FirstName
        {
            get { return firstname; }
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        public string MiddleName
        {
            get { return middlename; }
            set
            {
                if (middlename != value)
                {
                    middlename = value;
                    NotifyPropertyChanged("MiddleName");
                }
            }
        }
        public string LastName
        {
            get { return lastname; }
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }
    }
    
    public class RepContacts : ViewModelEntity
    {
        public RepContacts()
        {

        }
        protected string typeid;
        protected string typename;
        protected string details;

        public string ContactTypeID
        {
            get { return typeid; }
            set
            {
                if (typeid != value)
                {
                    typeid = value;
                    NotifyPropertyChanged("ContactTypeID");
                }
            }
        }
        public string ContactType
        {
            get { return typename; }
            set
            {
                if (typename != value)
                {
                    typename = value;
                    NotifyPropertyChanged("ContactType");
                }
            }
        }
        public string ContactDetails
        {
            get { return details; }
            set
            {
                if (details != value)
                {
                    details = value;
                    NotifyPropertyChanged("ContactDetails");
                }
            }
        }
    }

    public class Contacts : ViewModelEntity
    {
        public Contacts()
        {

        }
        protected string typeid;
        protected string typename;
        protected string details;

        public string ContactTypeID
        {
            get { return typeid; }
            set
            {
                if (typeid != value)
                {
                    typeid = value;
                    NotifyPropertyChanged("ContactTypeID");
                }
            }
        }
        public string ContactType
        {
            get { return typename; }
            set
            {
                if (typename != value)
                {
                    typename = value;
                    NotifyPropertyChanged("ContactType");
                }
            }
        }
        public string ContactDetails
        {
            get { return details; }
            set
            {
                if (details != value)
                {
                    details = value;
                    NotifyPropertyChanged("ContactDetails");
                }
            }
        }
    }
}
