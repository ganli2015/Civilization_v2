using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;

namespace MessageProcess
{
    public class MessageProcessor:iMessageProcessor
    {
        MessageDisplayer _messageDisplayer;
        OptionSelectDisplayer _optionSelectDisplayer;

        public void SetMessageDisplayer(MessageDisplayer val)
        {
            _messageDisplayer = val;
        }
        public void SetOptionSelectDisplayer(OptionSelectDisplayer val)
        {
            _optionSelectDisplayer = val;
        }

        public void Process(GameMessage message)
        {
            switch (message.GetMessageType())
            {
                case Message.TextDisplay:
                    {
                        string messageStr = message.GetData() as string;
                        _messageDisplayer.Display(messageStr);
                        break;
                    }
                case Message.OptionSelect:
                    {
                        OptionSelectData data = (OptionSelectData)message.GetData();
                        _optionSelectDisplayer.Display(data);

                        break;
                    }
            }
        }
    }
}
