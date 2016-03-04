using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public enum Message
    {
        TextDisplay,
        OptionSelect     
    }

    public abstract class GameMessage
    {
        object _data;

        public void SetData(object data)
        {
            _data = data;
        }

        public object GetData()
        {
            return _data;
        }

        public abstract Message GetMessageType();   
    }

    public interface iMessageFactory
    {
        GameMessage Create(Message type);
    }
}
