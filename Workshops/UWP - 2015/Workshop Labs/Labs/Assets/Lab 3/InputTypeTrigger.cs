using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomTriggers.Mvvm;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace CustomTriggers.Triggers
{
    public class InputTypeTrigger : StateTriggerBase
    {
        private PointerDeviceType _triggerPointerType;
        public PointerDeviceType PointerType
        {
            get { return _triggerPointerType; }
            set
            {
                _triggerPointerType = value;
                WeakEvent.Subscribe<TypedEventHandler<CoreWindow, PointerEventArgs>>
                    (Window.Current.CoreWindow, nameof(Window.Current.CoreWindow.PointerPressed), CoreWindow_PointerPressed);
                UpdateTrigger(default(PointerDeviceType));
            }
        }

        private void CoreWindow_PointerPressed(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
        {
            UpdateTrigger(args.CurrentPoint.PointerDevice.PointerDeviceType);
        }

        public void UpdateTrigger(PointerDeviceType type)
        {
            SetActive(_triggerPointerType.Equals(type));
        }
    }
}
