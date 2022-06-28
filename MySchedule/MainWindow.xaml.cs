using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MySchedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //界面最大化、最小化、关闭
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            };
            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            btnClose.Click += (s, e) =>
            {
                  this.Close();
            };
            //界面顶部实现鼠标拖动、双击界面变化
            TopZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton==MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            TopZone.MouseDoubleClick += (s, e) =>
              {
                  if (this.WindowState == WindowState.Maximized)
                  {
                      this.WindowState = WindowState.Normal;
                  }
                  else
                  {
                      this.WindowState = WindowState.Maximized;
                  }
              };
        }
    }
}
