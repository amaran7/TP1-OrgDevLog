using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using ImageEdgeDetection;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class TestFilterBlackWhite
    {
        // Image de départ
        Bitmap imageInitiale = Resource.BunnyLandscape;

        // Image finale (emploi du filtre Black & White)
        Bitmap imageFiltreeBlackWhite = Resource.BunnyLandscapeFiltered;
    
        // Méthode permettant de tester que la taille de l'image filtrée correspond à la taille de l'image initiale
        [TestMethod]
        public void sizeTest()
        {
            Bitmap imageFiltree = ImageFilters.BlackWhite(imageInitiale);

            Assert.AreEqual(imageInitiale.Size, imageFiltree.Size);
        }

        // Test permettant de comparer les deux images, pixel par pixel
        [TestMethod]
        public void pixelIntegrityTest()
        {
            Bitmap imageFiltree = ImageFilters.BlackWhite(imageInitiale);

            for (int x = 0; x < imageFiltree.Height; x ++)
            {
                for (int y = 0; y < imageFiltree.Width; y ++)
                {
                    Assert.AreEqual(imageInitiale.GetPixel(y,x), imageFiltree.GetPixel(y,x));
                }
            }

        }

        // Méthode permettant de tester que l'image finale correspond au résultat souhaité au niveau de la couleur (pixel par pixel)
        [TestMethod]
        public void colorPixelTest()
        {
            Bitmap imageFiltreeTest = ImageFilters.BlackWhite(imageInitiale);
            for (int i = 0; i < imageFiltreeTest.Width; i++)
            {
                for (int j = 0; j < imageFiltreeTest.Height; j++)
                {
                    Color couleurPixelSouhaite = imageFiltreeBlackWhite.GetPixel(i, j);
                    Color couleurPixelTest = imageFiltreeTest.GetPixel(i, j);

                    Assert.AreEqual(couleurPixelSouhaite, couleurPixelTest);
                }

            }

        }

        /*
        // Test vérifiant s'il s'agit bien d'une image
        [TestMethod]
        public void isImageTest()
        {

            //Image imageCorrompue = Image.FromFile("C:\\imageCorrompue.jpg");
            //Bitmap bmpImageCorrompue = new Bitmap(imageCorrompue);

            Bitmap bmpImageCorrompue = ImageFilters.BlackWhite(imageInitiale);

            Assert.IsNull(ImageFilters.BlackWhite(bmpImageCorrompue));

        }

        */

        /*
        // Test permettant de vérifier que la méthode retourne null si une image null est entrée
        [TestMethod]
        public void imageNullTestI()
        {
            Bitmap imageNull = null;

            Assert.IsNull(ImageFilters.BlackWhite(imageNull));
        }
        */

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
