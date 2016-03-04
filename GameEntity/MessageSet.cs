using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public class MessageSet : System.Collections.IEnumerable
    {
        List<GameMessage> _messages
        {
            get;
            set;
        }

        public MessageSet()
        {
            _messages = new List<GameMessage>();
        }

        public void Add(GameMessage val)
        {
            _messages.Add(val);
        }

        public void Add(MessageSet set)
        {
            _messages.AddRange(set._messages);
        }

        public bool Empty()
        {
            if (_messages.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            for (int index = 0; index < _messages.Count; index++)
            {
                yield return _messages[index];
            }
        }

        public List<GameMessage> GetOptionSelectMessage()
        {
            var res = from m in _messages where m.GetMessageType() == Message.OptionSelect select m;

            return new List<GameMessage>(res);
        }
    }
}
