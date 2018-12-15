using System;
using System.Windows.Forms;
using System.Data.Linq;

namespace _3DSearch
{
    public partial class Search : UserControl
    {
        SQLRepositoryDataContext da = new SQLRepositoryDataContext();
        SearchModel search;
        SearchModel wasSelected;
        int percents = 10;
        

        public Search()
        {
            InitializeComponent();
            dataGridViewSearchResult.Size = new System.Drawing.Size(this.Size.Width, 250);
            comboBoxPercents.DataSource = new int[] { 10, 20, 30 ,40, 50 ,60 ,70 ,80 ,90 ,100};
            comboBoxPercents.SelectedIndex = 0;
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool CollectValues(SearchModel search)
        {
            try
            {
                search.Size1 = Convert.ToInt32(textBoxWidth.Text);
                search.Size2 = Convert.ToInt32(textBoxHeight.Text);
                search.Size3 = Convert.ToInt32(textBoxLength.Text);
                percents = (int)comboBoxPercents.SelectedItem;
                return true;
            }
            catch (Exception  e )
            {
                MessageBox.Show("Введены некорекктные параметры");
                return false;
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SQLRepositoryDataContext da = new SQLRepositoryDataContext(Properties.Settings.Default.SQLConnection1);
            Table <KindaRepository> repo = da.KindaRepositories;



            search = new SearchModel();

            if (checkBoxSearchAll.Checked)
            {
                dataGridViewSearchResult.DataSource = search.SearchSimilar();
            }
            else
            {
                if (CollectValues(search))
                {
                    dataGridViewSearchResult.DataSource = search.SearchSimilar(percents, search.Size1, search.Size2, search.Size3);
                    dataGridViewSearchResult.Columns[0].Visible = false;
                    //dataGridViewSearchResult.Height = ResizeDataGridView();
                    dataGridViewSearchResult.CellClick += DataGridViewSearchResult_CellClick;
                }
            }
        }

        private void DataGridViewSearchResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString() + "  "  + e.RowIndex.ToString());

            if (e.ColumnIndex > 0 && e.RowIndex > 0)
            {
                int wasSel = e.RowIndex;

                try
                {
                    wasSelected = (SearchModel)dataGridViewSearchResult.Rows.SharedRow(wasSel).DataBoundItem;
                    string localPath;


                    if (wasSelected.Local)
                    {

                        localPath = search.GetPathFromDB(wasSelected.ID);

                        if (!search.OpenLocal(localPath))
                        {
                            search.GoToGetBytes(wasSelected.ID);
                        }
                    }
                    else
                    {
                        search.GoToGetBytes(wasSelected.ID);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void checkBoxSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchAll.Checked)
            {
                textBoxHeight.Enabled = false;
                textBoxLength.Enabled = false;
                textBoxWidth.Enabled = false;
            }
            else
            {
                textBoxHeight.Enabled = true;
                textBoxLength.Enabled = true;
                textBoxWidth.Enabled = true;

            }
        }

        private int ResizeDataGridView()
        {
            int quantity = dataGridViewSearchResult.Rows.Count;
            int count =  dataGridViewSearchResult.Rows.GetRowsHeight(DataGridViewElementStates.Displayed);

            if (quantity < 1) return 25;

            return quantity * count;
        }



    }
}