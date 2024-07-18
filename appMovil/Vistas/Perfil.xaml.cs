using LabReciclaje.Modelo;
using LabReciclaje.Service;
using Newtonsoft.Json;

namespace LabReciclaje.Vistas;

public partial class Perfil : ContentPage
{
    UsuarioService usuarioService;
    int perfilId;
    public Perfil()
	{
		InitializeComponent();
        usuarioService = new UsuarioService();

        var userResponseJson = Preferences.Get("UserResponse", string.Empty);
        if (!string.IsNullOrEmpty(userResponseJson))
        {
            var userResponse = JsonConvert.DeserializeObject<UsuarioResponse>(userResponseJson);
            lbl_nombres.Text = userResponse.Nombres;
            lbl_apellidos.Text = userResponse.Apellidos;
            txt_email.Text = userResponse.Email;
            lbl_usuario.Text = userResponse.Usuario;
            perfilId = userResponse.IdUsuario;
        }
    }

    private async void btn_actualizar_Clicked(object sender, EventArgs e)
    {
        if (txt_email.Text != null)
        {

            if (await usuarioService.ActualizarUsuarioAsync(perfilId,txt_email.Text,txt_password.Text))
            {
                DisplayAlert("Exito", "Tus datos fueron actualizados.", "OK");
                var userResponseJson = Preferences.Get("UserResponse", string.Empty);
                var userResponse = JsonConvert.DeserializeObject<UsuarioResponse>(userResponseJson);
                userResponse.Email= txt_email.Text;
                Preferences.Set("UserResponse", JsonConvert.SerializeObject(userResponse));


                Navigation.PushAsync(new Perfil());
            }
            else
            {
                DisplayAlert("Error", "Vuelve a intentar.", "OK");

            }
        }
        else
        {
            DisplayAlert("Error", "Existen campos vacios.", "OK");

        }
    }
}