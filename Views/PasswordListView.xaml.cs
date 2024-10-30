using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;

namespace Password_Manager.Views
{
    public partial class PasswordListView : ContentPage
    {
        public ObservableCollection<PasswordRow> Passwords { get; set; }

        public PasswordListView()
        {
            InitializeComponent();

            // Initialize dummy data
            Passwords = new ObservableCollection<PasswordRow>
            {
                new PasswordRow { UserID = 1, PasswordID = 1, Platform = "Facebook", Password = "sk2ksn0!" },
                new PasswordRow { UserID = 1, PasswordID = 2, Platform = "Google", Password = "sk2ksn0!" },
                new PasswordRow { UserID = 1, PasswordID = 3, Platform = "Spotify", Password = "sk2ksn0!" },
                new PasswordRow { UserID = 1, PasswordID = 4, Platform = "Youtube", Password = "sk2ksn0!" },
                new PasswordRow { UserID = 1, PasswordID = 5, Platform = "Apple", Password = "sk2ksn0!" }
            };

            // Bind the ObservableCollection to the CollectionView
            PasswordCollectionView.ItemsSource = Passwords;
        }

        private async void btnAddNewPassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPasswordView());
        }

        private void CopyPassToClipboard(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int passwordId)
            {
                var passwordRow = Passwords.FirstOrDefault(p => p.PasswordID == passwordId);
                if (passwordRow != null)
                {
                    Clipboard.SetTextAsync(passwordRow.Password);
                    DisplayAlert("Copied", $"Password for {passwordRow.Platform} copied to clipboard.", "OK");
                }
            }
        }

        private void EditPassword(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int passwordId)
            {
                var passwordRow = Passwords.FirstOrDefault(p => p.PasswordID == passwordId);
                if (passwordRow != null)
                {
                    passwordRow.Editing = !passwordRow.Editing;
                }
            }
        }

        private void DeletePassword(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is int passwordId)
            {
                var passwordRow = Passwords.FirstOrDefault(p => p.PasswordID == passwordId);
                if (passwordRow != null)
                {
                    Passwords.Remove(passwordRow);
                    DisplayAlert("Deleted", $"Password for {passwordRow.Platform} deleted.", "OK");
                }
            }
        }
    }

    // PasswordRow Model within the same file
    public class PasswordRow : BindableObject, INotifyPropertyChanged
    {
        public int UserID { get; set; }
        public int PasswordID { get; set; }
        public string Platform { get; set; } = "";

        private string _pass = "";
        private bool _isShown = false;
        private bool _editing = false;

        public string Password
        {
            get { return _pass; }
            set
            {
                _pass = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsShown
        {
            get { return _isShown; }
            set
            {
                _isShown = value;
                OnPropertyChanged(nameof(IsShown));
                OnPropertyChanged(nameof(ShowPass));
            }
        }

        public bool ShowPass => !_isShown;

        public bool Editing
        {
            get { return _editing; }
            set
            {
                _editing = value;
                OnPropertyChanged(nameof(Editing));
                OnPropertyChanged(nameof(ShowToggle));
            }
        }

        public bool ShowToggle => !_editing;
    }
}
