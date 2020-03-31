using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoShop.Classes;

namespace VideoShop.Forms
{
    public partial class FilterForm : Form
    {
        private Point mouseDown = Point.Empty;

        public FilterForm()
        {
            InitializeComponent();
        }
        
        private void FilterForm_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(161, 123, 89); 
            Border.BackColor = Color.Black;

            foreach (Genres g in ViewControl.Instance.getGenresArray())
            {
                genreBox.Items.Add(g.getGenreName());
            }
        }

        private void Border_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = new Point(e.X, e.Y);
            }
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown.IsEmpty)
                return;
            this.Location = new Point(this.Location.X + (e.X - mouseDown.X), this.Location.Y + (e.Y - mouseDown.Y));
        }

        private void Border_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = Point.Empty;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Films f = new Films();
            f.setName(nameBox.Text);
            f.setLead(leadName.Text);
            
            f.setStringGenre(genreBox.Text);

            if(yearBox.Text != "")
            {
                f.setYear(Int32.Parse(yearBox.Text));
            }
            ViewControl.Instance.setFilterItem(f);

            Visible = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
