﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SpotifyApp.Models;

namespace SpotifyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPage : ContentPage
	{
		public NoteEntryPage ()
		{
			InitializeComponent ();
		}

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            } else
            {
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            
            if(File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }

            await Navigation.PopAsync();
        }
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
	}
}