using Newtonsoft.Json;
namespace LabReciclaje.Vistas;

public partial class TemplateHeader : ContentView
{
    private FlyoutPage _parentFlyoutPage;

    public TemplateHeader()
	{
		InitializeComponent();
    }



    private void btn_openMenu_Clicked(object sender, EventArgs e)
    {
        var parentPage = GetParentPage();
        var userPopup = parentPage?.FindByName<ContentView>("userPopup");
        if (userPopup != null)
        {
            userPopup.IsVisible = !userPopup.IsVisible;
        }
    }

    private ContentPage GetParentPage()
    {
        Element parent = this;
        while (parent.Parent != null && !(parent is ContentPage))
        {
            parent = parent.Parent;
        }
        return parent as ContentPage;
    }
}