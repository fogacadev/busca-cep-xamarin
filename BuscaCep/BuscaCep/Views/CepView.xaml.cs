using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BuscaCep.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CepView : ContentPage
    {
        public CepView()
        {
            InitializeComponent();
        }


        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<string>(this, "ShowDisplay", async (msg)=> {
                await DisplayAlert("Erro", msg, "Ok");
            });
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<string>(this, "showDisplay");
        }
    }
}