using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEntity
{
    public class MessageTransporter
    {
        MessageResponsor _responsor;

        public void SetResponsor(MessageResponsor responsor)
        {
            _responsor=responsor;
        }

        public void Notify(GameMessage message)
        {
            _responsor.Response(message);
        }
    }
}
