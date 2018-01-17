using OfficeGraphTest.Domain.Contracts;
using OfficeGraphTest.Domain.Entities;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace OfficeGraphExplorer.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private const string SIGN_IN  = "Sign In";
        private const string SIGN_OUT = "Sign Out";

        private readonly IOfficeGraphClient _officeGraphClient;

        private GraphUser    _me;
        private byte[]       _myImageBytes;
        private byte[]       _defaultImage;
        private RelayCommand _reloadCommand;
        private string       _statusMessage;
        private RelayCommand _getContactsCommand;
        private RelayCommand _signInOrOutCommand;

        // SignIn Button
        private string          _signInButtonText;
        private Brush           _signInButtonColor;
        private FontWeight      _signInButtonFontWeight;
        private Brush           _signInButtonForeground;


        public MainWindowViewModel()
        {
            //TODO: Dirty, let's fix this sometime soon, and NOT use a static IoC Container for resolving dependencies!
            _officeGraphClient = App.IoC.GetInstance<IOfficeGraphClient>();

            _signInButtonText        = "Sign In";
            _signInButtonColor       = new SolidColorBrush(Colors.DarkGreen);
            _signInButtonFontWeight  = FontWeights.Bold;
            _signInButtonForeground  = new SolidColorBrush(Colors.White);
        }


        #region Bindable Properties and Commands 


        public ICommand SignInOrOutCommand
        {
            get
            {
                if (_signInOrOutCommand == null)
                    _signInOrOutCommand = new RelayCommand(OnSignInOrOut);

                return _signInOrOutCommand;
            }
        }


        public Brush SignInButtonForeground
        {
            get { return _signInButtonForeground; }
            set { _signInButtonForeground = value; AnnounceProperty(nameof(SignInButtonForeground)); }
        }


        public string SignInButtonText
        {
            get { return _signInButtonText;  }
            set { _signInButtonText = value; AnnounceProperty(nameof(SignInButtonText)); }
        }


        public FontWeight SignInButtonFontWeight
        {
            get { return _signInButtonFontWeight; }
            set { _signInButtonFontWeight = value; AnnounceProperty(nameof(SignInButtonFontWeight)); }
        }


        public Brush SignInButtonColor
        {
            get { return _signInButtonColor; }
            set { _signInButtonColor = value; AnnounceProperty(nameof(SignInButtonColor)); }
        }


        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; AnnounceProperty(nameof(StatusMessage)); }
        }


        public ICommand ReloadCommand
        {
            get
            {                
                if (_reloadCommand == null)
                    _reloadCommand = new RelayCommand(OnReload);


                return _reloadCommand;
            }
        }


        public ICommand GetContactsCommand
        {
            get
            {
                if (_getContactsCommand == null)
                    _getContactsCommand = new RelayCommand(OnGetContacts);

                return _getContactsCommand;
            }
        }


        public GraphUser Me
        {
            get
            {
                if (_me == null)
                    RetrieveMyInformation();
                    
                return _me;
            }
        }


        public byte[] MyImage
        {
            get
            {
                if (_myImageBytes == null)
                    RetrieveMyImage();

                return _myImageBytes;

            }
        }

        #endregion


        #region Private helper methods                


        private async void OnSignInOrOut()
        {
            // EEP, cheesy!!
            if(_signInButtonText == SIGN_IN)
            {
                StatusMessage     = "Signing in";
                SignInButtonText  = SIGN_OUT;
                SignInButtonColor = new SolidColorBrush(Colors.Red);

                if(_officeGraphClient.Initialize())
                {
                    OnReload();
                }
            }
            else
            {
                StatusMessage     = "Signing out..";
                SignInButtonText  = SIGN_IN;
                SignInButtonColor = new SolidColorBrush(Colors.Green);
                await _officeGraphClient.SignOut();

                _me = null; AnnounceProperty(nameof(Me));
                _myImageBytes = null; AnnounceProperty(nameof(MyImage));
            }
            StatusMessage = "Ok";
        }

        private async void OnGetContacts()
        {
            StatusMessage = "Retrieving Contacts...";

            var contacts = await _officeGraphClient.GetMyContactsAsync();



            StatusMessage = "Contacts retrieval complete";
        }


        private void OnReload()
        {
            StatusMessage = "Reloading data from Microsoft Graph...";

            RetrieveMyImage();
            RetrieveMyInformation();

            StatusMessage = "Data loaded";
        }


        private async void RetrieveMyImage()
        {
            _myImageBytes = await _officeGraphClient.GetMyImageBytesAsync();

            if(_myImageBytes == null)
            {
                if(_defaultImage == null)
                {
                    LoadDefaultImageFromEmbeddedResources();
                }
                _myImageBytes = _defaultImage;
            }
            AnnounceProperty("MyImage");
        }


        private void LoadDefaultImageFromEmbeddedResources()
        {
            var thisAssembly = Assembly.GetExecutingAssembly();
            var embeddedImagePath = thisAssembly.GetManifestResourceNames()
                .Where(name => name.EndsWith("man.png"))
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(embeddedImagePath))
            {
                var imageStream = thisAssembly.GetManifestResourceStream(embeddedImagePath);
                using (var memoryStream = new MemoryStream())
                {
                    imageStream.CopyTo(memoryStream);
                    _defaultImage = memoryStream.ToArray();
                }
            }
        }


        public async void RetrieveMyInformation()
        {
            _me = await _officeGraphClient.GetMyInformationAsync();
            if(_me != null)
            {
                AnnounceProperty("Me");
            }
        }

        #endregion
    }
}
