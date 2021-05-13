using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 设置为浮动窗体，不获取焦点
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;
        private const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
                cp.Parent = IntPtr.Zero; // Keep this line only if you used UserControl
                cp.X = this.Location.X;
                cp.Y = this.Location.Y;
                return cp;

                //return base.CreateParams;
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = panel1.Width;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = ColorTranslator.FromHtml("#333333");
            //不能用environment，否则当其他exe调起此exe时，CurrentDirectory用的是发起调用的程序的目录
            //string path = Environment.CurrentDirectory + @"\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe";
            string path = Application.ExecutablePath;
            if (File.Exists(path))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);
                if (config.AppSettings.Settings["startX"] == null)
                {
                    config.AppSettings.Settings.Add("startX", "100");//起始点X
                    config.Save();
                }
                if (config.AppSettings.Settings["startY"] == null)
                {
                    config.AppSettings.Settings.Add("startY", "100");//起始点Y
                    config.Save();
                }
                this.Location = new Point(int.Parse(config.AppSettings.Settings["startX"].Value), int.Parse(config.AppSettings.Settings["startY"].Value));
            }
            else
            {
                MessageBox.Show("配置文件不存在\r\n"+path);
            }
        }

#region 数字键盘
        private void btn1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{1}");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{2}");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{3}");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{4}");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{5}");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{6}");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{7}");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{8}");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{9}");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{0}");
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{-}");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{.}");
        }

        bool isDraging = false;
        Point dragStart = new Point(0, 0);
        private void btnDrag_MouseDown(object sender, MouseEventArgs e)
        {
            isDraging = true;
            dragStart = PointToScreen(e.Location);
        }

        private void btnDrag_MouseUp(object sender, MouseEventArgs e)
        {
            isDraging = false;
        }

        private void btnDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraging)
            {
                Point pointNow = PointToScreen(e.Location);
                Point loc = this.Location;
                loc.X += (pointNow.X - dragStart.X);
                loc.Y += (pointNow.Y - dragStart.Y);
                this.Location = loc;
                dragStart = pointNow;
            }
        }
        
        private void btnEnter_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{Enter}");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
        }

        private void btnCharKey_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            this.Width = panel2.Width;
            panel2.Location = new Point(0, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.keyBack3MouseOver_x2;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.keyBack3_x2;
        }
        #endregion

#region 字母键盘
        private void btnQ_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower ? "{q}" : "{Q}");
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{w}":"{W}");
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{e}":"{E}");
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{r}":"{R}");
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{t}":"{T}");
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{y}":"{Y}");
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{u}":"{U}");
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{i}":"{I}");
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{o}":"{O}");
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{p}":"{P}");
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{a}":"{A}");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{s}":"{S}");
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{d}":"{D}");
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{f}":"{F}");
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{g}":"{G}");
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{h}":"{H}");
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{j}":"{J}");
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{k}":"{K}");
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{l}":"{L}");
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{z}":"{Z}");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{x}":"{X}");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{c}":"{C}");
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{v}":"{V}");
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{b}":"{B}");
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{n}":"{N}");
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            SendKeys.Send(lower?"{m}":"{M}");
        }

        private void btnDot2_Click(object sender, EventArgs e)
        {
            btnDot_Click(sender, e);
        }

        bool lower = false;
        private void btnLower_Click(object sender, EventArgs e)
        {
            if (!lower)
            {
                btnLower.Text = "ABC";
                lower = true;

                btnQ.Text = "q";
                btnW.Text = "w";
                btnE.Text = "e";
                btnR.Text = "r";
                btnT.Text = "t";
                btnY.Text = "y";
                btnU.Text = "u";
                btnI.Text = "i";
                btnO.Text = "o";
                btnP.Text = "p";
                btnA.Text = "a";
                btnS.Text = "s";
                btnD.Text = "d";
                btnF.Text = "f";
                btnG.Text = "g";
                btnH.Text = "h";
                btnJ.Text = "j";
                btnK.Text = "k";
                btnL.Text = "l";
                btnZ.Text = "z";
                btnX.Text = "x";
                btnC.Text = "c";
                btnV.Text = "v";
                btnB.Text = "b";
                btnN.Text = "n";
                btnM.Text = "m";
            }
            else
            {
                btnLower.Text = "abc";
                lower = false;

                btnQ.Text = "Q";
                btnW.Text = "W";
                btnE.Text = "E";
                btnR.Text = "R";
                btnT.Text = "T";
                btnY.Text = "Y";
                btnU.Text = "U";
                btnI.Text = "I";
                btnO.Text = "O";
                btnP.Text = "P";
                btnA.Text = "A";
                btnS.Text = "S";
                btnD.Text = "D";
                btnF.Text = "F";
                btnG.Text = "G";
                btnH.Text = "H";
                btnJ.Text = "J";
                btnK.Text = "K";
                btnL.Text = "L";
                btnZ.Text = "Z";
                btnX.Text = "X";
                btnC.Text = "C";
                btnV.Text = "V";
                btnB.Text = "B";
                btnN.Text = "N";
                btnM.Text = "M";
            }
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            this.Width = panel1.Width;
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            SendKeys.Send("+");//代表shift，若要发送+号，则为SendKeys.Send("{+}");
        }
        
        private void btnDrag2_MouseDown(object sender, MouseEventArgs e)
        {
            btnDrag_MouseDown(sender, e);
        }

        private void btnDrag2_MouseUp(object sender, MouseEventArgs e)
        {
            btnDrag_MouseUp(sender, e);
        }

        private void btnDrag2_MouseMove(object sender, MouseEventArgs e)
        {
            btnDrag_MouseMove(sender, e);
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void btnSpace_MouseEnter(object sender, EventArgs e)
        {
            btnSpace.Image = Properties.Resources.keyBack3MouseOver_x4_h;
        }

        private void btnSpace_MouseLeave(object sender, EventArgs e)
        {
            btnSpace.Image = Properties.Resources.keyBack3_x4_h;
        }

        private void btnDash2_Click(object sender, EventArgs e)
        {
            btnDash_Click(sender, e);
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            btnDel_Click(sender, e);
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void btnEnter2_Click(object sender, EventArgs e)
        {
            btnEnter_Click(sender, e);
        }

        private void btnEnter2_MouseEnter(object sender, EventArgs e)
        {
            btnEnter2.Image = Properties.Resources.keyBack3MouseOver_x2;
        }

        private void btnEnter2_MouseLeave(object sender, EventArgs e)
        {
            btnEnter2.Image = Properties.Resources.keyBack3_x2;
        }

        #endregion

    }
}
