using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsProject
{
    public delegate void CloseEventHandler();
    public partial class StopClock: UserControl
    {
        int min, sec;
        string strSec, strMin;
        public event CloseEventHandler CloseClick;
        public StopClock()
        {
            InitializeComponent();
        }

        public void Start()
        {
            timer1.Start();
        }
        public void Stop()
        {
            timer1.Stop();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec < 59)
            {
                sec += 1;
            }
            else
            {
                sec = 0;
                if (min < 59)
                {
                    min += 1;
                }
                else
                {
                    min = 0;
                    timer1.Stop();
                }
            }
            if(sec<10)
            {
                strSec = 0 + sec.ToString();
            }
            else
            {
                strSec = sec.ToString();
            }
            if(min<10)
            {
                strMin = 0 + min.ToString();
            }
            else
            {
                strMin = min.ToString();
            }
            mtbTimer.Text = strMin + strSec;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseClick();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            mtbTimer.Text = "0000";
            timer1.Stop();
            min = sec = 0;
        }
        public string ElapsedTime
        {
            get { return mtbTimer.ToString(); }
        }
    }
}
