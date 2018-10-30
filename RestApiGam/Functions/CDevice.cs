using RestApiGam.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApiGam.Functions
{
    public class CDevice : IDevice
    {
        public void RegisterDevice(string connId, string deviceName )
        {
            using(var ent = new GDROIDEntities())
            {
                var device = ent.DEVICE.Where(x => x.DEVICE_NAME == deviceName).FirstOrDefault();

                if (device == null)
                {
                    ent.DEVICE.Add(new DEVICE { CONNECTION_ID = connId, DEVICE_NAME = deviceName}); //registra el vhi si es la priemra vez conectado
                }
                else
                {
                    device.CONNECTION_ID = connId;
                    device.DEVICE_NAME = deviceName;                  
                }

                ent.SaveChanges();
            }
        }

        public List<NOTIFICATION> GetNotifications()
        {
            List<NOTIFICATION> ListOfNotifications = new List<NOTIFICATION>();

            using (var ent = new GDROIDEntities())
            {
                ListOfNotifications = ent.NOTIFICATION.ToList();

            }

            return ListOfNotifications;
        }

        public string GetDeviceConnection(int id)
        {
            string deviceConn = string.Empty;

            using (var ent = new GDROIDEntities())
            {
                deviceConn = ent.DEVICE.Where(x=> x.ID == id).Select(c=> c.CONNECTION_ID).FirstOrDefault();
            }

            return deviceConn;
        }
    }
}