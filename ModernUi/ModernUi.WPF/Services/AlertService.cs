using ModernUi.WPF.Alert;
using ModernUi.WPF.Services.Interfaces;

namespace ModernUi.WPF.Services
{
    public class AlertService : IAlertService
    {
        public void PopUp(string title, string message)
        {
            var customDialog = new PopUp(title, message);
            customDialog.ShowDialog();
        }
    }
}
