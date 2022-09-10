using NuxeoFileManagementApp.Helpers;
using NuxeoFileManagementApp.Interfaces;
using NuxeoFileManagementApp.ViewModel;

namespace NuxeoFileManagementApp.View;

public partial class FolderPage : ContentPage
{
	public FolderPage()
	{
		InitializeComponent();
		BindingContext = new FolderPageViewModel(ServiceHelper.GetService<INuxeoService>());
	}
}