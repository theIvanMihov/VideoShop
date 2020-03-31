using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoShop.BufferClasses;
using VideoShop.Classes;
using VideoShop.Forms;

namespace VideoShop
{
    public partial class MainMenu : Form
    {
        private GenresBuffer genres = new GenresBuffer();

        private Point mouseDown = Point.Empty;

        private Dictionary<RadioButton, TabPage> userRadioPanelsPairs = new Dictionary<RadioButton, TabPage>();
        private Dictionary<RadioButton, TabPage> adminRadioPanelsPairs = new Dictionary<RadioButton, TabPage>();

        private FilterForm filter = new FilterForm();
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Функцията обработва какво се случва при зареждането на главния прозорец
        /// </summary>
        private void MainMenu_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(220, 93, 1);
            topPanel.BackColor = Color.FromArgb(134, 36, 0);
            adminTabView.Visible = false;
            userTabView.Visible = false;
            FillRadioButtons();

            navigationControl.ItemSize = new Size(0, 1);
            navigationControl.SizeMode = TabSizeMode.Fixed;



            adminTab.BackColor = Color.FromArgb(255, 192, 57);
            userTab.BackColor = Color.FromArgb(255, 192, 57);

            if (GlobalVariables.Instance.getAdminLogged())
            {
                navigationControl.SelectedTab = adminTab;
                adminTabView.Visible = true;
                adminTabView.ItemSize = new Size(0, 1);
                adminTabView.SizeMode = TabSizeMode.Fixed;


                addOfficeRadio.Checked = true;

                adminLoad();
            }
            else
            {
                navigationControl.SelectedTab = userTab;
                userTabView.Visible = true;
                userTabView.ItemSize = new Size(0, 1);
                userTabView.SizeMode = TabSizeMode.Fixed;



                showBegginingRadio.Checked = true;

                userLoad();
            }

        }

        private void minButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        /// <summary>
        /// Тук взимаме всеки един радио бутон слагаме го в списък и променям начина на визуализация на самия радио бутон,
        /// след това взимаме съответните радио бутони и ги слагаме във мап със съотният панел за визуализация
        /// </summary>
        private void FillRadioButtons()
        {
            List<RadioButton> options = new List<RadioButton>();
            List<RadioButton> adminOptions = new List<RadioButton>();

            options.Add(showBegginingRadio);
            options.Add(showCatRadio);
            options.Add(showLibRadio);
            options.Add(showSeriesRadio);
            options.Add(showOptionRadio);
            options.Add(films);
            options.Add(series);

            foreach (RadioButton i in options)
            {
                i.Appearance = Appearance.Button;

            }
            userRadioPanelsPairs.Add(showBegginingRadio, beginingView);
            userRadioPanelsPairs.Add(showCatRadio, categoryView);
            userRadioPanelsPairs.Add(showLibRadio, libraryView);
            userRadioPanelsPairs.Add(showSeriesRadio, userSeriesView);
            userRadioPanelsPairs.Add(showOptionRadio, optionsView);


            adminOptions.Add(addOfficeRadio);
            adminOptions.Add(addFilmRadio);
            adminOptions.Add(addSeriesRadio);
            adminOptions.Add(addGenresRadio);
            adminOptions.Add(usersRadioButton);

            foreach (RadioButton i in adminOptions)
            {
                i.Appearance = Appearance.Button;
            }
            adminRadioPanelsPairs.Add(addOfficeRadio, officesView);
            adminRadioPanelsPairs.Add(addFilmRadio, filmsView);
            adminRadioPanelsPairs.Add(addSeriesRadio, seriesView);
            adminRadioPanelsPairs.Add(addGenresRadio, genresView);
            adminRadioPanelsPairs.Add(usersRadioButton, usersView);

        }

        /// Тук се обработват какво се случва при натискането на съответен радио бутон
        private void showBegginingRadio_CheckedChanged(object sender, EventArgs e)
        {
            getActiveOption();
        }

        private void showLibRadio_CheckedChanged(object sender, EventArgs e)
        {
            filmLibraryView.BackColor = Color.FromArgb(255, 192, 57);
            getActiveOption();
        }

        private void showCatRadio_CheckedChanged(object sender, EventArgs e)
        {
            getActiveOption();
        }
        private void showSeriesRadio_CheckedChanged(object sender, EventArgs e)
        {
            seriesLibraryView.BackColor = Color.FromArgb(255, 192, 57);
            getActiveOption();
        }
        private void showOptionRadio_CheckedChanged(object sender, EventArgs e)
        {
            getActiveOption();
        }

        private void addOfficeRadio_CheckedChanged(object sender, EventArgs e)
        {

            allOfficesView.BackColor = Color.FromArgb(255, 192, 57);

            getActiveOption();
        }

        private void addFilmRadio_CheckedChanged(object sender, EventArgs e)
        {
            allFilmsView.BackColor = Color.FromArgb(255, 192, 57);

            foreach (Genres s in genres.returnRecords())
            {
                genresCombo.Items.Add(s.getGenreName());
            }
            getActiveOption();
        }

        private void addSeriesRadio_CheckedChanged(object sender, EventArgs e)
        {
            getActiveOption();
        }

