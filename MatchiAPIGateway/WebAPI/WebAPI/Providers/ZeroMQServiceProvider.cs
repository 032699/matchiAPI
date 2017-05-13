using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroMQ;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace MatchiWebAPI.Providers
{
    public static class ZeroMQServiceProvider
    {
        public static async Task<string> LookupServiceMessenger(string message, string action)
        {
            string connection = ConfigurationManager.AppSettings.Get("ZeroMQHostLookupService");
            var mesage = await Task.FromResult<string>(DoLookupServiceTask(message, action, connection));

            return message;
        }

        public static async Task<string> UserServiceMessenger(string message, string action)
        {
            string connection = ConfigurationManager.AppSettings.Get("ZeroMQHostUserService");
            var mesage = await Task.FromResult<string>(DoLookupUserTask(message, action, connection));

            return message;
        }

        public static async Task<string> PostServiceMessenger(string message, string action)
        {
            string connection = ConfigurationManager.AppSettings.Get("ZeroMQHostPostService");
            var mesage = await Task.FromResult<string>(DoLookupPostTask(message, action, connection));

            return message;
        }
        public static string DoLookupPostTask(string message, string action, string connection)
        {
            string response = "";
            using (var context = new ZContext())
            using (var requester = new ZSocket(context, ZSocketType.REQ))
            {

                requester.Connect(connection);


                ZMessage zM = new ZMessage();
                ZFrame zFrame1 = new ZFrame(message);

                ZFrame zFrame2 = new ZFrame(action);

                zM.Append(zFrame1);
                zM.Append(zFrame2);
                requester.Send(zM);

                using (ZFrame reply = requester.ReceiveFrame())
                {
                    response = reply.ReadString();
                }
            }
            return response;
        }
        public static string DoLookupUserTask(string message, string action, string connection)
        {
            string response = "";
            using (var context = new ZContext())
            using (var requester = new ZSocket(context, ZSocketType.REQ))
            {

                requester.Connect(connection);


                ZMessage zM = new ZMessage();
                ZFrame zFrame1 = new ZFrame(message);

                ZFrame zFrame2 = new ZFrame(action);

                zM.Append(zFrame1);
                zM.Append(zFrame2);
                requester.Send(zM);

                using (ZFrame reply = requester.ReceiveFrame())
                {
                    response = reply.ReadString();
                }
            }
            return response;
        }
        public static  string DoLookupServiceTask(string message, string action, string connection )
        {
            string response = "";
            using (var context = new ZContext())
            using (var requester = new ZSocket(context, ZSocketType.REQ))
            {
             
                requester.Connect(connection);


                ZMessage zM = new ZMessage();
                ZFrame zFrame1 = new ZFrame(message);

                ZFrame zFrame2 = new ZFrame(action);

                zM.Append(zFrame1);
                zM.Append(zFrame2);
                requester.Send(zM);

                using (ZFrame reply = requester.ReceiveFrame())
                {
                    response = reply.ReadString();
                }
            }
            return  response;
        }
    }
}