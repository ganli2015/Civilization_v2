using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;

namespace Messages
{
    public class TextDisplay:GameMessage
    {
        override public Message GetMessageType()
        {
            return Message.TextDisplay;
        }

        static public TextDisplay Create(string text)
        {
            TextDisplay textDisplay = new TextDisplay();
            textDisplay.SetData(text);
            return textDisplay;
        }
    }
}
