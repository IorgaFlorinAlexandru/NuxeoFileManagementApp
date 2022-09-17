using NuxeoClient;
using NuxeoClient.Wrappers;
using NuxeoFileManagementApp.Interfaces;
using System.Collections;
using System.Net;

namespace NuxeoFileManagementApp.Services
{
    public class NuxeoService : INuxeoService
    {
        private readonly NuxeoClient.Client client = new NuxeoClient.Client("http://10.1.58.31:8080/nuxeo/", new NuxeoClient.Authorization("Administrator", "Administrator"));

        public async Task<Documents> GetDocuments(string path)
        {
            try
            {
                Documents allDocuments = (Documents) await client.Operation("Document.GetChildren")
                                           .SetInput("doc:" + path)
                                           .Execute();

                //Gets all documents including the ones that have been removed
                //So we filter the trashed documents
                Documents validDocuments = new Documents();
                foreach (var document in allDocuments)
                {
                    if (!document.IsTrashed)
                        validDocuments.Add(document);
                }

                return validDocuments;
            }
            catch(NuxeoClient.ClientErrorException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new Documents();
        }
    }
}
