using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace YinZiAttack
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Task.Run(() => {
                this.Run();
            });
        }
        private void Run()
        {
            YinZiHttp yinZiHttp = new YinZiHttp();
            yinZiHttp.ResultEvent += YinZiHttp_ResultEvent;
            while (true)
            {
                yinZiHttp.Login();
                Thread.Sleep(1);
            }
        }
        private int count = 0;
        private void YinZiHttp_ResultEvent(HttpResult httpResult)
        {
            Action action = () => {
                this.rtbResult.Text = httpResult.Result;
                this.Text = this.count++.ToString();
            };
            this.BeginInvoke(action);
        }
    }
}
