﻿using Microsoft.AspNet.SignalR;
using SignalRExtendLib;
using SignalRExtendLib.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [SessionEnable]
    public class MyServiceHub : Hub
    {
        public void HelloWorld()
        {
            Console.WriteLine("ID为" + base.Context.ConnectionId + "的用户进入聊天室");
            Clients.All.pushMessage("管理员", "欢迎ID为" + base.Context.ConnectionId + "的用户进入聊天室");
        }

        public void SendMessage(string msg)
        {
            Clients.All.pushMessage(Context.ConnectionId, msg);
        }

        public void SendObject(dynamic obj)
        {
            Console.WriteLine("客户端发送了一个对象,类型为"+obj.GetType().Name.ToString());
            Clients.Caller.pushMessage("管理员", "您向我发送了一个类型为"+obj.GetType().Name.ToString()+"的对象");
        }

        public void GetSessionId()
        {
            Clients.Caller.pushMessage("SessionID",Context.RequestCookies["ASP.NET_Signal_SessionKey"].Value);
        }
    }
}