using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace _WEBAPP
{
    public class FireBasePush
    {
        private string FIREBASE_URL = "https://fcm.googleapis.com/fcm/send";
        private string KEY_SERVER;
        public FireBasePush(String key_server)
        {
            this.KEY_SERVER = key_server;
        }
        public dynamic SendPush(PushMessage message)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FIREBASE_URL);
            request.Method = "POST";
            request.Headers.Add("Authorization", "key=" + this.KEY_SERVER);
            request.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(message);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                StreamReader read = new StreamReader(response.GetResponseStream());
                String result = read.ReadToEnd();
                read.Close();
                response.Close();
                dynamic stuff = JsonConvert.DeserializeObject(result);
                return stuff;
            }
            else
            {
                throw new Exception("An error has occurred when try to get server response: " + response.StatusCode);
            }
        }
    }
    public class PushMessage
    {
        private string _to;
        private PushMessageData _notification;

        private dynamic _data;
        private dynamic _click_action;
        public dynamic data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string to
        {
            get { return _to; }
            set { _to = value; }
        }
        public PushMessageData notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

        public dynamic click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }

    public class PushMessageData
    {
        private string _title;
        private string _text;
        private string _sound = "default";
        private string _click_action;
        public string sound
        {
            get { return _sound; }
            set { _sound = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }
}
