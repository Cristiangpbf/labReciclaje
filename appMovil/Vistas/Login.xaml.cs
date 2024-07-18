
using Newtonsoft.Json;
using LabReciclaje.Service;

namespace LabReciclaje.Vistas;

public partial class Login : ContentPage
{
    UsuarioService usuarioService;
	public Login()
    {
        InitializeComponent();
        usuarioService = new UsuarioService();
    }

    private async void btn_loguearse_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_usuario.Text) && !string.IsNullOrEmpty(txt_password.Text))
        {
            string email = txt_usuario.Text;
            string password = txt_password.Text;

            try
            {
                try
                {
                    loadingOverlay.IsVisible = true;
                    blockElemt();
                    var userResponse = await usuarioService.LoginAsync(email, password);
                    if (userResponse != null)
                    {
                        Preferences.Set("UserResponse", JsonConvert.SerializeObject(userResponse));
                        await SecureStorage.SetAsync("auth_token", userResponse.Token);
                        await DisplayAlert("Info", $"Bienvenido: {userResponse.Nombres + " " + userResponse.Apellidos}", "OK");
                        Application.Current.MainPage = new NoticiaPage();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Usuario no encontrado.", "OK");

                    }

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            }
            finally
            {
                loadingOverlay.IsVisible = false;
                enableElemt();
            }
        }
        else {
            await DisplayAlert("Error", "Existen campos vacios.", "OK");
        }
    }

    public void blockElemt()
    {
        txt_usuario.IsEnabled = false; txt_password.IsEnabled = false; btn_loguearse.IsEnabled = false;
    }

    public void enableElemt()
    {
        txt_usuario.IsEnabled = true; txt_password.IsEnabled = true; btn_loguearse.IsEnabled = true;
    }

    private void btn_registrar_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new CrearCuenta());
    }
}