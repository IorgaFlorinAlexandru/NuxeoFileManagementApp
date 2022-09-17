using NuxeoFileManagementApp.ViewModel;

namespace NuxeoFileManagementApp.View;

public partial class FolderPage : ContentPage
{
	public FolderPage()
	{
		InitializeComponent();
		BindingContext = new FolderPageViewModel();
	}
}