using MobilApp.ViewModels;
using System.Collections.ObjectModel;

namespace MobilApp
{
    public partial class MainPage : ContentPage
    {
       
       

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; 
          
        }

        
    }

}
