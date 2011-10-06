using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Microsoft.Xna.Framework.Graphics;

using MAXNew;
using MAXNew.Game;
using MAXNew.Game.Graphic;

namespace MAXNew.Tools
{
    

    public sealed class MaxRes
    {
        const int pal_size = 0x300;
        const int max_width = 640;
        const int max_height = 480;

        public static Map loadWrl(string name)
        {
            Map map = new Map();
            System.IO.FileStream str1 = new System.IO.FileStream(name, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

            BinaryReader inf = new System.IO.BinaryReader(str1);
            map.name = new string(inf.ReadChars(5));
            map.w = inf.ReadInt16();
            map.h = inf.ReadInt16();
            map.minimap = inf.ReadBytes(map.w * map.h);
            byte[] bytes = inf.ReadBytes(map.w * map.h * 2);
            map.map = new short[map.w * map.h];
            Buffer.BlockCopy(bytes, 0, map.map, 0, map.w * map.h * 2);
            map.elementCount = inf.ReadInt16();
            map.mapElements = new byte[map.elementCount][];
            for (int i = 0; i < map.elementCount; i++)
                map.mapElements[i] = inf.ReadBytes(64 * 64);

            map.palette = inf.ReadBytes(pal_size);
            map.groundType = inf.ReadBytes(map.elementCount);

            return map;
        }

        
        
        public static void convertAll(string path)
        {
            //string[] filenames = System.IO.Directory.GetFiles(SystemConfiguration.AppPath + path);
            /* for (int i = 1427; i < filenames.Length; i++)
                 if (isImagePaletted(filenames[i]))
                     convertPalettedImage(filenames[i]);
                 else
                     convertSimpleImage(filenames[i]);*/
           // FileStream str1 = new FileStream("D:\\GAME\\MAX\\MAXNew\\MAXNew\\MAXNew\\bin\\x86\\Debug\\unpacked\\ALNTANK", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
           // BinaryReader inf = new BinaryReader(str1);
          //  LoadMultiImage(inf);
        }

        public static bool isImagePaletted(string name)
        {
            System.IO.FileStream str1 = new System.IO.FileStream(name, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            BinaryReader inf = new System.IO.BinaryReader(str1);

            if (inf.BaseStream.Length == 0)
            {
                inf.Close();
                return false;
            }
            int f = inf.ReadInt32();
            inf.Close();

            return f == 0;
        }

        
    }
}
