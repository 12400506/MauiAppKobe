using MauiApp1.Service;
using Newtonsoft.Json;
using ClassLibrary1;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        private void CarData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTeam = e.CurrentSelection.FirstOrDefault() as Car;
            if (selectedTeam == null)
                return;
            CarData.SelectedItem = null;

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            var service = new RestService();
            var response = await service.GetCars();

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<List<Car>>(json);
                CarData.ItemsSource = car;
            }
            else
            {
                await DisplayAlert("Error", "Couldnt Load Cars Try Again Later", "Ok");
            }
        }


    }

}
