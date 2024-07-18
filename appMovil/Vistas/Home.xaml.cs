using LabReciclaje.Service;
using System.Collections.ObjectModel;

namespace LabReciclaje.Vistas;

public partial class Home : ContentPage
{
    public ObservableCollection<Item> Items { get; set; }
    CategoriaService categoriaService;
    public Home()
	{
		InitializeComponent();
        categoriaService = new CategoriaService();
        LoadItemsAsync();
    }

    public async Task LoadItemsAsync()
    {
        try
        {
            var categorias = await categoriaService.GetCategoriasAsync();

            Items = new ObservableCollection<Item>();
            foreach (var categoria in categorias)
            {
                Items.Add(new Item
                {
                    IdCategoria = categoria.Id,
                    Titulo = categoria.Nombre,
                    BackgroundColor = GetBackgroundColor(categoria.Color),
                    Icon = categoria.Icon
                });
            }

            itemsCollectionView.ItemsSource = Items;
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }



    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
    private  void OnFrameTapped(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var selectedItem = frame.BindingContext as Item;
        if (selectedItem != null)
        {
            NavigateToCentroPage(selectedItem);
        }
    }

    private async void NavigateToCentroPage(Item selectedItem)
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
        {
            await navigationPage.PushAsync(new CentroPage(selectedItem));
        }
        else
        {
            Application.Current.MainPage = new NavigationPage(new CentroPage(selectedItem));
        }
    }

    private Color GetBackgroundColor(string colorHex)
    {
        if (!string.IsNullOrEmpty(colorHex))
        {
            return Color.FromHex(colorHex);
        }
        return Color.FromHex("#F3F4F6");
    }

}

public class Item
{
    public int IdCategoria { get; set; }
    public string Titulo { get; set; }
    public Color BackgroundColor { get; set; }
    public string Icon { get; set; }
}