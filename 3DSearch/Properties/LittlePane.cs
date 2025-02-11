﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _3DSearch
{
    [ComVisible(true)]
    [ProgId(Loader.SWTASKPANE_PROGID)]
    public partial class LittlePane : UserControl
    {
        static AddControl userAddControl = new AddControl();
        static AddFromFolders userAddFromFolderControl = new AddFromFolders();
        static ConfigurationControl userConfigurationControl = new ConfigurationControl();
        static Search userSerachControl = new Search();



        static private LittlePane littleInstance = new LittlePane();
        public static LittlePane Instance
        {
            get
            {
                MessageBox.Show("get ");
                if (littleInstance == null)
                {
                   
                    littleInstance.BackColor = Color.AntiqueWhite;
                    return littleInstance;
                }
                else
                {
                    //MessageBox.Show("From else "  + littleInstance.GetHashCode().ToString());
                    return littleInstance;
                }
            }
        }

        public LittlePane()
        {

            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.Bisque;
            this.Resize += LittlePane_Resize;
        }


        private void AddButton_Click(object sender, EventArgs e)
        {

            if (this.Controls.ContainsKey("Add"))
            {
                this.Controls["Add"].Show();
            }
            else
            {
                userAddControl.BackColor = Color.YellowGreen;
                userAddControl.Name = "Add";
                userAddControl.Size = this.Size;
                this.Controls.Add(userAddControl);
                this.Controls["Add"].BringToFront();
            }
        }

        private void AddFileFromFolderButton_Click(object sender, EventArgs e)
        {
            //if (this.Controls.ContainsKey("AddFromFolder"))
            //{
            //    this.Controls["AddFromFolder"].Show();
            //}
            //else
            //{
            //    userAddFromFolderControl.BackColor = Color.PaleVioletRed;
            //    userAddFromFolderControl.Name = "AddFromFolder";
            //    userAddFromFolderControl.Size = this.Size;
            //    this.Controls.Add(userAddFromFolderControl);
            //    this.Controls["AddFromFolder"].BringToFront();
            //}
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("Search"))
            {
                this.Controls["Search"].Show();
            }
            else
            {
                userSerachControl.BackColor = Color.MediumPurple;
                userSerachControl.Name = "Search";
                userSerachControl.Size = this.Size;
                this.Controls.Add(userSerachControl);
                this.Controls["Search"].BringToFront();
            }
        }

        private void LittlePane_Resize(object sender, EventArgs e)
        {
            userAddControl.Size = this.Size;
            userAddFromFolderControl.Size = this.Size;
            userConfigurationControl.Size = this.Size;
            userSerachControl.Size = this.Size;
        }

        private void ConfigurationButton_Click(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("Configuration"))
            {
                this.Controls["Configuration"].Show();
            }
            else
            {
                userConfigurationControl.BackColor = Color.Honeydew;
                userConfigurationControl.Name = "Configuration";
                userConfigurationControl.Size = this.Size;
                this.Controls.Add(userConfigurationControl);
                this.Controls["Configuration"].BringToFront();
            }
        }
    }
}