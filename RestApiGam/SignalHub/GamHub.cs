using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using RestApiGam.Functions;
using RestApiGam.Helpers;

namespace RestApiGam.SignalHub
{
    public class GamHub: Hub<IClientMethods> //la herencia se usa para habilitar intelli y que te aparezcan los metodos
    {
        IDevice _dev;

        public GamHub() : this(new CDevice()) { }

        internal GamHub(IDevice dev)
        {
            _dev = dev;
        }

        //metodos override por defecto SignalR aqui se registra y actualiza dispositivos en la tabla
        #region Default Override Methods 

        public override Task OnConnected()
        {
            var deviceName =  Context.QueryString["device_name"];

            _dev.RegisterDevice(Context.ConnectionId, deviceName);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            var deviceName =  Context.QueryString["device_name"];

            _dev.RegisterDevice(Context.ConnectionId, deviceName);

            return base.OnReconnected();
        }

        #endregion

        //metodos enviar notificaciones
        #region Notification 

        public void SendNotifications()
        {
            var notifications = _dev.GetNotifications(); //recoge la lista de notificaciones pendientes

            foreach(var item in notifications)
            {
                Clients.Client(_dev.GetDeviceConnection(item.ID_DEVICE)).NewMessage();
            }
        }

        #endregion
    }
}