using _3DSearch.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace _3DSearch
{
    public partial class AddFromFolders : UserControl
    {
        string[] filePathes;
        string oneFile;

        KindaRepository model;
        AddLogic addModel;

        decimal width = 0;
        decimal height = 0;
        decimal lenght = 0;

        decimal dimVal1 = 0;
        decimal dimVal2 = 0;
        decimal dimVal3 = 0;

        public AddFromFolders()
        {
            InitializeComponent();
            addModel = new AddLogic();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filePathes = null;
            oneFile = string.Empty;
            try
            {
                if (!checkBox1.Checked)
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {

                        filePathes = Directory.GetFiles(folderBrowserDialog1.SelectedPath);

                        foreach (var item in filePathes)
                        {


                            MessageBox.Show(item);
                        }
                    }
                }
                else
                {
                    OpenFileDialog choofdlog = new OpenFileDialog();
                    choofdlog.Filter = "All Files (*.SLDPRT*)|*.*";
                    choofdlog.FilterIndex = 1;

                    if (choofdlog.ShowDialog() == DialogResult.OK)
                    {

                        SomeHelpful.OpenLocal(choofdlog.FileName);
                    }
                 
                }
                //if (filePathes?.Length > 0 || oneFile != string.Empty)
                //{
                //    groupBox1.Enabled = true;
                //}
                //else
                //{
                //    groupBox1.Enabled = false;
                //}
            }
            catch(Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
        }

        private void buttonRepoSave_Click(object sender, EventArgs e)
        {
            if (CheckValues())
            {
                KindaRepository model = InitializeModel();
                addModel.InsertNewValue(model);
            }
        }
        private bool CheckValues()
        {
            try
            {

                height = Convert.ToDecimal(textBoxHeight.Text);
                lenght = Convert.ToDecimal(textBoxLenght.Text);
                width = Convert.ToDecimal(textBoxWidth.Text);

                dimVal1 = (textBoxDim1.Text == string.Empty) ? 0 : Convert.ToDecimal(textBoxDim1.Text);
                dimVal2 = (textBoxDim2.Text == string.Empty) ? 0 : Convert.ToDecimal(textBoxDim2.Text);
                dimVal3 = (textBoxDim3.Text == string.Empty) ? 0 : Convert.ToDecimal(textBoxDim3.Text);


                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Введены недопустимые значения" + e.Message);
                return false;
            }
        }

        private KindaRepository InitializeModel()
        {
            SizeM point3dSize = SomeHelpful.OrderSize(height, width, lenght);


            model = new KindaRepository();
            model.Size1 = point3dSize.P1;
            model.Size2 = point3dSize.P2;
            model.Size3 = point3dSize.P3;

            SizeM diamOfVals = SomeHelpful.OrderSize(dimVal1, dimVal2, dimVal3);
            model.DimVal1 = diamOfVals.P1;
            model.DimVal2 = diamOfVals.P2;
            model.DimVal3 = diamOfVals.P3;


            model.Path = addModel.GetPath();
            model.Model = addModel.ModelBytes(model.Path);

            return model;
        }

    
    }
}