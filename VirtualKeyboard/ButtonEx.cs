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
    public partial class ButtonEx : Button
    {
        public ButtonEx()
        {
            InitializeComponent();
            
            this.ForeColor = ColorTranslator.FromHtml("#009900");
            this.Font = new Font("微软雅黑", 12);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.IsSingleKeySpace = true;
        }
        
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        /// <summary>
        /// 按键所占的空间是否只占一个键位
        /// </summary>
        [Browsable(true)]
        public bool IsSingleKeySpace { get; set; }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (IsSingleKeySpace)
                this.Image = Properties.Resources.keyBack3MouseOver;
            this.ForeColor = Color.White;

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (IsSingleKeySpace)
                this.Image = Properties.Resources.keyBack3;
            this.ForeColor = ColorTranslator.FromHtml("#009900");

            base.OnMouseLeave(e);
        }
        
    }
}
