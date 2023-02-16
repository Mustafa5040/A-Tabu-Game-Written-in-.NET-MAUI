namespace Tabu;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        VersionLabel.Text = "S�r�m " + AppInfo.VersionString;
    }
}