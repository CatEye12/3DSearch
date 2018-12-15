using System;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections.Generic;

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
            comboBoxPercents.DataSource = new int[] { 0, 10, 20, 30 ,40, 50 ,60 ,70 ,80 ,90, 100};
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
                search.Size1 = Convert.ToDecimal(textBoxWidth.Text);
                search.Size2 = Convert.ToDecimal(textBoxHeight.Text);
                search.Size3 = Convert.ToDecimal(textBoxLength.Text);
                percents = Convert.ToInt32( comboBoxPercents.Text);
                MessageBox.Show(percents.ToString());
                if (!checkBoxMainParams.Checked)
                {
                    search.DimVal1 = string.IsNullOrEmpty(textBoxD1.Text) ? 0 : Convert.ToDecimal(textBoxD1.Text);
                    search.DimVal2 = string.IsNullOrEmpty(textBoxD2.Text) ? 0 : Convert.ToDecimal(textBoxD2.Text);
                    search.DimVal3 = string.IsNullOrEmpty(textBoxD3.Text) ? 0 : Convert.ToDecimal(textBoxD3.Text);
                }
                else
                {
                    search.DimVal1 = 0;
                    search.DimVal2 = 0;
                    search.DimVal3 = 0;
                }


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
            List<SearchModel> fillTable = new List<SearchModel>();
            search = new SearchModel();

            if (checkBoxSearchAll.Checked)
            {
                fillTable = search.SearchSimilar();
            }
            else
            {
                if (CollectValues(search))
                {
                    fillTable = search.SearchSimilar(percents, search);
                }
            }
            dataGridViewSearchResult.DataSource = fillTable;
            dataGridViewSearchResult.Columns[0].Visible = false;

           // dataGridViewSearchResult.Height = ResizeDataGridView();
        }




        private void checkBoxSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchAll.Checked)
            {
                textBoxHeight.Enabled = false;
                textBoxLength.Enabled = false;
                textBoxWidth.Enabled = false;
                comboBoxPercents.Enabled = false;
            }
            else
            {
                textBoxHeight.Enabled = true;
                textBoxLength.Enabled = true;
                textBoxWidth.Enabled = true;
                comboBoxPercents.Enabled = true;
            }
        }

        private int ResizeDataGridView()
        {
            int quantity = dataGridViewSearchResult.Rows.Count;
            int count =  dataGridViewSearchResult.Rows.GetRowsHeight(DataGridViewElementStates.Displayed);

            if (quantity < 1) return dataGridViewSearchResult.ColumnHeadersHeight;

            return quantity * count;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMainParams.Checked)
            {
                textBoxD1.Enabled = false;
                textBoxD2.Enabled = false;
                textBoxD3.Enabled = false;
            }
            else
            {
                textBoxD1.Enabled = true ;
                textBoxD2.Enabled = true;
                textBoxD3.Enabled = true;
            }
        }

        private void dataGridViewSearchResult_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex.ToString() + "  " + e.RowIndex.ToString());

            if (e.RowIndex >= 0)
            {
                try
                {
                    wasSelected = (SearchModel)dataGridViewSearchResult.Rows.SharedRow(e.RowIndex).DataBoundItem;

                    search.GetPartFromDB(wasSelected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}