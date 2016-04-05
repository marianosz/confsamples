namespace BingVideoUWPApp
{
  using BingVideoLibrary;
  using Windows.ApplicationModel.Activation;
  using Windows.UI.Xaml;

  sealed partial class App : Application
  {
    public App()
    {
      this.InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
      MainPage mainPage = Window.Current.Content as MainPage;

      if (mainPage == null)
      {
        if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(
          "Windows.Phone.UI.Input.HardwareButtons"))
        {
          Windows.Phone.UI.Input.HardwareButtons.BackPressed += (sender, args) =>
          {
            if (NavigationService.Current.CanGoBack)
            {
              NavigationService.Current.GoBackCommand.Execute(null);
              args.Handled = true;
            }
          };
        }

        // Create a Frame to act as the navigation context and navigate to the first page
        mainPage = new MainPage();

        // Place the frame in the current Window
        Window.Current.Content = mainPage;

        NavigationService.Current.NavigateToPage("videos",
          BingVideoCategoryType.Music);

      }
      // Ensure the current window is active
      Window.Current.Activate();
    }
  }
}
