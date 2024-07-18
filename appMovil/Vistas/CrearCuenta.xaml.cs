using LabReciclaje.Modelo;
using LabReciclaje.Service;

namespace LabReciclaje.Vistas;

public partial class CrearCuenta : ContentPage
{
    UsuarioService usuarioService;

    public CrearCuenta()
	{
		InitializeComponent();
        usuarioService = new UsuarioService();

    }

    private async void btn_crear_Clicked(object sender, EventArgs e)
    {
        if (txt_nombres.Text != null || txt_apellidos.Text != null || txt_usuario.Text != null || txt_email.Text != null || txt_password.Text != null || txt_password2.Text != null)
        {

            if (await usuarioService.ValidarUsuarioAsync(txt_usuario.Text))
            {
                DisplayAlert("Error", "Ya existe el nombre de usuario.", "OK");

            }
            else
            {
               if (txt_password.Text == txt_password2.Text) {
                    UsuarioResponse userNew = new UsuarioResponse();
                    userNew.Nombres = txt_nombres.Text;
                    userNew.Apellidos = txt_apellidos.Text;
                    userNew.Email = txt_email.Text;
                    userNew.Usuario = txt_usuario.Text;
                    userNew.Password = txt_password.Text;

                    if (await usuarioService.InsertarUsuarioAsync(userNew))
                    {
                        DisplayAlert("Exito", "Tu registro fue ingresado correctamente", "OK");
                        Navigation.PushAsync(new Login());
                    }
                    else
                    {
                        DisplayAlert("Error", "Vuelve a intentar.", "OK");

                    }
                }
                else {
                    DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");

                }
            }
        }
        else
        {
            DisplayAlert("Error", "Existen campos vacios.", "OK");

        }
    }
}