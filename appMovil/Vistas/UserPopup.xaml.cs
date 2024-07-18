using LabReciclaje.Modelo;
using Newtonsoft.Json;

namespace LabReciclaje.Vistas;

public partial class UserPopup : ContentView
{
	public UserPopup()
	{
		InitializeComponent();
        var userResponseJson = Preferences.Get("UserResponse", string.Empty);
        if (!string.IsNullOrEmpty(userResponseJson))
        {
            var userResponse = JsonConvert.DeserializeObject<UsuarioResponse>(userResponseJson);
            lbl_user.Text = userResponse.Nombres + " - "+ userResponse.Apellidos;
            lbl_userEmail.Text = userResponse.Email;
        }
    
    }


    private async void btn_logout_Clicked(object sender, EventArgs e)
    {
        SecureStorage.Remove("auth_token");
        Application.Current.MainPage = new NavigationPage(new Login());
    }

    private void optionsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            string selectedOption = e.CurrentSelection[0] as string;
            switch (selectedOption)
            {
                case "Que Reciclar":
                    Application.Current.MainPage = new NavigationPage(new Home());
                    break;
                case "Mi perfil":
                    Application.Current.MainPage = new NavigationPage(new Perfil());
                    break;
                case "Noticias / Novedades":
                    Application.Current.MainPage = new NavigationPage(new NoticiaPage());
                    break;
            }
        }
    }



}