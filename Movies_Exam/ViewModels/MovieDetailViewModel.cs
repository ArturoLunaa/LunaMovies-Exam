using Movies_Exam.Models;
using Movies_Exam.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Movies_Exam.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        //Variables locales
        private readonly MovieViewModel MovieViewModel;
        //Comandos
        private Command _DeleteCommand;
        public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        private Command _SaveCommand;
        public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        //Propiedades
        private int _MovieID;
        public int MovieID
        {
            get => _MovieID;
            set => SetProperty(ref _MovieID, value);
        }

        private string _MovieName;
        public string MovieName
        {
            get => _MovieName;
            set => SetProperty(ref _MovieName, value);
        }

        private string _MovieCategory;
        public string MovieCategory
        {
            get => _MovieCategory;
            set => SetProperty(ref _MovieCategory, value);
        }

        private float _MoviePrice;
        public float MoviePrice
        {
            get => _MoviePrice;
            set => SetProperty(ref _MoviePrice, value);
        }


        private string _MovieImage;
        public string MovieImage
        {
            get => _MovieImage;
            set => SetProperty(ref _MovieImage, value);
        }

        //Constructor
        public MovieDetailViewModel(MovieViewModel movieViewModel)
        {
            this.MovieViewModel = movieViewModel;

        }

        public MovieDetailViewModel(MovieViewModel movieViewModel, MovieClass movie)
        {
            this.MovieViewModel = movieViewModel;
            //Cargamos los datos de la peli seleccionada
            //Primera opción
            MovieID = movie.ID;
            MovieName = movie.Name;
            MovieCategory = movie.Category;
            MoviePrice = movie.Price;
            MovieImage = movie.Image;
        }

        //Métodos y procedimientos
        private void SaveAction(object obj)
        {
            if (MovieID == 0)
            {
                //Crear
                int newID = this.MovieViewModel.MemoryMovies.Count + 1;
                this.MovieViewModel.MemoryMovies.Add(
                    new MovieClass
                    {
                        ID = newID,
                        Name = MovieName,
                        Category = MovieCategory,
                        Price = MoviePrice,
                        Image = MovieImage
                    });
            }
            else
            {
                //Actualizar
                foreach (MovieClass movie in this.MovieViewModel.MemoryMovies)
                {
                    if (movie.ID == MovieID)
                    {
                        movie.Name = MovieName;
                        movie.Category = MovieCategory;
                        movie.Price = MoviePrice;
                        movie.Image = MovieImage;
                        break;
                    }
                }
            }
            this.MovieViewModel.ListRefresh();

            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void DeleteAction(object obj)
        {
            //Usando un foreach instanseamos la MovieClass
           foreach (MovieClass movie in this.MovieViewModel.MemoryMovies)
           {
                //Le decimos que compare el id solicitado con los que hay en la lista y cuando lo encuentre
                //que lo elimine
                if(movie.ID == MovieID)
                {
                    this.MovieViewModel.MemoryMovies.Remove(movie);
                    break;
                }
           }
           //Refrescamos la vista
            this.MovieViewModel.ListRefresh();

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
