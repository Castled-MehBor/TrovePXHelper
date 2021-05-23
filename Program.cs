using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace TrovePXHelper
{
    class Program
    {
        const string Red = "Red";
        const string Orange = "Orange";
        const string Yellow = "Yellow";
        const string Green = "Green";
        const string Blue = "Blue";
        const string Purple = "Purple";
        const string Grey = "Grey";
        const string Primal = "Primal";
        const string Standard = "Standard";
        const string Metallic = "Metallic";
        const string Glass = "Glass";
        const string Glowing = "Glowing";
        const string Special = "Special";
        static bool[] checkerboard = new bool[2];
        static bool checkerWarning = false;
        static readonly Dictionary<string, Color> TroveColor = new Dictionary<string, Color>
    {
        #region Primal Blocks
        {"PrimalRed", Color.FromArgb(155, 39, 39) },
        {"PrimalOrange", Color.FromArgb(255, 148, 25) },
        {"PrimalYellow", Color.FromArgb(243, 211, 2) },
        {"PrimalGreen", Color.FromArgb(0, 128, 0) },
        {"PrimalBlue", Color.FromArgb(47, 72, 184) },
        {"PrimalPurple", Color.FromArgb(74, 48, 126) },
        {"PrimalGrey", Color.FromArgb(136, 136, 136) },
        #endregion
        #region Standard Blocks
        {"MidnightBlue", Color.FromArgb(000, 022, 056) },
        {"DarkBlue", Color.FromArgb(010, 058, 130) },
        {"BusinessBlue", Color.FromArgb(094, 145, 222) },
        {"LightBlue", Color.FromArgb(198, 221, 255) },
        {"BlueBlue", Color.FromArgb(024, 106, 255) },
        {"LaserBlue", Color.FromArgb(016, 213, 255) },
        {"MoarBlue", Color.FromArgb(000, 054, 255) },
        {"BoiledDenim", Color.FromArgb(063, 075, 095) },
        {"DarkBrown", Color.FromArgb(042, 031, 015) },
        {"StillPrettyDarkBrown", Color.FromArgb(073, 057, 035) },
        {"Sepiagram", Color.FromArgb(182, 161, 132) },
        {"AlsoBrown", Color.FromArgb(051, 042, 024) },
        {"Hazelish", Color.FromArgb(103, 095, 073) },
        {"DarkChocolate", Color.FromArgb(033, 029, 022) },
        {"CardboardBox", Color.FromArgb(196, 171, 141) },
        {"KhakiPants", Color.FromArgb(160, 133, 081) },
        {"BrownTown", Color.FromArgb(106, 081, 042) },
        {"DarkGreen", Color.FromArgb(032, 056, 000) },
        {"LimeGreen", Color.FromArgb(131, 189, 049) },
        {"SlimeGreen", Color.FromArgb(168, 222, 094) },
        {"ElectricGreen", Color.FromArgb(000, 255, 210) },
        {"SuperGreen", Color.FromArgb(000, 255, 006) },
        {"Greenyer", Color.FromArgb(000, 138, 003) },
        {"PineGreen", Color.FromArgb(000, 085, 044) },
        {"ArmyMan", Color.FromArgb(073, 099, 055) },
        {"RadioactiveGreen", Color.FromArgb(168, 255, 000) },
        {"MossyGreen", Color.FromArgb(110, 130, 030) },
        {"Charcoal", Color.FromArgb(043, 043, 043) },
        {"RegularOldGrey", Color.FromArgb(164, 164, 164) },
        {"LightGrey", Color.FromArgb(228, 228, 228) },
        {"UmberOrange", Color.FromArgb(152, 084, 011) },
        {"FestiveOrange", Color.FromArgb(239, 166, 089) },
        {"Peachy", Color.FromArgb(234, 216, 188) },
        {"BurntOrange", Color.FromArgb(083, 043, 000) },
        {"ConstructionOrange", Color.FromArgb(221, 114, 000) },
        {"OrangeCreamsicle", Color.FromArgb(255, 201, 117) },
        {"PumpkinOrange", Color.FromArgb(255, 174, 000) },
        {"ReddishOrange", Color.FromArgb(239, 091, 045) },
        {"OrangeSherbet", Color.FromArgb(240, 200, 152) },
        {"SprayTan", Color.FromArgb(201, 152, 095) },
        {"OminousPurple", Color.FromArgb(023, 003, 062) },
        {"DarkPurple", Color.FromArgb(053, 011, 136) },
        {"Violet", Color.FromArgb(137, 092, 227) },
        {"Lilac", Color.FromArgb(217, 199, 255) },
        {"VibrantPurple", Color.FromArgb(156, 000, 255) },
        {"8BitGrape", Color.FromArgb(096, 000, 186) },
        {"PastelPurple", Color.FromArgb(178, 106, 211) },
        {"SeverePeriwinkle", Color.FromArgb(078, 000, 255) },
        {"MagentaMagic", Color.FromArgb(133, 000, 149) },
        {"DarkRed", Color.FromArgb(060, 005, 006) },
        {"CadmiumRed", Color.FromArgb(131, 015, 018) },
        {"SalmonRed", Color.FromArgb(222, 097, 101) },
        {"Pink", Color.FromArgb(255, 199, 201) },
        {"GrandmasLipstick", Color.FromArgb(128, 069, 069) },
        {"RosyPink", Color.FromArgb(255, 075, 075) },
        {"PrettyPink", Color.FromArgb(240, 114, 255) },
        {"Registroxel", Color.FromArgb(228, 000, 255) },
        {"DarkerYellow", Color.FromArgb(056, 049, 000) },
        {"DarkYellow", Color.FromArgb(130, 114, 010) },
        {"ButtercupYellow", Color.FromArgb(189, 170, 049) },
        {"PaleYellow", Color.FromArgb(255, 247, 198) },
        {"YellowyOrange", Color.FromArgb(255, 174, 000) },
        {"YellowMustard", Color.FromArgb(255, 210, 000) },
        {"FastFoodYellow", Color.FromArgb(255, 246, 002) },
        {"ElectricLime", Color.FromArgb(207, 238, 000) },
        {"HoneyMustard", Color.FromArgb(245, 204, 093) },
        {"White", Color.FromArgb(231, 235, 238) },
        {"Gold", Color.FromArgb(255, 255, 085) },
        {"CornerstoneFoundation", Color.FromArgb(066, 061, 062) },
        {"VerdantGreen", Color.FromArgb(083, 175, 020) },
        #endregion
        #region Metallic Blocks
        {"MetalBlueJeans", Color.FromArgb(064, 113, 155) },
        {"BlueSteel", Color.FromArgb(018, 165, 197) },
        {"MechanicBlue", Color.FromArgb(041, 048, 052) },
        {"AutoBodyBlue", Color.FromArgb(035, 051, 168) },
        {"DeepBlueSea", Color.FromArgb(005, 014, 073) },
        {"MetallicBrown", Color.FromArgb(144, 127, 117) },
        {"MetallicGreyBlue", Color.FromArgb(132, 135, 150) },
        {"MetallicPurple", Color.FromArgb(104, 059, 160) },
        {"PolishedPurple", Color.FromArgb(131, 040, 151) },
        {"PolishedPeriwinkle", Color.FromArgb(044, 044, 117) },
        {"MetalMagenta", Color.FromArgb(066, 005, 073) },
        {"MidnightMetal", Color.FromArgb(001, 061, 059) },
        {"MetallicRed", Color.FromArgb(145, 094, 094) },
        {"RedRust", Color.FromArgb(160, 059, 059) },
        {"RustyRouge", Color.FromArgb(073, 005, 005) },
        {"MetallicPink", Color.FromArgb(198, 054, 162) },
        {"MetallicDarkPink", Color.FromArgb(187, 034, 103) },
        {"MetallicDarkOrange", Color.FromArgb(117, 087, 000) },
        {"MetallicGreen", Color.FromArgb(132, 152, 119) },
        {"ShinyGreen", Color.FromArgb(059, 119, 052) },
        {"GlisteningMoss", Color.FromArgb(141, 177, 015) },
        {"MetalCamouflage", Color.FromArgb(094, 100, 072) },
        {"PewterPine", Color.FromArgb(000, 138, 003) },
        {"MetallicRustOrange", Color.FromArgb(167, 137, 073) },
        {"MetallicYellow", Color.FromArgb(224, 205, 076) },
        {"MetallicMustard", Color.FromArgb(182, 165, 049) },
        {"MetallicWhite", Color.FromArgb(243, 248, 250) },
        {"Silver", Color.FromArgb(185, 194, 197) },
        {"BlackIron", Color.FromArgb(013, 013, 013) },
        #endregion
        #region Glass Blocks
        {"BrownGlass", Color.FromArgb(092, 076, 051) },
        {"TransparentBrown", Color.FromArgb(119, 082, 035) },
        {"AlsoTransparentBrown", Color.FromArgb(076, 058, 024) },
        {"FrostedLeather", Color.FromArgb(091, 054, 000) },
        {"PurpleGlass", Color.FromArgb(123, 079, 163) },
        {"CoolMagentaGlass", Color.FromArgb(116, 011, 078) },
        {"GlassyGrape", Color.FromArgb(170, 027, 253) },
        {"LightPurpleGlass", Color.FromArgb(202, 124, 246) },
        {"TransparentPurple", Color.FromArgb(050, 000, 124) },
        {"YellowGlass", Color.FromArgb(208, 191, 049) },
        {"LightYellowGlass", Color.FromArgb(255, 236, 111) },
        {"VibrantYellowGlass", Color.FromArgb(249, 217, 000) },
        {"OrangeGlass", Color.FromArgb(195, 110, 000) },
        {"PumpkinGlass", Color.FromArgb(244, 121, 011) },
        {"PeachyGlaze", Color.FromArgb(228, 165, 108) },
        {"BlueGlass", Color.FromArgb(045, 059, 146) },
        {"SkylightBlue", Color.FromArgb(063, 142, 239) },
        {"MoonRoofBlue", Color.FromArgb(000, 055, 124) },
        {"DarkBlueGlass", Color.FromArgb(026, 041, 066) },
        {"GreenGlass", Color.FromArgb(078, 119, 069) },
        {"SeeThroughGreen", Color.FromArgb(001, 061, 059) },
        {"GrassGlass", Color.FromArgb(076, 151, 056) },
        {"SeaFoam", Color.FromArgb(130, 228, 104) },
        {"LimeGlass", Color.FromArgb(203, 246, 098) },
        {"IcyGreen", Color.FromArgb(019, 134, 141) },
        {"RedGlass", Color.FromArgb(144, 022, 022) },
        {"RevealingRed", Color.FromArgb(106, 002, 002) },
        {"RedSunglasses", Color.FromArgb(045, 000, 000) },
        {"PinkGlass", Color.FromArgb(249, 146, 245) },
        {"PlexiglassPink", Color.FromArgb(255, 010, 166) },
        {"BubblegumGlass", Color.FromArgb(185, 87, 149) },
        {"TurquoiseGlass", Color.FromArgb(111, 177, 185) },
        {"TransparentTurquoise", Color.FromArgb(068, 241, 252) },
        {"WhiteGlass", Color.FromArgb(255, 255, 255) },
        {"GreyGlass", Color.FromArgb(150, 150, 150) },
        {"BlackIce", Color.FromArgb(000, 000, 000) },
        #endregion
        #region Glowing Blocks
        {"GlowingBlue", Color.FromArgb(073, 117, 228) },
        {"GlowJeans", Color.FromArgb(002, 094, 117) },
        {"DeepBlue", Color.FromArgb(020, 061, 087) },
        {"GlowingGreen", Color.FromArgb(108, 249, 053) },
        {"PineBulb", Color.FromArgb(002, 117, 091) },
        {"ToxicNeon", Color.FromArgb(210, 255, 000) },
        {"LuminescentMoss", Color.FromArgb(127, 180, 000) },
        {"GlowingYellow", Color.FromArgb(249, 242, 053) },
        {"MustardLightning", Color.FromArgb(180, 169, 000) },
        {"GlowingPink", Color.FromArgb(245, 050, 234) },
        {"NeonPink", Color.FromArgb(243, 000, 132) },
        {"GlowingRed", Color.FromArgb(246, 059, 059) },
        {"RadiantRust", Color.FromArgb(105, 039, 039) },
        {"GlowingCyan", Color.FromArgb(096, 220, 242) },
        {"GlowingDarkBlue", Color.FromArgb(004, 083, 228) },
        {"GlowingDarkRed", Color.FromArgb(192, 000, 000) },
        {"GlowingOrange", Color.FromArgb(255, 144, 046) },
        {"CreamyOrange", Color.FromArgb(255, 201, 125) },
        {"EmittingOrange", Color.FromArgb(255, 096, 000) },
        {"GlowingPurple", Color.FromArgb(094, 000, 224) },
        {"BrightGrape", Color.FromArgb(134, 000, 248) },
        {"SpooOOookyPurple", Color.FromArgb(057, 000, 128) },
        {"NeonTurquoise", Color.FromArgb(000, 255, 198) },
        {"GlowingWhite", Color.FromArgb(255, 255, 255) }
        #endregion
    };
        static readonly List<BlockRecipe> recipes = new List<BlockRecipe>
        {
            #region Primal
            new BlockRecipe(Primal, Red),
            new BlockRecipe(Primal, Orange),
            new BlockRecipe(Primal, Yellow),
            new BlockRecipe(Primal, Green),
            new BlockRecipe(Primal, Blue),
            new BlockRecipe(Primal, Purple),
            new BlockRecipe(Primal, Grey),
            #endregion
            #region Standard
            new BlockRecipe(Standard, Blue), //Midnight Blue
            new BlockRecipe(Standard, Blue),
            new BlockRecipe(Standard, Blue),
            new BlockRecipe(Standard, Blue),
            new BlockRecipe(Standard, Blue),
            new BlockRecipe(Standard, Blue),
            new BlockRecipe(Standard, Blue),
            new BlockRecipe(Standard, Blue), //Boiled Denum
            new BlockRecipe(Standard, Orange), //Dark Brown
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange), //Brown Town
            new BlockRecipe(Standard, Green), //Dark Green
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green),
            new BlockRecipe(Standard, Green), // Mossy Green
            new BlockRecipe(Standard, Grey), //Charcoal
            new BlockRecipe(Standard, Grey),
            new BlockRecipe(Standard, Grey), // Light Grey
            new BlockRecipe(Standard, Orange), //Umber Orange
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange),
            new BlockRecipe(Standard, Orange), //Spray Tan
            new BlockRecipe(Standard, Purple), //Ominous Purple
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple),
            new BlockRecipe(Standard, Purple), //Magenta Magic
            new BlockRecipe(Standard, Red), //Dark Red
            new BlockRecipe(Standard, Red),
            new BlockRecipe(Standard, Red),
            new BlockRecipe(Standard, Red),
            new BlockRecipe(Standard, Red),
            new BlockRecipe(Standard, Red),
            new BlockRecipe(Standard, Red),
            new BlockRecipe(Standard, Red), // Registroxel
            new BlockRecipe(Standard, Yellow), //Darker Yellow
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow),
            new BlockRecipe(Standard, Yellow), //Honey Mustard
            new BlockRecipe(Special, Grey), //White
            new BlockRecipe(Metallic, Yellow), //Gold
            new BlockRecipe(Metallic, Grey), // Cornerstone Foundation
            new BlockRecipe(Standard, Green), //Verdant Green
            #endregion
            #region Metallic
            new BlockRecipe(Metallic, Blue), //Metal Blue Jeans
            new BlockRecipe(Metallic, Blue),
            new BlockRecipe(Metallic, Blue),
            new BlockRecipe(Metallic, Blue),
            new BlockRecipe(Metallic, Blue), //Deep Sea Blue
            new BlockRecipe(Metallic, Orange), //Metallic Brown
            new BlockRecipe(Metallic, Blue), //Metallic Grey-Blue
            new BlockRecipe(Metallic, Purple), //Metal Purple
            new BlockRecipe(Metallic, Purple),
            new BlockRecipe(Metallic, Purple),
            new BlockRecipe(Metallic, Purple),
            new BlockRecipe(Metallic, Purple), //Midnight Metal
            new BlockRecipe(Metallic, Red), //Metallic Red
            new BlockRecipe(Metallic, Red),
            new BlockRecipe(Metallic, Red),
            new BlockRecipe(Metallic, Red),
            new BlockRecipe(Metallic, Red), //Metallic Dark Pink
            new BlockRecipe(Metallic, Orange), //Metallic Dark Orange
            new BlockRecipe(Metallic, Green), //Metallic Green
            new BlockRecipe(Metallic, Green),
            new BlockRecipe(Metallic, Green),
            new BlockRecipe(Metallic, Green),
            new BlockRecipe(Metallic, Green),//Pewter Pine
            new BlockRecipe(Metallic, Orange), //Metallic Rust Orange
            new BlockRecipe(Metallic, Yellow), //Metallic Yellow
            new BlockRecipe(Metallic, Yellow), //Metallic Mustard
            new BlockRecipe(Metallic, Grey), //Metallic White
            new BlockRecipe(Metallic, Grey),
            new BlockRecipe(Metallic, Grey), //Black Iron
            #endregion
            #region Glass
            new BlockRecipe(Glass, Orange), //Brown Glass
            new BlockRecipe(Glass, Orange),
            new BlockRecipe(Glass, Orange),
            new BlockRecipe(Glass, Orange), //Frosted Leather
            new BlockRecipe(Glass, Purple), //Purple Glass
            new BlockRecipe(Glass, Purple),
            new BlockRecipe(Glass, Purple),
            new BlockRecipe(Glass, Purple),
            new BlockRecipe(Glass, Purple), //Transparent Purple
            new BlockRecipe(Glass, Yellow), //Yellow Glass
            new BlockRecipe(Glass, Yellow),
            new BlockRecipe(Glass, Yellow), //Vibrant Yellow Glass
            new BlockRecipe(Glass, Orange), //Orange Glass
            new BlockRecipe(Glass, Orange),
            new BlockRecipe(Glass, Orange), //Peachy Glaze
            new BlockRecipe(Glass, Blue), //Blue Glass
            new BlockRecipe(Glass, Blue),
            new BlockRecipe(Glass, Blue),
            new BlockRecipe(Glass, Blue), //Dark Blue Glass
            new BlockRecipe(Glass, Green), //Green Glass
            new BlockRecipe(Glass, Green),
            new BlockRecipe(Glass, Green),
            new BlockRecipe(Glass, Green),
            new BlockRecipe(Glass, Green),
            new BlockRecipe(Glass, Green), //Icy Green
            new BlockRecipe(Glass, Red), //Red Glass
            new BlockRecipe(Glass, Red),
            new BlockRecipe(Glass, Red),
            new BlockRecipe(Glass, Red),
            new BlockRecipe(Glass, Red),
            new BlockRecipe(Glass, Red), //Bubblegum Glass
            new BlockRecipe(Glass, Blue), //Turquoise Glass
            new BlockRecipe(Glass, Blue), //Transparent Turquoise
            new BlockRecipe(Glass, Grey), //White Glass
            new BlockRecipe(Glass, Grey),
            new BlockRecipe(Glass, Grey), //Black Ice
            #endregion
            #region Glowing
            new BlockRecipe(Glowing, Blue), //Glowing Blue
            new BlockRecipe(Glowing, Blue),
            new BlockRecipe(Glowing, Blue), //Deep Blue
            new BlockRecipe(Glowing, Green), //Glowing Green
            new BlockRecipe(Glowing, Green),
            new BlockRecipe(Glowing, Green),
            new BlockRecipe(Glowing, Green), //Luminescent Moss
            new BlockRecipe(Glowing, Yellow), //Glowing Yellow
            new BlockRecipe(Glowing, Yellow), //Mustard Lightning
            new BlockRecipe(Glowing, Red), //Glowing Pink
            new BlockRecipe(Glowing, Red),
            new BlockRecipe(Glowing, Red),
            new BlockRecipe(Glowing, Red), //Radiant Rust
            new BlockRecipe(Glowing, Blue), //Glowing Cyan
            new BlockRecipe(Glowing, Blue), //Glowing Dark Blue
            new BlockRecipe(Glowing, Red), //Glowing Dark Red
            new BlockRecipe(Glowing, Orange), //Glowing Orange
            new BlockRecipe(Glowing, Orange),
            new BlockRecipe(Glowing, Orange), //Emitting Orange
            new BlockRecipe(Glowing, Purple), //Glowing Orange
            new BlockRecipe(Glowing, Purple),
            new BlockRecipe(Glowing, Purple), //Spooky Orange
            new BlockRecipe(Glowing, Blue), //Neon Turquoise
            new BlockRecipe(Glowing, Grey), //Glowing White

            #endregion
        };
        static readonly List<string> IntroductoryLines = new List<string>
        {
            "Made by: Castledking2341",
            "Discord - Castledking2341#2006",
            "- - -",
            "This software will attempt to find the bitmap file that you type the file name of,",
            "and create multiple bitmap files, or 'blueprints' using block colors found in Trove.",
            "All of the files will be put into a folder within ImageOutput with a random number.",
            "As a bonus, a text file will also be generated,",
            "giving the  amount of materials needed to create the pixel art in-game.",
            "As well as this, a palette comparison image will be created.",
            "You may also apply a checkerboard layer for each blueprint for easier block/block placement.",
            "- - -"
        };
        static void Main(string[] args)
        {
            InitialAction(new bool[2] { true, false }, "");
        }
        public static void InitialAction(bool[] introduction, string path)
        {
            bool fail = false;
            if (introduction[0])
            {
                foreach (string s in IntroductoryLines)
                    Console.WriteLine(s);
            }
            if (introduction[1])
            {
                Console.WriteLine($"Operation finished: Output in path '{path}'");
                if (checkerWarning)
                {
                    Console.WriteLine("Total pixel count was too large to perform checkerboard layering.");
                    checkerWarning = false;
                }
                Console.WriteLine(string.Empty);
            }
            Console.WriteLine("File Name: ");
            string name = Console.ReadLine();
            if (!File.Exists(name))
            {
                Console.WriteLine("File does not exist.");
                fail = true;
                InitialAction(new bool[2] { false, false }, "");
            }
            if (!fail)
            {
                if (!checkerboard[0])
                {
                    Console.WriteLine("Checkerboard Layering? (Y/N, defaults to no)");
                    Console.WriteLine("Input will affect any future outputs during this session, and this will not be asked again.");
                    string yn = Console.ReadLine();
                    if (yn == "y" || yn == "yes")
                        checkerboard[1] = true;
                    checkerboard[0] = true;
                }
                Console.WriteLine("Creating blueprints...");
                ConvIMG((Bitmap)Image.FromFile(name), name.Remove(name.Length - 4));
            }
        }
        public static void ConvIMG(Bitmap bmp, string name)
        {
            try
            {
                string number = $"{new Random().Next(0, 999999)}";
                Bitmap clone = new Bitmap(bmp.Width, bmp.Height);
                Color[] array = new Color[bmp.Width * bmp.Height];
                Directory.CreateDirectory($"ImageOutput/{name}{number}");
                GetData(bmp, array);
                //Create palettes
                Color[] palette = Palette(array);
                Color[] tPal = Clone(palette);
                //Convert Trove Palette colors
                for (int a = 0; a < tPal.Length; a++)
                    tPal[a] = tPal[a] == Color.Transparent ? Color.Transparent : SetTroveColor(tPal[a]);
                //Convert original color array to Trove colors
                Dictionary<Color, Color> reference = new Dictionary<Color, Color>();
                for (int a = 0; a < palette.Length; a++)
                    if (!reference.ContainsKey(palette[a]))
                        reference.Add(palette[a], tPal[a]);
                CheckPalettes(palette, tPal, "Palettes" + number, $"{name}{number}");
                for (int a = 0; a < array.Length; a++)
                    if (array[a] != Color.Transparent)
                        if (reference.ContainsKey(array[a]))
                            array[a] = reference[array[a]];
                //Create images: Layers, then entire image
                SetData(clone, array);
                ExportTexture(clone, "Complete" + number, $"{name}{number}");
                foreach (Color c in tPal)
                {
                    List<Color> check = new List<Color>();
                    if (!check.Contains(c))
                    {
                        check.Add(c);
                        if (array.Length >= 7500)
                            checkerWarning = true;
                        if (c != Color.Transparent)
                            CheckerboardLayer(c, clone.Width, clone.Height, number);
                    }
                }
                MaterialsTxt(tPal, array, number, $"ImageOutput/{name}{number}");
                Console.Clear();
                InitialAction(new bool[2] { true, true }, $"ImageOutput/{name}{number}");
                void CheckerboardLayer(Color indexer, int width, int height, string num)
                {
                    Bitmap bitmap = new Bitmap(width, height);
                    Color[] arr = Clone(array);
                    Color[] checker = checkerboard[1] && arr.Length < 7500 ? Checkerboard(arr.Length) : new Color[arr.Length];
                    for (int a = 0; a < arr.Length; a++)
                        if (arr[a] != indexer)
                            arr[a] = Color.FromArgb(0, 0, 0, 0);
                    for (int a = 0; a < arr.Length; a++)
                    {
                        if (arr[a] == indexer)
                            checker[a] = indexer;
                    }
                    SetData(bitmap, checker);
                    ExportTexture(bitmap, GetKey(indexer) + num, $"{name}{number}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has occured that has prevented the operation from being performed: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Gets the name of the color within TroveColors, otherwise returns string.Empty
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static string GetKey(Color c)
        {
            foreach (string s in TroveColor.Keys)
            {
                if (TroveColor[s] == c)
                    return s;
            }
            return string.Empty;
        }
        static void MaterialsTxt(Color[] palette, Color[] board, string name, string directory)
        {
            int[] material = new int[8];
            string[] primalName = new string[8] { "Primal Red", "Primal Orange", "Primal Yellow", "Primal Green", "Primal Blue", "Primal Purple", "Primal Grey", "Formicite Ore" };
            List<string> lines = new List<string>();
            List<MaterialListing> materials = new List<MaterialListing>();
            foreach (Color c in palette)
            {
                if (c != Color.Transparent)
                {
                    BlockRecipe data = GetRecipe(c);
                    materials.Add(new MaterialListing(c, data.colorType));
                    ScourBoard(c, data);
                }
            }
            foreach (MaterialListing listing in materials)
            {
                BlockRecipe data = GetRecipe(listing.identifier);
                string enclosedText = $"({Insertion(1)}{Insertion(2)})";
                if (enclosedText != "()")
                    lines.Add($"{GetKey(listing.identifier)} {enclosedText}");
                material[BlockType(listing)] += listing.materials[MaterialListing.Block];
                material[7] += listing.materials[MaterialListing.Formicite];
                string Insertion(int type)
                {
                    switch (type)
                    {
                        case 1:
                            if (listing.materials[MaterialListing.Block] > 0)
                                return BlockName();
                            break;
                        case 2:
                            if (listing.materials[MaterialListing.Formicite] > 0)
                                return $", {listing.materials[MaterialListing.Formicite]} Formicite Ore";
                            break;
                    }
                    return string.Empty;
                }
                string BlockName()
                {
                    if (data.blockType == Primal)
                        return $"{listing.materials[MaterialListing.Block]}";
                    return $"{primalName[BlockType(listing)]} x {listing.materials[MaterialListing.Block]}";
                }
            }
            for (int a = 0; a < material.Length; a++)
            {
                if (material[a] > 0)
                    lines.Add($"Total {primalName[a]}: {material[a]}");
            }
            void ScourBoard(Color check, BlockRecipe data)
            {
                MaterialListing listing = Data();
                int[] additive = new int[2] { 0, 0 };
                foreach (Color c in board)
                {
                    if (c == check)
                    {
                        additive[1]++;
                        if (additive[1] > (IsFormiciteType(data) ? 2 : 0))
                        {
                            AddValue();
                            additive[1] = 0;
                        }
                    }
                }
                if (IsFormiciteType(data) && additive[1] < 3)
                    AddValue();
                void AddValue()
                {
                    switch (data.blockType)
                    {
                        case Primal:
                            listing.materials[MaterialListing.Block]++;
                            break;
                        case Standard:
                            listing.materials[MaterialListing.Block]++;
                            break;
                        case Metallic:
                            {
                                listing.materials[MaterialListing.Block] += 3;
                                listing.materials[MaterialListing.Formicite]++;
                            }
                            break;
                        case Glass:
                            {
                                listing.materials[MaterialListing.Block] += 3;
                                listing.materials[MaterialListing.Formicite]++;
                            }
                            break;
                        case Glowing:
                            {
                                listing.materials[MaterialListing.Block] += 3;
                                listing.materials[MaterialListing.Formicite] += 2;
                            }
                            break;
                    }
                }
                MaterialListing Data()
                {
                    foreach (MaterialListing m in materials)
                        if (m.identifier == check)
                            return m;
                    return null;
                }
            }
            int BlockType(MaterialListing data)
            {
                switch (data.color)
                {
                    case Red:
                        return 0;
                    case Orange:
                        return 1;
                    case Yellow:
                        return 2;
                    case Green:
                        return 3;
                    case Blue:
                        return 4;
                    case Purple:
                        return 5;
                    case Grey:
                        return 6;
                }
                return 0;
            }
            using (StreamWriter file = File.CreateText($"{directory}/Materials{name}.txt"))
            {
                foreach (string line in lines)
                    file.WriteLine(line);
            }
        }
        static bool IsFormiciteType(BlockRecipe data) => data.blockType == Metallic || data.blockType == Glass || data.blockType == Glowing;
        static BlockRecipe GetRecipe(Color indexer)
        {
            int adding = 0;
            foreach (Color check in TroveColor.Values)
            {
                adding++;
                if (check == indexer)
                    return recipes[adding - 1];
            }
            return null;
        }
        static void CheckPalettes(Color[] palette1, Color[] palette2, string name, string directory)
        {
            Bitmap tex = new Bitmap(palette1.Length, 2);
            Color[] array = new Color[palette1.Length + palette2.Length];
            for (int a = 0; a < palette1.Length; a++)
                array[a] = palette1[a];
            for (int a = palette1.Length; a < array.Length; a++)
                array[a] = palette2[a - palette2.Length];
            SetData(tex, array);
            ExportTexture(tex, name, directory);
        }
        static void ExportTexture(Bitmap tex, string name, string directory)
        {
            using (FileStream stream = File.Create($"ImageOutput/{directory}/{DuplicateFileName(name)}.bmp"))
                tex.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            #region
            /*            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            tex.Save($"ImageOutput/{directory}/{name}.jpg", myImageCodecInfo, myEncoderParameters);
            ImageCodecInfo GetEncoderInfo(String mimeType)
            {
                int j;
                ImageCodecInfo[] encoders;
                encoders = ImageCodecInfo.GetImageEncoders();
                for (j = 0; j < encoders.Length; ++j)
                {
                    if (encoders[j].MimeType == mimeType)
                        return encoders[j];
                }
                return null;
            }
            */
            #endregion
        }
        static string DuplicateFileName(string name)
        {
            string current = (string)name.Clone();
            int count = 1;
            if (File.Exists(name))
            {
                Dir();
                void Dir()
                {
                    current = (string)name.Clone();
                    name.Insert(name.Length, $" ({count})");
                    count++;
                    if (Directory.Exists(name))
                        Dir();
                }
            }
            return current;
        }
        static Color[] Checkerboard(int length)
        {
            //int[] run = new int[2] { 0, 0 };
            int run1 = 0;
            int run2 = 0;
            Color[] output = new Color[length];
            Check();
            return output;
            void Check()
            {
                if (run2++ > 1)
                {
                    run2 = 0;
                    output[run1] = Color.Black;
                }
                else
                    output[run1] = Color.Transparent;
                if (run1++ < length - 1)
                    Check();
            }
        }
        static Color SetTroveColor(Color color)
        {
            int[] cycles = new int[2] { 0, 30 };
            Color output = Color.Transparent;
            CheckColor(cycles[1]);
            return output;
            void CheckColor(int intensity)
            {
                foreach (Color c in TroveColor.Values)
                {
                    if (color != Color.FromArgb(0, 0, 0, 0) && SimilarColor(color, c, cycles[1]))
                    {
                        output = c;
                        break;
                    }
                }
                if (output == Color.Transparent && cycles[0] < 5)
                {
                    cycles[1] += 5;
                    cycles[0]++;
                    CheckColor(cycles[1]);
                }
            }
        }
        static Color[] Clone(Color[] array)
        {
            Color[] output = new Color[array.Length];
            for (int a = 0; a < array.Length; a++)
                output[a] = array[a];
            return output;
        }
        /// <summary>
        /// Applies the Color[] array to the Bitmap
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="colors"></param>
        static void SetData(Bitmap bmp, Color[] colors)
        {
            int[] coorStart = new int[2];
            for (int a = 0; a < colors.Length; a++)
            {
                if (coorStart[0] >= bmp.Width)
                {
                    coorStart[0] = 0;
                    if (coorStart[1] <= bmp.Height - 2)
                        coorStart[1]++;
                }
                bmp.SetPixel(coorStart[0], coorStart[1], Color.Transparent);
                coorStart[0]++;
            }
            int[] coor = new int[2];
            for (int a = 0; a < colors.Length; a++)
            {
                if (coor[0] >= bmp.Width)
                {
                    coor[0] = 0;
                    if (coor[1] <= bmp.Height - 2)
                        coor[1]++;
                }
                bmp.SetPixel(coor[0], coor[1], colors[a]);
                coor[0]++;
            }
        }
        /// <summary>
        /// Gets all colors within the Bitmap, and applies them to the Color[] array
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="colors"></param>
        static void GetData(Bitmap bmp, Color[] colors)
        {
            for (int a = 0; a < colors.Length; a++)
                colors[a] = Color.Transparent;
            int[] coor = new int[2];
            for (int a = 0; a < colors.Length; a++)
            {
                if (coor[0] >= bmp.Width)
                {
                    coor[0] = 0;
                    if (coor[1] <= bmp.Height - 2)
                        coor[1]++;
                }
                colors[a] = bmp.GetPixel(coor[0], coor[1]);
                coor[0]++;
            }
        }
        /// <summary>
        /// Creates a palette with the given color array: an array that contains one of every unique color within the array
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static Color[] Palette(Color[] arr)
        {
            Color[] array = new Color[0];
            List<Color> colors = new List<Color>();
            foreach (Color c in arr)
            {
                if (!colors.Contains(c))
                    colors.Add(c);
            }
            Array.Resize(ref array, colors.Count);
            for (int a = 0; a < colors.Count; a++)
                array[a] = colors[a];
            return array;
        }
        static bool SimilarColor(Color compare, Color subject, int power) => RangeValue(subject.R, compare.R, power) && RangeValue(subject.G, compare.G, power) && RangeValue(subject.B, compare.B, power);
        static bool RangeValue(byte value1, byte value2, int power) => value1 >= value2 - power && value1 <= value2 + power;
        internal class BlockRecipe
        {
            public string blockType;
            public string colorType;
            public BlockRecipe(string b, string c) { blockType = b; colorType = c; }
        }
        internal class MaterialListing
        {
            public const int Block = 0;
            public const int Formicite = 1;
            public Color identifier;
            public string color;
            public int[] materials = new int[2];
            public MaterialListing(Color i, string c) { identifier = i; color = c; }
        }
    }
}
