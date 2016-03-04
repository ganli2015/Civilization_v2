using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;

namespace Messages
{

    public class OptionSelect:GameMessage
    {
        override public Message GetMessageType()
        {
            return GameEntity.Message.OptionSelect;
        }
    }
}
