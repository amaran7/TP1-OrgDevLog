﻿using System;
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

        // Méthode permettant de tester que le type de fichier de départ est identique à celui d'arrivée
        [TestMethod]
        public void extensionTest()
        {
            Bitmap imageFiltreeTest = ImageFilters.BlackWhite(imageInitiale);

            String extensionImageInitiale = Path.GetExtension(imageInitiale.ToString());
            String extensionImageFiltree = Path.GetExtension(imageFiltreeTest.ToString());

            Assert.AreEqual(extensionImageInitiale, extensionImageFiltree);
        }

        
    }

}
