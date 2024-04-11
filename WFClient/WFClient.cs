using WFClient.Models;

namespace WFClient
{
    public partial class WFClient : Form
    {
        private ImgApp imgApp;
        private const int imgSizePx = 500;
        private const int imgSizeBt = 2 ^ 20;
        private FileStream? imgStream;
        public WFClient()
        {
            InitializeComponent();

            imgApp = new ImgApp();
            openFileDialogImg.InitialDirectory = imgApp.path;

            imgStream = imgApp.fsImgs[imgApp.imgNames.First()];
            setImgInfo();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialogImg.ShowDialog() == DialogResult.Cancel) { return; }

            if (imgStream?.Length != 0) { imgStream?.Dispose(); }

            imgStream = (FileStream)openFileDialogImg.OpenFile();

            setImgInfo();
        }

        private void setImgInfo()
        {
            Image imgX = Image.FromStream(imgStream);

            prBxSelect.Image = imgX;

            lbSizeMb.Text = $"Byte: {imgStream?.Length}";
            lbSizeWxH.Text = $"Size: {imgX.Width} x {imgX.Height}";
        }

        private void WFClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (imgStream?.Length != 0) { imgStream?.Dispose(); }
        }
    }
}