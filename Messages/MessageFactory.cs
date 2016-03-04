using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;

namespace Messages
{
    public class MessageFactory:iMessageFactory
    {
        public GameMessage Create(Message type)
        {
            switch (type)
            {
                case Message.TextDisplay:
                    {
                        return new TextDisplay();
                    }
                case Message.OptionSelect:
                    {
                        return new OptionSelect();
                    }
                default: return null;
            }
        }
    }
}
