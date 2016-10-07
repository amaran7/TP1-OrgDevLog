﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageEdgeDetection
{
    public static class ImageFilters
    {
        private const String nightFilter = "Night Filter";
        private const String hellFilter = "Hell Filter";
        private const String miamiFilter = "Miami Filter";
        private const String zenFilter = "Zen Filter";
        private const String bandwFilter = "Black and White";
        private const String swapFilter = "Swap Filter";
        private const String crazyFilter = "Crazy Filter";
        private const String megagreenFilter = "Mega Filter Green";
        private const String megaorangeFilter = "Mega Filter Orange";
        private const String megapinkFilter = "Mega Filter Pink";
        private const String megacustomFilter = "Mega Filter Custom";
        private const String rainbowFilter = "Rainbow Filter";


        public static Bitmap ApplyImageFilter(Bitmap bmp, String filterName)
        {
            switch (filterName)
            {
                case nightFilter:
                    return ApplyFilter(bmp, 1, 1, 1, 25);
                case hellFilter:
                    return ApplyFilter(bmp, 1, 1, 10, 15);
                case miamiFilter:
                    return ApplyFilter(bmp, 1, 1, 10, 1);
                case zenFilter:
                    return ApplyFilter(bmp, 1, 10, 1, 1);
                case bandwFilter:
                    return BlackWhite(bmp);
                case swapFilter:
                    return ApplyFilterSwap(bmp);
                case crazyFilter:
                    return ApplyFilterSwap(ApplyFilterSwapDivide(bmp, 1, 1, 2, 1));
                case megagreenFilter:
                    return ApplyFilterMega(bmp, 230, 110, Color.Green);
                case megaorangeFilter:
                    return ApplyFilterMega(bmp, 230, 110, Color.Orange);
                case megapinkFilter:
                    return ApplyFilterMega(bmp, 230, 110, Color.Pink);
                case megacustomFilter:
                    return ApplyFilterMega(bmp, 230, 110, Color.Black);
                case rainbowFilter:
                    return RainbowFilter(bmp);
            }

            return null;
        }
        //Rainbow Filter
        public static Bitmap RainbowFilter(Bitmap bmp)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);
            int raz = bmp.Height / 4;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {

                    if (i < (raz))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 2))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R, bmp.GetPixel(i, x).G / 5, bmp.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 3))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B / 5));
                    }
                    else if (i < (raz * 4))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B / 5));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G / 5, bmp.GetPixel(i, x).B / 5));
                    }
                }

            }
            return temp;
        }

        //apply color filter at your own taste
        public static Bitmap ApplyFilter(Bitmap bmp, int alpha, int red, int blue, int green)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.G / green, c.B / blue);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //black and white filter
        public static Bitmap BlackWhite(Bitmap Bmp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return Bmp;

        }

        //apply color filter to swap pixel colors
        public static Bitmap ApplyFilterSwap(Bitmap bmp)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //apply color filter to swap pixel colors
        public static Bitmap ApplyFilterSwapDivide(Bitmap bmp, int a, int r, int g, int b)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / a, c.G / g, c.B / b, c.R / r);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //apply color filter to swap pixel colors
        public static Bitmap ApplyFilterMega(Bitmap bmp, int max, int min, Color co)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {

                    Color c = bmp.GetPixel(i, x);
                    if (c.G > min && c.G < max)
                    {
                        Color cLayer = Color.White;
                        temp.SetPixel(i, x, cLayer);
                    }
                    else
                    {
                        temp.SetPixel(i, x, co);
                    }

                }

            }
            return temp;
        }

        //apply magic mosaic
        public static Bitmap DivideCrop(Bitmap bmp)
        {
            int razX = Convert.ToInt32(bmp.Width / 3);
            int razY = Convert.ToInt32(bmp.Height / 3);

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int x = 0; x < bmp.Height - 1; x++)
                {
                    if (i < razX && x < razY)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < (razX * 2) && x < (razY))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x, i));
                    }
                    else if (i < (razX * 3) && x < (razY))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < (razX) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x, i));
                    }
                    else if (i < (razX) && x < (razY * 3))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < (razX * 2) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < (razX * 4) && x < (razY * 1))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < (razX * 4) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x / 2, i / 2));
                    }
                    else if (i < (razX * 4) && x < (razY * 3))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x / 3, i / 3));
                    }

                }

            }
            return temp;
        }
    }
}
