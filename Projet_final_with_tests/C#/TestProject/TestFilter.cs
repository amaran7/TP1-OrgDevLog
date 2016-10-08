using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ImageEdgeDetection;

namespace TestProject
{
    [TestClass]
    public class TestFilter
    {
        Bitmap imageInitiale = Resource.BunnyLandscape;
        Bitmap imageFiltree = Resource.BunnyLandscapeFiltered;
    
        [TestMethod]
        public void sizeTest()
        {
            Bitmap resultImageFilter = ImageFilters.BlackWhite(imageInitiale);

            Assert.AreEqual(imageInitiale.Size, imageFiltree.Size);
        }

        [TestMethod]
        public void pixelIntegrityTest()
        {
            Bitmap resultImageFilter = ImageFilters.BlackWhite(imageInitiale);

            for (int x = 0; x < resultImageFilter.Height; x ++)
            {
                for (int y = 0; y < resultImageFilter.Width; y ++)
                {
                    Assert.AreEqual(imageInitiale.GetPixel(y,x), imageFiltree.GetPixel(y,x));
                }
            }

        }

        /*
        [TestMethod]
        public void corruptedImageTest()
        {
            Image notImage = Image.FromFile("D:\\OneDrive\\HES\\625-1 Organisation du développement logiciel\\Test Driven Development - Genoud\\Projets\\TP1\\TP1-OrgDevLog\\Projet_final_with_tests\\C#\\ImageEdgeDetection\\Resources\\imageCorrompue.png");

            Bitmap bitmapImage = new Bitmap(notImage);

                Bitmap imageFinale = ImageFilters.BlackWhite(bitmapImage);
                        
        }

       */
    }

}
