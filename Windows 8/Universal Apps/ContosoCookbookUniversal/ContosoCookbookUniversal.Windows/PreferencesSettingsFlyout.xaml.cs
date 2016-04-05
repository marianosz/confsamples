using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace ContosoCookbookUniversal
{
    public sealed partial class PreferencesSettingsFlyout : SettingsFlyout
    {
        private const string _key = "UseLocalDataSource";
        
        public PreferencesSettingsFlyout()
        {
            this.InitializeComponent();

            // Initialize the ToggleSwitch control
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(_key))
                DataSwitch.IsOn = !(bool)ApplicationData.Current.LocalSettings.Values[_key];
        }

        private void OnToggleSwitchToggled(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values[_key] = !DataSwitch.IsOn;
        }
    }
}
