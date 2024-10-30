namespace Password_Manager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.NewUserView();
        }
    }
}