        private void addGenresRadio_CheckedChanged(object sender, EventArgs e)
        {
            getActiveOption();
        }
        private void usersRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            getActiveOption();
        }


        /// <summary>
        /// Спрямо това кой радио бутон е активен от навигацията, го намираме в мапа и активираме съотният 
        /// TapPage за визуализация на данните
        /// </summary>
        private void getActiveOption()
        {
            if (!GlobalVariables.Instance.getAdminLogged())
            {
                foreach (var pair in userRadioPanelsPairs)
                {
                    if (pair.Key.Checked)
                    {
                        userTabView.SelectedTab = pair.Value;
                        pair.Value.BackColor = Color.FromArgb(220, 93, 1);
                    }
                }
            }
            else
            {
                foreach (var pair in adminRadioPanelsPairs)
                {
                    if (pair.Key.Checked)
                    {
                        adminTabView.SelectedTab = pair.Value;
                        pair.Value.BackColor = Color.FromArgb(220, 93, 1);
                    }
                }
            }
        }

        private void changeRecord_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Зареждане на главния прозорец в Мениджърски режим
        /// </summary>
        private void adminLoad()
        {
            genres.initializeGenresArray();

            ViewControl.Instance.fillViewControl(allFilmsView, "films");
            ViewControl.Instance.fillViewControl(allOfficesView, "cities");
        }

        /// <summary>
        /// Зареждане на главния прозорец в Потребителски режим
        /// </summary>
        private void userLoad()
        {
            userNameLabel.Text = ViewControl.Instance.getLoggedEmail();
            welcomeLabel.Text = "Добре дошли отново " + userNameLabel.Text;

            ViewControl.Instance.fillViewControl(filmLibraryView, "FilmsLibrary");
            ViewControl.Instance.fillViewControl(seriesLibraryView, "SeriesLibrary");

            films.BackColor = Color.FromArgb(255, 192, 57);
            series.BackColor = Color.FromArgb(255, 192, 57);
            searchView.BackColor = Color.FromArgb(255, 192, 57);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selCombo = genresCombo.SelectedItem.ToString();
            if (String.IsNullOrWhiteSpace(selCombo))
            {
                MessageBox.Show("Изберете опция ");
            }
            ViewControl.Instance.searchResult(allFilmsView, "films", selCombo);
            
        }
        public static string row = null;

        /// <summary>
        /// Взима информацията от избрания ред за даден запис
        /// </summary>
        private void allFilmsView_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                
                Point startPoint = new Point(Cursor.Position.X, Cursor.Position.Y);

                rightClickStrip.Show(startPoint);

                
                ListViewItem itemRow = allFilmsView.SelectedItems[0];

                for( int i = 0; i < itemRow.SubItems.Count; i++)
                {
                    row +=  itemRow.SubItems[i].Text + "," ;
                }                
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// Обработва опцията от каскадното меню Промени за даден запис. Мениджърски режим
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
        {
            OptionsMenuFilms options = new OptionsMenuFilms(row, false, genres.returnRecords());
            row = null;
            options.Show();
        }

        /// <summary>
        /// Отваря прозореца за въвеждане на нов филм в базата данни. Мениджърски режим
        /// </summary>
        private void add_Click_1(object sender, EventArgs e)
        {
            OptionsMenuFilms options = new OptionsMenuFilms(row, true, genres.returnRecords());
            options.Show();
        }

        /// <summary>
        /// Презареждане на филмите. Използва се в мениджърски режим
        /// </summary>
        private void Reload_Click(object sender, EventArgs e)
        {
            allFilmsView.Items.Clear();
            ViewControl.Instance.fillViewControl(allFilmsView, "films");
        }

        /// <summary>
        /// Обработва опцията от каскадното меню при натискане на Изтриване при логване в мениджърски режим
        /// </summary>
        private void Delete_Click(object sender, EventArgs e)
        {
            Films f = new Films();
            string[] arr = row.Split(',');
            f.setName(arr[2]);
            ViewControl.Instance.deleteData(f, "Films");
            
        }

        /// <summary>
        /// Отваря прозореца за създаване на филтъра на търсене на филм / сериал
        /// </summary>
        private void filters_Click(object sender, EventArgs e)
        {
            filter.Visible = true;
        }

        /// <summary>
        /// Извежда всички филми или сериали по запаметеният филтър
        /// </summary>
        private void search_Click(object sender, EventArgs e)
        {
            searchView.Items.Clear();
            if (films.Checked)
            {
                ViewControl.Instance.filterResult(searchView, "Films");
            }
            
            if(series.Checked)
            {
                ViewControl.Instance.filterResult(searchView, "Series");
            }
            
        }

        /// <summary>
        /// Извежда всички филми или сериали
        /// </summary>
        private void all_Click(object sender, EventArgs e)
        {
            searchView.Items.Clear();
            if (films.Checked)
            {
                ViewControl.Instance.fillViewControl(searchView, "films");
            }

            if (series.Checked)
            {
                ViewControl.Instance.fillViewControl(searchView, "series");
            }
        }

        //Функции, с който се реализират движението на главния прозорец при натискане на бутона на мишката 
        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = new Point(e.X, e.Y);
            }
        }
        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown.IsEmpty)
                return;
            this.Location = new Point(this.Location.X + (e.X - mouseDown.X), this.Location.Y + (e.Y - mouseDown.Y));
        }
        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = Point.Empty;
        }
    }
}
