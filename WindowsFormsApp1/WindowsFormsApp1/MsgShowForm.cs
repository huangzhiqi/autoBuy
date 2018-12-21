using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBuy
{
    public partial class MsgShowForm : Form
    {
        public MsgShowForm()
        {
            InitializeComponent();
        }
        public MsgShowForm(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
            System.Media.SystemSounds.Beep.Play();
            NetLog.WriteTextLog("通知", msg, DateTime.Now);
        }
    }
}
