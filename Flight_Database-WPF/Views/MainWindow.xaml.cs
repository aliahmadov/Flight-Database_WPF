using Flight_Database_WPF.Entities;
using Flight_Database_WPF.ViewModels;
using Flight_Database_WPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flight_Database_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private FlightEntities _context;

        public string SelectedFROM { get; set; }

        public int FlightId { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            _context = new FlightEntities();
            fromCombo.ItemsSource = _context.Airports.Select(c => c.Name).ToList();
            typeCombo.ItemsSource = _context.FlightTypes.Select(c => c.FlightType1).ToList();
        }

        private void fromCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fromCombo.SelectedItem != null)
            {

                _context = new FlightEntities();
                SelectedFROM = (sender as ComboBox).SelectedItem.ToString();
                var id = _context.Airports.FirstOrDefault(c => c.Name == SelectedFROM).Id;
                toCombo.ItemsSource = _context.Sectors.Where(c => c.Flight.StartAirportId == id).Select(c => c.Airport.Name).ToList().Distinct();

            }


        }

        private void toCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _context = new FlightEntities();
            var selectedItem = (sender as ComboBox).SelectedItem;
            if (selectedItem != null)
            {

                var towhere = selectedItem.ToString();
                var id = _context.Airports.FirstOrDefault(c => c.Name == towhere).Id;
                var id_start = _context.Airports.FirstOrDefault(c => c.Name == SelectedFROM).Id;

                dateCombo.ItemsSource = _context.Sectors.Where(c => c.Flight.StartAirportId == id_start).Where(c => c.ArrivalAirportId == id)
                                                        .Select(c => c.Flight.StartDate).ToList().Distinct();



            }


        }
        private void dateCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dateCombo.SelectedItem != null)
            {
                var id = _context.Airports.FirstOrDefault(c => c.Name == toCombo.SelectedItem.ToString()).Id;
                var id_start = _context.Airports.FirstOrDefault(c => c.Name == SelectedFROM).Id;
                var selectedDate = DateTime.Parse(dateCombo.SelectedItem.ToString());
                FlightId = _context.Sectors.Where(c => c.Flight.StartAirportId == id_start).Where(c => c.ArrivalAirportId == id).
                   Where(c => c.Flight.StartDate == selectedDate).First().Flight.Id;

                // var flight = _context.Flights.Where(d => d.Id == IDS[1]).First();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var flighttypeId = _context.FlightTypes.FirstOrDefault(c => c.FlightType1 == typeCombo.SelectedItem.ToString()).Id;
            var flightType = _context.FlightTypes.FirstOrDefault(c => c.FlightType1 == typeCombo.SelectedItem.ToString());
            var flight = _context.Flights.Where(c => c.Id == FlightId).First();
            Ticket ticket = new Ticket
            {
                FlightTypeId = flighttypeId,
                FlightId = FlightId,
                Flight = flight,
                FlightType = flightType
            };

            var arrivalDate = _context.Sectors.Where(c => c.FlightId == FlightId).Select(c => c.ArrivalDate).First();
            var arrivalCountry = _context.Sectors.Where(c => c.FlightId == FlightId).Select(c => c.Airport.Name).First();

            var uC = new TicketUC();
            var vM = new TicketShowViewModel();
            var window = new TicketShow();
            uC.DataContext = vM;
            vM.Ticket = ticket;
            vM.Name = txtBox.Text;
            vM.ArrivalAirport = arrivalCountry;
            vM.ArrivalDate = arrivalDate;
            uC.Width = 450;
            uC.Height = 480;
            uC.Margin = new Thickness(10, 10, 10, 10);

            window.stackPanel.Children.Add(uC);

            window.ShowDialog();
            toCombo.SelectedItem = null;
            toCombo.ItemsSource = null;

            fromCombo.SelectedItem = null;

            dateCombo.SelectedItem = null;
            dateCombo.ItemsSource = null;

            typeCombo.SelectedItem = null;
            txtBox.Text = "";
            //stack.Children.Add(uC);


        }

    }
}
