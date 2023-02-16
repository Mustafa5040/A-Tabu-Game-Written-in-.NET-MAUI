namespace Tabu;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        VersionLabel.Text = "Sürüm " + AppInfo.VersionString;
    }
}