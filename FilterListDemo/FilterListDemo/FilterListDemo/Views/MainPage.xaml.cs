using Xamarin.Forms;

namespace FilterListDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FilterUsersListView.ItemSelected += (sender, args) => FilterUsersListView.SelectedItem = null;
        }
    }
}
