using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiGam.Helpers
{
    interface IDevice
    {
        void RegisterDevice(string connId, string deviceName);

        List<NOTIFICATION> GetNotifications();

        string GetDeviceConnection(int id);



    }
}
