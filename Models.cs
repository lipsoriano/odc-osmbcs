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
            set { SetProperty(ref firstname, value); }
        }
        public string MiddleName
        {
            get { return middlename; }
            set { SetProperty(ref middlename, value); }
        }
        public string LastName
        {
            get { return lastname; }
            set { SetProperty(ref lastname, value); }
        }
    }
    
    //public class RepContacts : ViewModelEntity
    //{
    //    public RepContacts()
    //    {

    //    }
    //    protected string typeidr;
    //    protected string typenamer;
    //    protected string detailsr;

    //    public string RepContactTypeID
    //    {
    //        get { return typeidr; }
    //        set
    //        {
    //            if (typeidr != value)
    //            {
    //                typeidr = value;
    //                NotifyPropertyChanged("RepContactTypeID");
    //            }
    //        }
    //    }
    //    public string RepContactType
    //    {
    //        get { return typenamer; }
    //        set
    //        {
    //            if (typenamer != value)
    //            {
    //                typenamer = value;
    //                NotifyPropertyChanged("RepContactType");
    //            }
    //        }
    //    }
    //    public string RepContactDetails
    //    {
    //        get { return detailsr; }
    //        set
    //        {
    //            if (detailsr != value)
    //            {
    //                detailsr = value;
    //                NotifyPropertyChanged("RepContactDetails");
    //            }
    //        }
    //    }
    //}

    public class Contact : ViewModelEntity
    {
        public Contact()
        {

        }
        protected string typeid;
        protected string typename;
        protected string details;

        public string ContactTypeID
        {
            get { return typeid; }
            set { SetProperty(ref typeid, value); }
        }
        public string ContactType
        {
            get { return typename; }
            set { SetProperty(ref typename, value); }
        }
        public string ContactDetails
        {
            get { return details; }
            set { SetProperty(ref details, value); }
        }
    }

}
