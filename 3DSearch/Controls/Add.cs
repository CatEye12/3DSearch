using System;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using System.Runtime.InteropServices;
using _3DSearch.Controls;

namespace _3DSearch
{
    public partial class Add : UserControl
    {


        KindaRepository model;
        AddLogic addModel;
        int width = 0;
        int height = 0;
        int lenght = 0;

        int dimVal1 = 0;
        int dimVal2 = 0;
        int dimVal3 = 0;




        public Add()
        {
            InitializeComponent();
            
            addModel = new AddLogic();
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

            if (dimVal3 != 0)
            {
                SizeM diamOfVals = SomeHelpful.OrderSize(height, width, lenght);

                model.DimVal1 = diamOfVals.P1;
                model.DimVal2 = diamOfVals.P2;
                model.DimVal3 = diamOfVals.P3;
            }
            else if (dimVal2 == 0)
            {
                model.DimVal1 = dimVal1;
                model.DimVal2 = 0;
                model.DimVal3 = 0;
            }
            else
            {
                int temp = Math.Max(dimVal1, dimVal2);
                model.DimVal1 = temp;

                temp = Math.Min(dimVal1, dimVal2);
                model.DimVal2 = temp;

                model.DimVal3 = 0;
            }

            model.Path = addModel.GetPath();
            model.Model = addModel.ModelBytes(model.Path);

            return model;
        }

        private bool CheckValues()
        {
            try
            {

                height  = Convert.ToInt32(textBoxHeight.Text);
                lenght = Convert.ToInt32(textBoxLenght.Text);
                width = Convert.ToInt32(textBoxWidth.Text);

                dimVal1 = (textBoxDim1.Text == string.Empty) ? 0: Convert.ToInt32(textBoxDim1.Text);
                dimVal2 = (textBoxDim2.Text == string.Empty) ? 0 : Convert.ToInt32(textBoxDim2.Text);
                dimVal3 = (textBoxDim3.Text == string.Empty) ? 0 : Convert.ToInt32(textBoxDim3.Text);

                
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

    }
}
