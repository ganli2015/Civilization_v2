using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using GameEntity;

namespace CivilizationWPF
{
    /// <summary>
    /// MessageDisplayBox.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class MessageDisplayBox : UserControl,MessageDisplayer
    {

        public MessageDisplayBox()
        {
            InitializeComponent();

        }

        public void Display(string message)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                textBox.Text = message;
            });
        }

        public void DisplayText(string message)
        {
            
        }
    }
}
