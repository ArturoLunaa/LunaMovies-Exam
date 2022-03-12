using Movies_Exam.Models;
using Movies_Exam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies_Exam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailView : ContentPage
    {
        MovieClass Movie = new MovieClass();

        public MovieDetailView(MovieViewModel movieViewModel)
        {
            InitializeComponent();

            BindingContext = new MovieDetailViewModel(movieViewModel);

           
        }

        public MovieDetailView(MovieViewModel movieViewModel, MovieClass movie)
        {
            InitializeComponent();

            BindingContext = new MovieDetailViewModel(movieViewModel, movie);

            // Cargar película seleccionada en el detalle
            this.Movie.ID = movie.ID;
            ImagePicture.Source = movie.Image;
            EntryName.Text = movie.Name;
            EntryCategory.Text = movie.Category;
            EntryPrice.Text = movie.Price.ToString();
            EntryImage.Text = movie.Image;
           
        }

    }
}