using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public interface iMessageProcessor
    {
        void SetMessageDisplayer(MessageDisplayer val);
        void SetOptionSelectDisplayer(OptionSelectDisplayer val);
        void Process(GameMessage message);
    }
}
