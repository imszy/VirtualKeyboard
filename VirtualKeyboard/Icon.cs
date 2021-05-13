using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Icon : UserControl
    {
        public Icon()
        {
            InitializeComponent();

            this.Width = 64;
            this.Height = 135;
            t.Interval = 30;
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {

        }

        Timer t = new Timer();
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }
    }
}
