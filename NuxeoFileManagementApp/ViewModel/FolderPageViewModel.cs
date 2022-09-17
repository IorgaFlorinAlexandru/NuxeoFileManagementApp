using NuxeoClient.Wrappers;
using NuxeoFileManagementApp.Helpers;
using NuxeoFileManagementApp.Interfaces;
using System.Collections.ObjectModel;
using Task = System.Threading.Tasks.Task;

namespace NuxeoFileManagementApp.ViewModel
{
    public class FolderPageViewModel : BaseViewModel
    {
        public ObservableCollection<Document> DocumentChildren { get; } = new ObservableCollection<Document>();

        public string folderPath = "/default-domain";
        public string FolderPath
        {
            get => folderPath;
            set
            {
                folderPath = value;
                OnPropertyChanged(nameof(FolderPath));
            }
        }

        private INuxeoService _nuxeoService;

        public Command GetDocumentsCommand { get; }

        public FolderPageViewModel()
        {
            _nuxeoService = ServiceHelper.GetService<INuxeoService>();
            GetDocumentsCommand = new Command(async () => await GetDocuments());
            
        }

        async Task GetDocuments()
        {
            isRefreshing = true;
            DocumentChildren.Clear();
            var folderDocuments = await _nuxeoService.GetDocuments(FolderPath);
            if (folderDocuments.Count != 0)
                DocumentChildren.Clear();

            foreach (var document in folderDocuments)
                DocumentChildren.Add(document);
            IsRefreshing = false;
        }

    }
}
