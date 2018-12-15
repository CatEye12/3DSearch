using System;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using System.Runtime.InteropServices;
using _3DSearch.Controls;
using System.IO;

namespace _3DSearch
{
    public partial class AddControl : UserControl
    {


        KindaRepository model;
        AddLogic addModel;
        decimal width = 0;
        decimal height = 0;
        decimal lenght = 0;

        decimal dimVal1 = 0;
        decimal dimVal2 = 0;
        decimal dimVal3 = 0;




        public AddControl()
        {
            InitializeComponent();
            addModel = new AddLogic();
            textBoxPartName.Text = GetNameIfPartAlreadyNamed();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonRepoSave_Click(object sender, EventArgs e)
        {

            if (CheckValues())
            {
                KindaRepository model = InitializeModel();
                addModel.InsertNewValue(model);
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

        private bool CheckValues()
        {
            try
            {

                height  = Convert.ToDecimal(textBoxHeight.Text);
                lenght = Convert.ToDecimal(textBoxLenght.Text);
                width = Convert.ToDecimal(textBoxWidth.Text);

                dimVal1 = (textBoxDim1.Text == string.Empty) ? 0: Convert.ToDecimal(textBoxDim1.Text);
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



        private void buttonLocalSave_Click(object sender, EventArgs e)
        {
            string partName = textBoxPartName.Text;
            if (partName != string.Empty)
            {

                if (!addModel.SaveLocal(partName))
                {
                    ((SldWorks)Marshal.GetActiveObject("SldWorks.Application")).SendMsgToUser("Не удалось сохранить деталь!");
                }
            }
            else
            {
                MessageBox.Show("Укажите с каким именем сохранить  деталь");
            }
        }

        private void btnOneMoreDiam2_Click(object sender, EventArgs e)
        {
            if (!label5.Visible)
            {
                label5.Visible = true;
                textBoxDim2.Visible = true;
                btnOneMoreDiam2.Location = new System.Drawing.Point(textBoxDim2.Size.Width + textBoxDim2.Location.X + 3, textBoxDim2.Location.Y);
            }
            else
            {
                label6.Visible = true;
                textBoxDim3.Visible = true;
                btnOneMoreDiam2.Location = new System.Drawing.Point(textBoxDim3.Size.Width + textBoxDim3.Location.X + 3, textBoxDim3.Location.Y);
            }
        }

        private string GetNameIfPartAlreadyNamed()
        {
            ModelDoc2 part = ((SldWorks)Marshal.GetActiveObject("SldWorks.Application")).ActiveDoc;
            if (part != null)
            {
                return Path.GetFileNameWithoutExtension( part.GetTitle());
            }

            return string.Empty;
        }
    }
}
