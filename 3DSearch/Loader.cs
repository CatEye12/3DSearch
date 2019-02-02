using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using System;
using System.Runtime.InteropServices;

namespace _3DSearch
{
    [ComVisible(true)]
    public class Loader : ISwAddin
    {
        public const string SWTASKPANE_PROGID = "_3DSearch.Loader";
        public SldWorks SWApplication;
        private int mSWCookie;
        private TaskpaneView mTaskpaneView;
        static public LittlePane mTaskpaneHost;


        public bool ConnectToSW(object ThisSW, int Cookie)
        {
            SWApplication = (SldWorks)ThisSW;
            mSWCookie = Cookie;
            // Set-up add-in call back info
            bool result = SWApplication.SetAddinCallbackInfo(0, this, Cookie);
            this.UISetup();
            
            return true;
        }

        public bool DisconnectFromSW()
        {
            this.UITeardown();
            return true;
        }

        
        private void UITeardown()
        {
            mTaskpaneHost = null;
            mTaskpaneView.DeleteView();
            Marshal.ReleaseComObject(mTaskpaneView);
            mTaskpaneView = null;
        }



        private void UISetup()
        {
            try
            {
                string imagePath;
                imagePath = @"\Resources\Theme.png";
                mTaskpaneView = SWApplication.CreateTaskpaneView2(imagePath, "3DSearch");
                mTaskpaneHost = (LittlePane)mTaskpaneView.AddControl(Loader.SWTASKPANE_PROGID, "");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }


        [ComRegisterFunction()]
        private static void ComRegister(Type t)
        {
            string keyPath = String.Format(@"SOFTWARE\SolidWorks\AddIns\{0:b}", t.GUID);
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(keyPath))
            {
                rk.SetValue(null, 1); // Load at startup
                rk.SetValue("Title", "3DSearch"); // Title
                rk.SetValue("Description", "Repository for SolidWorks models."); // Description
            }
        }

        [ComUnregisterFunction()]
        private static void ComUnregister(Type t)
        {
            string keyPath = String.Format(@"SOFTWARE\SolidWorks\AddIns\{0:b}", t.GUID);
            Microsoft.Win32.Registry.LocalMachine.DeleteSubKeyTree(keyPath);
        }
    }
}