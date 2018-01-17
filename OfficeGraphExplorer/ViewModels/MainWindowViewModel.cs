using OfficeGraphTest.Domain.Contracts;
using OfficeGraphTest.Domain.Entities;
using System.Windows.Input;

namespace OfficeGraphExplorer.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IOfficeGraphClient _officeGraphClient;

        private GraphUser    _me;
        private byte[]       _myImageUrl;
        private RelayCommand _reloadCommand;
        private string       _statusMessage;
        private RelayCommand _getContactsCommand;


        public MainWindowViewModel()
        {
            //TODO: Dirty, let's fix this sometime soon, and NOT use a static IoC Container for resolving dependencies!
            _officeGraphClient = App.IoC.GetInstance<IOfficeGraphClient>();

            var initalized = _officeGraphClient.Initialize();

            // hmm, what to do..
        }

        #region Bindable Properties and Commands 

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
                if (_myImageUrl == null)
                    RetrieveMyImage();

                return _myImageUrl;

            }
        }

        #endregion


        #region Private helper methods

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
            _myImageUrl = await _officeGraphClient.GetMyImageBytesAsync();
            AnnounceProperty("MyImage");
        }


        public async void RetrieveMyInformation()
        {
            _me = await _officeGraphClient.GetMyInformationAsync();
            AnnounceProperty("Me");
        }

        #endregion
    }
}
