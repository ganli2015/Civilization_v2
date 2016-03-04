using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GameEntity;
using System.Windows.Forms;
using MessageProcess;
using System.Windows.Threading;
using System.Threading;
using Message = GameEntity.Message;
using Messages;

namespace Evolution
{
    public class GameMain:iGameMain
    {
        GameDisplay _gameDisplay;
        MessageTransporter _messageTransporter;
        long  _round;

        public GameMain()
        {
            _round = 0;
            OptionSelectFactory.Initialize();
        }

        public void SetGameDisplay(GameDisplay gameDisplay)
        {
            _gameDisplay = gameDisplay;
        }

        public void SetMessageTransporter(MessageTransporter messageTransporter)
        {
            _messageTransporter = messageTransporter;
        }

        public void Run(ref GameElements gameEntity)
        {
            GameMainArg gameMainArg = new GameMainArg();
            gameMainArg.Round = _round;

            MessageSet playerMessages=PlayerEvolution.Evolve(gameEntity,gameMainArg);
            MessageSet otherMessages = OtherEvolution.Evolve(gameEntity, gameMainArg);
            MessageSet gameMainMessages = GenerateGameMainMessages();

            MessageSet allMessages = IntegrageMessages(playerMessages, gameMainMessages);
            MessageSet finalMessages = MessageFilter.FilterMessage(allMessages);

            Notify(finalMessages);
            MessageSet textMessages=Response(finalMessages, gameEntity);
            Notify(textMessages);

            _round++;
        }

        private void Notify(MessageSet finalMessages)
        {
            foreach (GameMessage m in finalMessages)
            {
                _messageTransporter.Notify(m);
            }
        }

        private MessageSet Response(MessageSet finalMessages, GameElements gameEntity)
        {
            MessageSet res = new MessageSet();

            GameMainArg arg = new GameMainArg();
            arg.Round = _round;

            OptionSelect select;
            if (ContainOptionSelect(finalMessages, out select))
            {
                MessageSet set=OptionSelectResponse.Evolve(gameEntity, select.GetData() as OptionSelectData, arg);
                res.Add(set);
            }

            return res;
        }

        private MessageSet GenerateGameMainMessages()
        {
            MessageSet set = new MessageSet();


            return set;
        }

        private MessageSet IntegrageMessages(MessageSet m1, MessageSet m2)
        {
            MessageSet res = new MessageSet();
            res.Add(m1);
            res.Add(m2);
            return res;
        }

        /// <summary>
        /// Whether contain and contain only one the option select message
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="optionMessage"></param>
        /// <returns></returns>
        private bool ContainOptionSelect(MessageSet messages, out OptionSelect optionMessage)
        {
            var candidates = messages.GetOptionSelectMessage();
            if (candidates.Count() == 1)
            {
                optionMessage = candidates.ElementAt(0) as OptionSelect;
                if (optionMessage != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                optionMessage = null;
                return false;
            }
        }

        
    }

    
}
