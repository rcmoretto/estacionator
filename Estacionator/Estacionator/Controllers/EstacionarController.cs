using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Estacionator.Views
{
    public class EstacionarController : Controller
    {
        private string MQTT_BROKER_ADDRESS = "iot.eclipse.org";
        private MqttClient client = new MqttClient("iot.eclipse.org");
        // GET: Estacionar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Visualizacao()
        {
            return View();
        }
        [HttpPost]
        public void EscreveLampada(string value)
        {
            // create client instance 
            //MqttClient client = new MqttClient(MQTT_BROKER_ADDRESS);

            HttpCookie mycookie = HttpContext.Request.Cookies["fila"];

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            //string strValue = value == 10 ? "D" : "L";

            var ret3 = client.Publish("29asoMqttLampOutput", Encoding.UTF8.GetBytes(value), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }
    }
}