using System.Drawing;

namespace Dating.FaceRecognition
{
    public class FaceCompare
    {
        private readonly string currentDirectory = Environment.CurrentDirectory + "\\FaceRecModel";
        private readonly FaceRecognitionDotNet.FaceRecognition fr;

        public FaceCompare()
        {
            fr = FaceRecognitionDotNet.FaceRecognition.Create(currentDirectory);
        }

        public bool FaceCheckMatch(Stream image1, Stream image2)
        {
            var dlibToComBuf = FaceRecognitionDotNet.FaceRecognition.LoadImage(new Bitmap(image1));
            var dlibToComBuf2 = FaceRecognitionDotNet.FaceRecognition.LoadImage(new Bitmap(image2));
            lock (fr)
            {
                var enToCompare = fr.FaceEncodings(dlibToComBuf).First();
                var enToCompare2 = fr.FaceEncodings(dlibToComBuf2).First();
                return FaceRecognitionDotNet.FaceRecognition.CompareFace(enToCompare, enToCompare2);
            }
        }
    }
}
