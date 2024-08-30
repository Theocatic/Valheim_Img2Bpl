using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;

namespace Valheim_Image_Converter
{
    internal class Img2BP
    {
        public static string ConvertImage(string[] args)
        {
            String Output = "";

            string imgfile = args[0];
            string bplname = args[1];
            bool vshift = int.Parse(args[2]) == 1;
            bool bblock = int.Parse(args[3]) == 1;
            double fontsize = double.Parse(args[4]); //pixels are displaced by 1/10th of their fontsize by default.
            string tc = args[5];
            bool BetterTransparency = int.Parse(args[6]) == 1;
            bool signBacking = int.Parse(args[7]) == 1;
            
            List<string> tclist = new List<string>();
            char[] tcConverted = tc.ToCharArray();
            string tcBreaker = "";
            for (int i = 0; i < tcConverted.Length; i++)
            {
                if (tcConverted[i] != ',')
                    tcBreaker = tcBreaker + tcConverted[i];
                else
                {
                    tclist.Add(tcBreaker);
                    tcBreaker = "";
                }
            }
            if (tcBreaker != "")
                tclist.Add(tcBreaker);

   

            if (string.IsNullOrEmpty(imgfile) || string.IsNullOrEmpty(bplname))
            {
                Program.ThrowError("No Working Image File or No Blueprint Name", ErrorLocation.Bottom);
                return Output;
            }

            try
            {
                using (var image = new MagickImage(imgfile))
                {
                    int w = image.Width;
                    int h = image.Height;

                    //if (w > 480 || h > 480) removed max image size. You're welcome :) Good for heating up your house.
                    //{
                    //    Program.ThrowError("Image size too big");
                    //    return Output;
                    //}

                    if (w == 0 || h == 0)
                    {
                        Program.ThrowError("Image size too small", ErrorLocation.Bottom);
                        return Output;
                    }

                    string header = $@"
#Name:{bplname}
#Creator:Img2Bpl.cs
#Description:""
#Category:img2bpl
#Pieces
{(bblock ? "" : "wood_pole;Building;0;0;0;0;1;0;0;\"\";1;1;1\n")}";

                    Output = (header);

                    double pixsz = 0.3 * (fontsize / 9.0);
                    double xstart = -w * pixsz / 2;
                    double z1 = pixsz;
                    double z2 = z1 + pixsz * 1.1;


                    string pixelt = "<~rgb~>■\\n";
                    int newLines = 0;
                    double LeftOverNewLineSpace = 0;
                    string pixeltAlt = "<~rgb~>□\\n"; //a white square for transparent pixels to minimize strange coloration due to transparent text bugs thanks valheim devs -_-
                    string colt = @"
sign;Furniture;~x~;~z1~;0;1;0;0;0;<size=~fontsize~>~pix1~;1;1;1
sign;Furniture;~x~;~z2~;0;1;0;0;0;<size=~fontsize~>~pix2~;1;1;1";



                    for (int x = 0; x < w; x++)
                    {
                        string col = colt;
                        string pix1 = "";
                        string pix2 = "";

                        if (!vshift)
                        {
                            int temph = h;
                            if (h % 2 != 0)
                                temph++;

                            //Previous version of this used 1.45 but that created bad errors at larger picture sizes where the image would not line up
                            pix1 = new string('\n', (int)(temph / 1.5)).Replace("\n", "\\n");
                            pix2 = new string('\n', (int)(temph / 1.5)).Replace("\n", "\\n");
                            newLines = (int)(temph / 1.5);

                            LeftOverNewLineSpace = (double)temph / 1.5; //just in case because this is doing weird things

                            //this method is used because for some strange reason using a % didn't work as well probably user error on my part :p
                            LeftOverNewLineSpace = LeftOverNewLineSpace - newLines; 



                        }


                        for (int y = 0; y < h / 2; y++)
                        {
                            //$rgb1 = get_pixel_rgb($image, $x, $h - $y * 2 + 1);
                            //$rgb2 = get_pixel_rgb($image, $x, $h - $y * 2 + 0);
                            bool LastPixel = false;
                            string rgb1 = GetPixelRGB(image, x, h - (y * 2) - 1);
                            string rgb2 = GetPixelRGB(image, x, h - (y * 2 + 1) - 1);
                            string rgb3 = "";
                            if ((h - ((y * 2) + 2) - 1) == 0)//if there is one remaining pixel in the line
                            {
                                rgb3 = GetPixelRGB(image, x, h - ((y * 2) + 2) - 1);
                                LastPixel = true;
                            }


                            if (tclist.Count > 0)
                            {
                                for (int i = 0; i < tclist.Count; i++) //loop through each color to set transparent
                                {
                                    rgb1 = rgb1.ToLower() == tclist[i].ToLower() ? "#00000000" : rgb1; //check the hex of the color to the transparent setting color
                                    rgb2 = rgb2.ToLower() == tclist[i].ToLower() ? "#00000000" : rgb2;
                                    if (LastPixel)
                                        rgb3 = rgb3 == tclist[i].ToLower() ? "#00000000" : rgb3;

                                }

                            }


                            string pix1t;
                            string pix2t;
                            string pix3t = "";
                            if (BetterTransparency)
                            {
                                string comparison = "";
                                if (rgb1.Length == 9) //length is only 9 when the original pixel is partially or fully transparent
                                    comparison = rgb1.Substring(rgb1.Length - 2); //get the alpha value of the rgb
                                if (comparison == "00")
                                    pix1t = pixeltAlt.Replace("~rgb~", rgb1);
                                else
                                    pix1t = pixelt.Replace("~rgb~", rgb1);

                                comparison = ""; //reset comparison string
                                if (rgb2.Length == 9) //same as above but for rgb 2
                                    comparison = rgb2.Substring(rgb2.Length - 2);
                                if (comparison == "00")
                                    pix2t = pixeltAlt.Replace("~rgb~", rgb2);
                                else
                                    pix2t = pixelt.Replace("~rgb~", rgb2);
                                comparison = "";
                                if (LastPixel) //used for setup for the final pixel
                                {
                                    if (rgb3.Length == 9)
                                        comparison = rgb3.Substring(rgb3.Length - 2);

                                    if (comparison == "00")
                                        pix3t = pixeltAlt.Replace("~rgb~", rgb3);
                                    else
                                        pix3t = pixelt.Replace("~rgb~", rgb3);
                                }
                            }
                            else
                            {
                                pix1t = pixelt.Replace("~rgb~", rgb1);
                                pix2t = pixelt.Replace("~rgb~", rgb2);
                                if (LastPixel)
                                    pix3t = pixelt.Replace("~rgb~", rgb3);

                            }

                            pix1 += pix1t;
                            pix2 += pix2t;
                            if (LastPixel)
                            {
                                pix1 += pix3t;
                                pix2 += "<#00000000>□\\n"; //sets last pixel to just transparent. Only called when image is an odd number of pixels tall and adds this in to make the image generation work better
                            }



                        }
                        col = col.Replace("~pix1~", pix1) //replaces the variables in col with their appropriate data
                                 .Replace("~pix2~", pix2)
                                 .Replace("~z1~", z1.ToString())
                                 .Replace("~z2~", z2.ToString())
                                 .Replace("~fontsize~", fontsize.ToString())
                                 .Replace("~x~", xstart.ToString());



                        Output += col;
                        xstart += pixsz * 1.1;
                    }

                    if (signBacking)
                    {
                        string SignWall = "\nsign;Furniture;~x~;~z~;0;1;0;0;0; ;1;1;1";
                        double unitConverter = .11 / 3;

                        string signs = "";

                        double signHeight = .5 * .95; //multiplied by a value close to 1 to create more seemless overlap
                        double signWidth = 1 * .95; //same as above

                        double trueSignHeight = .5;
                        double trueSignWidth = 1;


                        if (h % 2 == 1)
                            h++;

                        //Based off of Starting X from above offset to middle of sign - half of fontsize to perfectly allign with image
                        double startingX = (-w * pixsz / 2) + ((trueSignWidth - unitConverter * fontsize) / 2); 

                        //this is still somehow slightly wrong and I have no idea why, but it's never not at least close so eh. May be slightly off depending on Height of image
                        //Based off of Starting Z1 from above. adjusted towards the middle of the sign and adding any offset caused by spacings of new line characters.
                        double startingZ = pixsz + ((trueSignHeight - fontsize * unitConverter) / 2 + (LeftOverNewLineSpace * fontsize * unitConverter * 2)); 


                        if (vshift)
                        {
                            startingZ -= ((h * pixsz * 1.1) / 2) - (fontsize * unitConverter * 1.1) + (LeftOverNewLineSpace * unitConverter * fontsize * 2);

                        }
                        double heightConversion = (h * pixsz * 1.1) / signHeight; //number of signs in Height the image takes up.
                        double widthConversion = (w * pixsz * 1.1) / signWidth; //number of signs in Width the image takes up.

                        for (int x = 0; x < widthConversion; x++)
                        {
                            for (int z = 0; z < heightConversion; z++)
                            {

                                string replaceX;
                                string replaceZ;
                                if (widthConversion - x < 1 && widthConversion - x > 0)
                                {
                                    replaceX = (startingX + signWidth * x - (1 - (signWidth * (widthConversion - x)))).ToString();
                                    Debug.WriteLine($"Offsetting last sign x is {x} widthConversion is {widthConversion} and signWidth * (WC - x) = {signWidth * (widthConversion - x)}");
                                }
                                else
                                    replaceX = (startingX + signWidth * x).ToString();

                                if (heightConversion - z < 1 && heightConversion - z > 0)
                                    replaceZ = (startingZ + signHeight * z - (.5-(signHeight * (heightConversion - z)))).ToString();
                                else
                                    replaceZ = (startingZ + signHeight * z).ToString();


                                signs += SignWall.Replace("~x~", replaceX)
                                   .Replace("~z~", replaceZ); ;

                                if (heightConversion - z <= .01)
                                    z++; //if sign would be placed with almost no variance just ignore that sign.
                            }
                            if (widthConversion - x <= .01)
                                x++; //same for x
                        }
                        Output += signs;
                    }
                }


            }

            
            catch (Exception e)
            {
                Program.ThrowError($"Error: {e.Message}", ErrorLocation.Bottom);
            }

            return Output;
        }


        public static string GetPixelRGB(MagickImage img, int x, int y)
        {

            var pixel = img.GetPixels().GetPixel(x, y);
            string color = pixel.ToColor().ToHexString();

            return color;

        }
    }
}
