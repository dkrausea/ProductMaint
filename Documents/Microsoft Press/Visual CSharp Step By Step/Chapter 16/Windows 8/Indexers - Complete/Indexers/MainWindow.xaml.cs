using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Indexers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Page
    {
        private PhoneBook phoneBook = new PhoneBook();

        public MainWindow()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += App.WindowSizeChanged;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void findByNameClick(object sender, RoutedEventArgs e)
        {
            string text = name.Text;
            if (!String.IsNullOrEmpty(text))
            {
                Name personsName = new Name(text);
                PhoneNumber personsPhoneNumber = this.phoneBook[personsName];
                phoneNumber.Text = String.IsNullOrEmpty(personsPhoneNumber.Text) ?
                                       "Not Found" : personsPhoneNumber.Text;
            }
        }

        private void findByPhoneNumberClick(object sender, RoutedEventArgs e)
        {
            string text = phoneNumber.Text;
            if (!String.IsNullOrEmpty(text))
            {
                PhoneNumber personsPhoneNumber = new PhoneNumber(text);
                Name personsName = this.phoneBook[personsPhoneNumber];
                name.Text = String.IsNullOrEmpty(personsName.Text) ?
                                "Not Found" : personsName.Text;
            }
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(phoneNumber.Text))
            {
                phoneBook.Add(new Name(name.Text),
                              new PhoneNumber(phoneNumber.Text));
                name.Text = "";
                phoneNumber.Text = "";
            }
        }
    }
}
