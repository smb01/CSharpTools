using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gif.Components;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace GifCut
{
    class GifConvert
    {
        public static bool DecompressGif(string gifPath, string outputPath)
        {
            try
            {
                using (Image imgGif = Image.FromFile(gifPath))
                {
                    System.Drawing.Imaging.FrameDimension ImgFrmDim = new FrameDimension(imgGif.FrameDimensionsList[0]);
                    int nFrameCount = imgGif.GetFrameCount(ImgFrmDim);

                    for (int i = 0; i < nFrameCount; i++)
                    {
                        imgGif.SelectActiveFrame(ImgFrmDim, i);
                        imgGif.Save(string.Format(outputPath + "\\Frame{0}.jpg", i), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    return true;
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
                return false; 
            }
        }

        public static bool CompressGif(List<string> gifPath, string outputPath,int ms,int repeat)
        {
            try
            {
                AnimatedGifEncoder gif = new AnimatedGifEncoder();

                gif.Start(outputPath);
                gif.SetDelay(ms);

                //-1:no repeat,0:always repeat   
                gif.SetRepeat(repeat);

                for (int i = 0, count = gifPath.Count; i < count; i++)
                {
                    using (Image img = Image.FromFile(gifPath.ElementAt(i)))
                        gif.AddFrame(img);
                }

                gif.Finish();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
