using WFClient.Models;

namespace WFClient
{
    public partial class WFClient : Form
    {
        private ImgApp imgApp;
        public WFClient()
        {
            InitializeComponent();
            imgApp = new ImgApp();
            prBxSelect.Image = imgApp.imgs["default"];

            lbSizeMb.Text = $"Byte: {imgApp.fsImgs["default"]?.Length}";
            lbSizeWxH.Text = $"Size: {imgApp.imgs["default"]?.Width} x {imgApp.imgs["default"]?.Height}";
        }

        private string getSizeMbImg(in string path)
        {
            try 
            { 
                return File.Open(path, FileMode.Open).Length.ToString();
            }
            catch { return "unknown"; }
        }
    }
}