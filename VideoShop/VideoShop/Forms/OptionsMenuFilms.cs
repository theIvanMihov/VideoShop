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

using VideoShop.BufferClasses;

namespace VideoShop
{
    public partial class OptionsMenuFilms : Form
    {
        private string filmData;
        private bool IsNew;
        private int chosenFilmID;

        private List<Object> genres = new List<Object>();
        private Point mouseDown = Point.Empty;
        public OptionsMenuFilms(string filmData, bool IsNew, List<Object> genres)
        {
            this.filmData = filmData;
            this.IsNew = IsNew;
            this.genres = genres;
            InitializeComponent();
        }

        private void OptionsMenuFilms_Load(object sender, EventArgs e)
        {
            
            BackColor = Color.FromArgb(161, 123, 89);
            //Border.BackColor = Color.FromArgb(220, 93, 1);
            Border.BackColor = Color.Black;

            foreach (Genres i in genres)
            {
                genreBox.Items.Add(i.getGenreName());
            }

            if (!IsNew)
            {
                string[] array = filmData.Split(',');

                producerBox.Text = array[0];
                leadBox.Text = array[1];
                nameBox.Text = array[2];
                genreBox.Text = array[3];
                yearBox.Text = array[4];
                chosenFilmID = ViewControl.Instance.getID(array[2], "Films");
            }
            
            
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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

        private void submitChanges_Click(object sender, EventArgs e)
        {
            
            if (!IsNew)
            {
                Films f = new Films();
                f.setID(chosenFilmID);
                f.setProd(producerBox.Text);
                f.setLead(leadBox.Text);
                f.setName(nameBox.Text);
                f.setStringGenre(genreBox.SelectedItem.ToString());
                f.setYear(Int32.Parse(yearBox.Text));
                ViewControl.Instance.chandeData(f as Object, "Films");
            }
            else
            {
                ViewControl.Instance.setData(getInfo(), "Films");
                this.Close();
            }
        }
        private string getInfo()
        {
            return producerBox.Text + "," + leadBox.Text + "," + nameBox.Text + "," + genreBox.SelectedItem.ToString() + "," + yearBox.Text;
        }
    }
}
