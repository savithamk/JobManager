using System.ComponentModel;
using Xamarin.Forms;
using JobManager.ViewModels;

namespace JobManager.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
