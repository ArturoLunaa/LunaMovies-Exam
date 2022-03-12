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
    public partial class MovieListView : ContentPage
    {
        public MovieListView()
        {
            InitializeComponent();

            BindingContext = new MovieViewModel();

        }
    }
}