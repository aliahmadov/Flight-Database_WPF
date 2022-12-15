using Flight_Database_WPF.Entities;
using Flight_Database_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Database_WPF.ViewModels
{
    public class TicketShowViewModel:BaseViewModel
    {

        private Ticket ticket;

        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; OnPropertyChanged(); }
        }

        private DateTime dateTime;

        public DateTime ArrivalDate
        {
            get { return dateTime; }
            set { dateTime = value; OnPropertyChanged(); }
        }

        private string arrivalAirport;

        public string ArrivalAirport
        {
            get { return arrivalAirport; }
            set { arrivalAirport = value; OnPropertyChanged(); }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;OnPropertyChanged(); }
        }


    }
}
