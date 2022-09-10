using NuxeoClient.Wrappers;
using NuxeoFileManagementApp.Interfaces;
using System.Collections.ObjectModel;

namespace NuxeoFileManagementApp.ViewModel
{
    public class FolderPageViewModel : BaseViewModel
    {
        public ObservableCollection<Document> Documents { get; } = new ObservableCollection<Document>();

        private INuxeoService _nuxeoService;

        public FolderPageViewModel(INuxeoService nuxeoService)
        {
            _nuxeoService = nuxeoService;
        }

    }
}
