using WFClient.Models;
using Library;
using System.Text;
using System.Net.Sockets;

namespace WFClient
{
    public partial class WFClient : Form
    {
        private ImgApp imgApp;
        private const int imgMaxSizePx = 500;
        private const int imgMaxSizeBt = 1048576;
        private FileStream? imgStream;
        private SocketClient? socketClient;
        private StreamWriter? sWriter;

        public WFClient()
        {
            InitializeComponent();
            if (!createClient() || !Extensions.createStreamWriter(socketClient, out sWriter))
            {
                MessageBox.Show("Reopen Client!");
                Environment.Exit(0);
            }

            imgApp = new ImgApp();
            openFileDialogImg.InitialDirectory = imgApp.path;

            imgStream = imgApp.fsImgs[imgApp.imgNames.First()];
            setImgInfo(Image.FromStream(imgStream));
        }

        private bool createClient()
        {
            try
            {
                socketClient = new SocketClient(new ConnectIPEndP().getIpeP());
                lbIpServer.Text = $"IpServer{socketClient.RemoteEndPoint}";
                lbIpClient.Text = $"IpClient{socketClient.LocalEndPoint}";
                return true;
            }
            catch { return false; }
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

            lbName.Text = $"Name: {Extensions.getFileName(imgStream?.Name)}";
            lbSizeMb.Text = $"Byte: {imgStream?.Length}";
            lbSizeWxH.Text = $"Size: {imgX.Width} x {imgX.Height}";
        }

        private void WFClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sWriter?.WriteLine("exit");
                sWriter?.Flush();
            }
            catch { }

            if (imgStream?.Length != 0) { imgStream?.Dispose(); }
            sWriter?.Close();
            socketClient?.Close();
        }

        private bool isImgRequirements(Image imgX)
        {
            if (imgX.Width > imgMaxSizePx || imgX.Height > imgMaxSizePx) return false;
            else if (imgStream?.Length > imgMaxSizeBt) return false;

            return true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sWriter?.WriteLine(lbName.Text);
            sWriter?.Flush();


        }
    }
}