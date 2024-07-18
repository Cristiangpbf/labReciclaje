using LabReciclaje.Modelo;
using LabReciclaje.Service;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace LabReciclaje.Vistas;

public partial class CentroPage : ContentPage
{
    CentroService centroService;
    ObjetoService objetoService;

    public CentroPage(Item selectedItem)
	{
		InitializeComponent();
        lbl_titulo.Text = selectedItem.Titulo;
        centroService = new CentroService();
        objetoService = new ObjetoService();

        LoadCentros(selectedItem.IdCategoria);



    }

    public async void LoadCentros(int idCategoria)
    {
        try
        {
            var objeto = await objetoService.GetObjetoAsync(idCategoria);
            cv_detalle.ItemsSource = objeto;

            var categorias = await centroService.GetCentrosAsync();
            cv_centros.ItemsSource = categorias;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private void cv_centros_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private async void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var selectedItem = frame.BindingContext as CentroResponse;
        if (selectedItem != null)
        {
            string latitude = selectedItem.Latitud;
            string longitude = selectedItem.Longitud;

            string mapsUrl = $"https://www.google.com/maps?q={latitude},{longitude}";

            await Launcher.OpenAsync(new Uri(mapsUrl));
        }
    }
}