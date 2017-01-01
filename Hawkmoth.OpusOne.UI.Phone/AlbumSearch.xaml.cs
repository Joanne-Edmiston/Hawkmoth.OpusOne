﻿using Hawmoth.OpusOne.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Hawkmoth.OpusOne.UI.Phone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlbumSearch : Page
    {
        private ObservableCollection<Album> albums = new ObservableCollection<Album>();

        public AlbumSearch()
        {
            this.InitializeComponent();

            AlbumsFound.ItemsSource = albums;
            Message.Text = string.Empty;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void search_Click(object sender, RoutedEventArgs e)
        {
            var musicFolder = KnownFolders.MusicLibrary;


            albums.Clear();
            Message.Text = "Searching albums ...";

            FilterByAlbumName.IsEnabled = false;
            FilterByArtist.IsEnabled = false;

            await DoAlbumSearchAsync(
                albums, 
                musicFolder, 
                searchText.Text.ToLower(), 
                FilterByAlbumName.IsChecked.GetValueOrDefault(), 
                FilterByArtist.IsChecked.GetValueOrDefault());

            FilterByAlbumName.IsEnabled = true;
            FilterByArtist.IsEnabled = true;

            if (albums.Any())
                Message.Text = "Search complete";
            else
                Message.Text = "No matching albums found";

        }


        private async Task DoAlbumSearchAsync(ObservableCollection<Album> albums, StorageFolder parent, string searchTextLower, bool filterName, bool filterArtist)
        {


            foreach (var item in await parent.GetFilesAsync())
            {
                var musicProperties = await item.Properties.GetMusicPropertiesAsync();

                if (musicProperties == null)
                    continue;

                var albumName = musicProperties.Album;
                var albumArtist = musicProperties.AlbumArtist;
                var artist = musicProperties.Artist;

                
                if ((filterName && albumName.ToLower().Contains(searchTextLower))
                    ||
                    (filterArtist && (albumArtist.ToLower().Contains(searchTextLower) || artist.ToLower().Contains(searchTextLower))))
                {
                    var album = albums.FirstOrDefault(a => a.Name == albumName);

                    if (album == null)
                    {
                        album = new Album
                        {
                            Name = albumName,
                            Artist = albumArtist,
                        };
                        albums.Add(album);
                        AlbumsFound.UpdateLayout();
                    }

                    if (!album.Songs.Any(s => s.Path == item.Path))
                    {
                        album.Songs.Add(item);
                    }
                }
            }

            foreach (var item in await parent.GetFoldersAsync()) await DoAlbumSearchAsync(albums, item, searchTextLower, filterName, filterArtist);
        }
        private void results_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterOption_Changed(object sender, RoutedEventArgs e)
        {
            if (FilterByAlbumName == null || FilterByArtist == null)
                return;

            if (FilterByAlbumName.IsChecked.GetValueOrDefault() || FilterByArtist.IsChecked.GetValueOrDefault())
                search.IsEnabled = true;
            else
                search.IsEnabled = false;
        }
    }
}
