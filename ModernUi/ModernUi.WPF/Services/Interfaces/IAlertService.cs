using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUi.WPF.Services.Interfaces
{
    public interface IAlertService
    {
        void PopUp(string title, string message);
    }
}
