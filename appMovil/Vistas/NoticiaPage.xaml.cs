using LabReciclaje.Service;

namespace LabReciclaje.Vistas;

public partial class NoticiaPage : ContentPage
{
    NoticiaService noticiaService;

    public NoticiaPage()
	{
		InitializeComponent();
        noticiaService = new NoticiaService();
        LoadNoticias();

    }

    public async void LoadNoticias()
    {
        try
        {
            var noticia = await noticiaService.GetNoticiaAsync();
            cv_noticias.ItemsSource = noticia;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }


    private void OnFrameTapped(object sender, EventArgs e)
    {
    }
}