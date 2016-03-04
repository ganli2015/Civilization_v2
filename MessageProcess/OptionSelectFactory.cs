using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using Messages;
using System.Xml;

namespace MessageProcess
{
    public class OptionSelectFactory
    {
        static Dictionary<SelectEvent,OptionSelect> _messageData;

        public static void Initialize()
        {
            _messageData = new Dictionary<SelectEvent, OptionSelect>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"OptionSelectEvents.xml");

            XmlNodeList events = doc.GetElementsByTagName("Event");
            foreach (XmlNode node in events)
            {
                OptionSelect select = ParseNode(node);
                SelectEvent myEvent=(SelectEvent)(Convert.ToInt32(node.Attributes["id"].InnerText));
                _messageData[myEvent]=select;
            }

            CheckMessageData();
        }

        public static GameMessage Create(SelectEvent myEvent)
        {
            return _messageData[myEvent];
        }

        private static OptionSelect ParseNode(XmlNode node)
        {
            OptionSelect select = new OptionSelect();
            OptionSelectData data = new OptionSelectData();

            data.Description = node.ChildNodes[0].InnerText;
            data.MyEvent = (SelectEvent)(Convert.ToInt32(node.Attributes["id"].InnerText));

            data.Options = ParseOption(node.ChildNodes[1]);
            select.SetData(data);

            return select;
        }

        private static List<string> ParseOption(XmlNode optionNode)
        {
            List<string> res= new List<string>();
            foreach (XmlNode opNode in optionNode.ChildNodes)
            {
                res.Add(opNode.InnerText);
            }

            return res;
        }

        private static void CheckMessageData()
        {
            int count = Enum.GetNames(typeof(SelectEvent)).Length;
            for (int i = 0; i < count;++i )
            {
                if(!_messageData.ContainsKey((SelectEvent)i))
                {
                    throw new ApplicationException("导入数据错误");
                }
            }
        }
    }
}
