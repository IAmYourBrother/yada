namespace PSSFx
{
    public class Message
    {
        string topic;
        object payload;
        public Message()
        {
               
        }
        public Message(string  topic, string payload)
        {
            Topic = topic;
            Payload = payload;
        }
        public string Topic
        {
            get
            {
                return topic;
            }

            set
            {
                topic = value;
            }
        }

        public object Payload
        {
            get
            {
                return payload;
            }

            set
            {
                payload = value;
            }
        }
    }
}