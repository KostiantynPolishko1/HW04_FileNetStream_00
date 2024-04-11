using WFClient.Models;

namespace WFClient
{
    public partial class WFClient : Form
    {
        private ImgApp imgApp;
        private const int imgMaxSizePx = 500;
        private const int imgMaxSizeBt = 1048576;
        private FileStream? imgStream;
        public WFClient()
        {
            InitializeComponent();

            imgApp = new ImgApp();
            openFileDialogImg.InitialDirectory = imgApp.path;

            imgStream = imgApp.fsImgs[imgApp.imgNames.First()];
            setImgInfo(Image.FromStream(imgStream));
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialogImg.ShowDialog() == DialogResult.Cancel) { return; }

            if (imgStream?.Length != 0) { imgStream?.Dispose(); }

            imgStream = (FileStream)openFileDialogImg.OpenFile();
            Image imgX = Image.FromStream(imgStream);

            setImgInfo(imgX);
            if (isImgRequirements(imgX)) { btnSend.Enabled = true; }
            else 
            { 
                btnSend.Enabled = false;
                MessageBox.Show($"Img is out size WxH{imgMaxSizePx}x{imgMaxSizePx} : Byte{imgMaxSizeBt}");
            }
        }

        private void setImgInfo(Image imgX)
        {           
            prBxSelect.Image = imgX;

            lbSizeMb.Text = $"Byte: {imgStream?.Length}";
            lbSizeWxH.Text = $"Size: {imgX.Width} x {imgX.Height}";
        }

        private void WFClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgStream?.Length != 0) { imgStream?.Dispose(); }
        }

        private bool isImgRequirements(Image imgX)
        {
            if (imgX.Width > imgMaxSizePx || imgX.Height > imgMaxSizePx) return false;
            else if (imgStream?.Length > imgMaxSizeBt) return false;

            return true;
        }
    }
}