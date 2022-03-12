using Movies_Exam.Models;
using Movies_Exam.ViewModels;
using Movies_Exam.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Movies_Exam.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        //Varia
        public List<MovieClass> MemoryMovies;

        //Declaración de comandos Binding
        private Command _LoadCommand;

        public Command LoadCommand => _LoadCommand ?? (_LoadCommand = new Command(LoadAction));

        private Command _NewCommand;

        public Command NewCommand => _NewCommand ?? (_NewCommand = new Command(NewAction));

        private Command _SelectedCommand;

        public Command SelectedCommand => _SelectedCommand ?? (_SelectedCommand = new Command(SelectedAction));


        //Declaración de propiedades Binding
        private List<MovieClass> _ListMovies;

        public List<MovieClass> ListMovies
        {
            get => _ListMovies;
            set => SetProperty(ref _ListMovies, value);
        }

        private MovieClass _SelectedMovie;

        public MovieClass SelectedMovie
        {
            get => _SelectedMovie;
            set => SetProperty(ref _SelectedMovie, value);
        }



        //Constructor
        public MovieViewModel()
        {
            //Cargamos variable local con las pelis iniciales
            MemoryMovies = new List<MovieClass>
            {
                new MovieClass()
                {
                    ID = 1,
                    Name = "Spiderman",
                    Category = "Acción, Infantil",
                    Price = 250,
                    Image = "https://sm.ign.com/t/ign_es/screenshot/default/spiderman-2_2h6a.h720.jpg"
                },
                new MovieClass()
                {
                     ID = 2,
                    Name = "Titanic",
                    Category = "Romance",
                    Price = 300,
                    Image = "https://i.blogs.es/4a9cb1/titanic/840_560.jpeg"
                },
                new MovieClass()
                {
                    ID = 3,
                    Name = "Great Gatsby",
                    Category = "Suspenso",
                    Price = 120,
                    Image = "https://imagenes.elpais.com/resizer/KYpS6gcPDN6yS9g6sEaMwN8j4TE=/1960x0/cloudfront-eu-central-1.images.arcpublishing.com/prisa/OELBTQVASPM4NOSABV7NM4HSHA.jpg"
                },
                new MovieClass()
                {
                     ID = 4,
                    Name = "Gol!",
                    Category = "Deportes, Drama",
                    Price = 500,
                    Image = "https://e00-marca.uecdn.es/assets/multimedia/imagenes/2018/02/27/15197556536850.jpg"
                },
                new MovieClass()
                {
                     ID = 5,
                    Name = "Matilda",
                    Category = "Fantasía, Infantil",
                    Price = 320,
                    Image = "https://i.ytimg.com/vi/7i-hSS2xYTI/maxresdefault.jpg"
                },
                new MovieClass()
                {
                     ID = 6,
                    Name = "Cuestión de tiempo",
                    Category = "Romance, Fantasía",
                    Price = 300,
                    Image = "https://eselcine.com/wp-content/uploads/2013/10/una-cuestion-de-tiempo-pelicula.jpg"
                }
            };
        }

        //Metodos y procedimientos
        private void LoadAction()
        {
            //Las peliculas en memoria se despliegan en collectionView
            ListMovies = null;
            ListMovies = MemoryMovies;
        }


        private void NewAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MovieDetailView(this));
        }

        private void SelectedAction()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MovieDetailView(this, SelectedMovie));
        }


        public void ListRefresh()
        {
            LoadAction();
        }
    }
}
