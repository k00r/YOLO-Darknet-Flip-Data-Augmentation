using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace sampleFlipper
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = @"C:\";	//change this path to your own folder
            string[] fliplenecekJpgler = Directory.GetFiles(workingDirectory, "*.jpg");

            for (int j = 0; j < fliplenecekJpgler.Length; j++)
            {
                string sampleRawName = Path.GetFileNameWithoutExtension(fliplenecekJpgler[j]);
                string sampleImageName = sampleRawName + ".jpg";
                string sampleAnnotationName = sampleRawName + ".txt";
                string[] objects = File.ReadAllLines(workingDirectory + sampleAnnotationName);
                string[] objectParameters;
                float y;

                for (int i = 0; i < objects.Length; i++)
                {
                    objectParameters = objects[i].Split(' ');
                    objectParameters[1] = objectParameters[1].Replace(".", ",");

                    y = float.Parse(objectParameters[1]);
                    y = 1.00f - y;

                    objectParameters[1] = y.ToString();
                    objectParameters[1] = objectParameters[1].Replace(",", ".");

                    objects[i] = String.Join(" ", objectParameters);
                }

                File.WriteAllLines(workingDirectory + sampleRawName + "f" + ".txt", objects);
                Image sample = Image.FromFile(workingDirectory + sampleImageName);
                sample.RotateFlip(RotateFlipType.Rotate180FlipY);
                sample.Save(workingDirectory + sampleRawName + "f" + ".jpg", ImageFormat.Jpeg);
                if (File.Exists(workingDirectory + sampleImageName) && File.Exists(workingDirectory + sampleAnnotationName))
                {
                    File.Delete(workingDirectory + sampleImageName);
                    File.Delete(workingDirectory + sampleAnnotationName);
                }
            }  
        }
    }
}
