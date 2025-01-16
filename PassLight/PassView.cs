using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PassLight
{
    public partial class PassView : Form
    {
        
        public PassView()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void PassView_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#121212");
            name_textBox.BackColor = ColorTranslator.FromHtml("#202020");
            name_textBox.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            Password_textBox.BackColor = ColorTranslator.FromHtml("#202020");
            Password_textBox.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            Copy_button.Dock = DockStyle.Bottom;
            Copy_button.BackColor = ColorTranslator.FromHtml("#BB86FC");
            Copy_button.ForeColor = Color.White;
            Copy_button.FlatStyle = FlatStyle.Flat;

            Close_button.Dock = DockStyle.Bottom;
            Close_button.BackColor = ColorTranslator.FromHtml("#BB86FC");
            Close_button.ForeColor = Color.White;
            Close_button.FlatStyle = FlatStyle.Flat;


        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void name_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
