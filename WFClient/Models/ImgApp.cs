using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFClient.Models
{
    public class ImgApp
    {
        public readonly string path;
        public readonly List<string> imgNames;
        public Dictionary<string, Image?> imgs;
        public Dictionary<string, FileStream?> fsImgs;

        public ImgApp()
        {
            path = setPathImg(Environment.CurrentDirectory);
            imgs = new Dictionary<string, Image?>();
            fsImgs = new Dictionary<string, FileStream?>();
            imgNames = new List<string>() { "default" };

            setFsImgs(imgNames);
            setImgs(imgNames);
        }

        private string setPathImg(string path) => path.Substring(0, path.IndexOf("bin")) + "Sources\\";

        private void setFsImgs(List<string> imgNames)
        {
            foreach (string img in imgNames)
            {
                fsImgs.Add(img, File.Open(this.path + img + ".jpg", FileMode.Open));
            }
        }

        private void setImgs(List<string> imgNames)
        {
            foreach (string img in imgNames) 
            { 
                imgs.Add(img, getImgFromStream(fsImgs[img])); 
            }
        }

        private Image? getImgFromFile(in string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch { return null; }
        }

        private Image? getImgFromStream(FileStream fs)
        {
            try
            {
                return Image.FromStream(fs);
            }
            catch { return null; }
        }
    }
}
