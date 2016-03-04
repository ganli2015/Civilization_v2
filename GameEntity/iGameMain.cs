using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public struct GameMainArg
    {
        public long Round;
    }

    public interface iGameMain
    {
        void SetGameDisplay(GameDisplay display);
        void Run(ref GameElements gameEntity);
        void SetMessageTransporter(MessageTransporter transporter);
    }
}
