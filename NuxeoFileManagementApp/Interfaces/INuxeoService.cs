using NuxeoClient.Wrappers;

namespace NuxeoFileManagementApp.Interfaces
{
    public interface INuxeoService
    {
        Task<Documents> GetDocuments(string path); 
    }
}
