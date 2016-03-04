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
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using GameEntity;

namespace CivilizationWPF.EventForms
{
    /// <summary>
    /// OptionSelectForm.xaml 的交互逻辑
    /// </summary>
    public partial class OptionSelectForm : Window,OptionSelectDisplayer
    {
        ManualResetEvent _manualReset;
        OptionSelectData _data;

        public OptionSelectForm(ManualResetEvent val,Window parent)
        {
            InitializeComponent();
            _manualReset = val;
            Owner = parent;
        }

        public void Display(OptionSelectData data)
        {
            _data = data;

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                textBlock_Desc.Text = data.Description;

                stackPanel.Children.Clear();
                data.Options.ForEach(str =>
                {
                    RadioButton radio = new RadioButton();
                    radio.Content = str;
                    radio.Height = stackPanel.Height/data.Options.Count;
                    stackPanel.Children.Add(radio);
                });

                this.ShowDialog();
            });

            _manualReset.Reset();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            string selectedText = GetSelectedButtonContent();
            if (selectedText == "")
            {
                MessageBox.Show("请选择一个选项。");
            }

            _data.Selected = selectedText;
            _manualReset.Set();
            this.Close();
        }

        private string GetSelectedButtonContent()
        {
            foreach (RadioButton button in stackPanel.Children)
            {
                if (button.IsChecked == true)
                {
                    return button.Content as string;
                }
            }

            return "";
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
