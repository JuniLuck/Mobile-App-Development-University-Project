namespace _6002AndroidApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("register", typeof(Views.Register));
            Routing.RegisterRoute("newcharacter", typeof(Views.NewCharacter));
            Routing.RegisterRoute("chooseimage", typeof(Views.ChooseImage));
        }
    }
}
