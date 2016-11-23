using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml;

namespace CustomTriggers.Triggers
{
    public class DeviceFamilyTrigger : StateTriggerBase
    {
        public string DeviceFamily
        {
            get { return string.Empty; }
            set
            {
                var family = ResourceContext.GetForCurrentView().QualifierValues["DeviceFamily"];
                SetActive(family.Equals(value));
            }
        }
    }

}
