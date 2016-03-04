using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public interface MessageResponsor
    {
        void Response(GameMessage message);
    }
}
