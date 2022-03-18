using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2IIPExamen.Controller;
using System.IO;


namespace PM2IIPExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lista : ContentPage
    {
        
        public lista()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await sitiosController.ObtenerSitios();
        }

        private async void ListaEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var d = e.SelectedItem as Models.apiSitios.SitioC;

            
            // img
            var byteArray = Convert.FromBase64String(d.imgT);
            System.IO.Stream stream = new MemoryStream(byteArray);
            var imageSource = ImageSource.FromStream(() => stream);
            imgFoto.Source = imageSource;

            /* audio*/
            String b64 = d.audioT;
            

            //System.IO.File.WriteAllBytes("th.wav", bytes);
            /*
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //audio.Load("PM2IIPExamen.th.wav");
            //audio.Play();


            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("PM2IIPExamen.th.wav");
            audio.Load(audioStream);

            */
            //Play(decodedString);
            //   await DisplayAlert("Proceso Terminado", d.sitiosA.descripcion, "OK");
        }

      
        



    }
}