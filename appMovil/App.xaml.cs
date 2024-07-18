namespace LabReciclaje
{
    public partial class App : Application
    {
        private bool _isAuthenticated;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Login());
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await HandleAuthenticationAsync();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private async Task HandleAuthenticationAsync()
        {
            if (!_isAuthenticated)
            {
                string token = await SecureStorage.GetAsync("auth_token");

                if (!string.IsNullOrEmpty(token))
                {
                    MainPage = new NavigationPage(new Vistas.NoticiaPage());
                    _isAuthenticated = true;
                }
                else
                {
                    MainPage = new NavigationPage(new Vistas.Login());
                }
            }
        }
    }
}
