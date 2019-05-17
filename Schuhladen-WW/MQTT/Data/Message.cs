using System;
using System.Collections.Generic;
using System.Text;

namespace MQTTClient.Data
{
    public class Message
    {
        private string str_topicname;
        private String _message;

        public string str_TopicName
        {
            get { return str_topicname; }
            set
            {
                if (str_topicname != value)
                {
                    str_topicname = value;
                }
            }
        }

        public string _Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                }
            }
        }

    }
}
