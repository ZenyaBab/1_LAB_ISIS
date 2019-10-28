using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_ISIS
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            Child newForm = new Child();
            newForm.MdiParent = this;
            newForm.Show();

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] form = MdiChildren;
            foreach (Form f in form)
            f.Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalTileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mozaikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void минимизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] form = MdiChildren;
            foreach (Form f in form)
                f.WindowState = FormWindowState.Minimized;
        }

        private void упорядочиваниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            Form[] form = MdiChildren;
            foreach (Form f in form)
            {
                f.StartPosition = FormStartPosition.Manual;
                f.Location = new Point(i);
                i += 100;
            }
        }
    }
}
