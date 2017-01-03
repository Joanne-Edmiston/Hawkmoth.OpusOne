using Hawkmoth.OpusOne.Data.Phone;
using Hawmoth.OpusOne.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Hawkmoth.OpusOne.UI.Phone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Album> albumsFound;
        private List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem() { Title = "Album Search",   ClassType = typeof(AlbumSearch) },
            new MenuItem() { Title = "Playlists",   ClassType = typeof(Playlists) },
        };

        public MainPage()
        {
            InitializeComponent();

            // This is a static public property that allows downstream pages to get a handle to the MainPage instance
            // in order to call methods that are in this class.
            Current = this;

            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;

        }




        public static MainPage Current;        
        public List<MenuItem> MenuItems
        {
            get { return menuItems; }
        }

        public PlayList PlayList { get; set; }

        public ObservableCollection<Album> AlbumsFound
        {
            get
            {
                return albumsFound ?? (albumsFound = new ObservableCollection<Album>());
            }
            set
            {
                albumsFound = value;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            if (MainFrame.Content == null)
            {
                await RunIndexerAsync();

                if (!MainFrame.Navigate(typeof(MainMenu)))
                {
                    throw new Exception("Failed to load main menu");
                }

            }

        }



        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();

                //Indicate the back button press is handled so the app does not exit
                e.Handled = true;
            }
        }


        private async Task RunIndexerAsync()
        {
            using (IUnitOfWork uow = new UnitOfWork(App.DB_PATH))
            {
                var songRepository = uow.GetRepository<Song>();
                var albumRepository = uow.GetRepository<Album>();

                await songRepository.CreateTableAsync();
                await albumRepository.CreateTableAsync();
            }
        }

      
    }
}
