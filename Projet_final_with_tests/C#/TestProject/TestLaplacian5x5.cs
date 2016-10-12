using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ImageEdgeDetection;

namespace TestProject
{
    [TestClass]
    public class TestLaplacian5x5
    {
        // Image initiale
        Bitmap imageInitiale = Resource.HortonLandscape;

        // Image finale (emploi de Edge Detection Laplacian 5x5)
        Bitmap imageFiltreeLaplacian = Resource.HortonLandscapeLaplacian5x5;

        // Méthode permettant de tester que la taille de l'image filtrée correspond à la taille de l'image initiale
        [TestMethod]
        public void sizeTest()
        {
            Bitmap imageFiltree = ExtBitmap.Laplacian5x5Filter(imageInitiale);

            Assert.AreEqual(imageInitiale.Size, imageFiltree.Size);
        }

        // Test permettant de comparer les deux images, pixel par pixel
        [TestMethod]
        public void pixelIntegrityTest()
        {
            Bitmap imageFiltree = ExtBitmap.Laplacian5x5Filter(imageInitiale, false);

            for (int x = 0; x < imageFiltree.Height; x++)
            {
                for (int y = 0; y < imageFiltree.Width; y++)
                {
                    Assert.AreEqual(imageFiltreeLaplacian.GetPixel(y, x), imageFiltree.GetPixel(y, x));
                }
            }

        }

        // Méthode permettant de tester que l'image finale correspond au résultat souhaité au niveau de la couleur (pixel par pixel)
        [TestMethod]
        public void colorPixelTest()
        {
            Bitmap imageFiltreeTest = ExtBitmap.Laplacian5x5Filter(imageInitiale, false);
            for (int i = 0; i < imageFiltreeTest.Width; i++)
            {
                for (int j = 0; j < imageFiltreeTest.Height; j++)
                {
                    Color couleurPixelSouhaite = imageFiltreeLaplacian.GetPixel(i, j);
                    Color couleurPixelTest = imageFiltreeTest.GetPixel(i, j);

                    Assert.AreEqual(couleurPixelSouhaite, couleurPixelTest);
                }

            }

        }


    }
}
