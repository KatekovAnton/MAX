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
    public struct typhdr
    {
        public char[] id;
        public int diroffset;
        public int dirlength;
    }

    public struct typdiritem
    {
        public char[] name;
        public int offset;
        public int size;
    }

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

        public static void maxresunpak(string from, string tof)
        {
            int f = 0;
            BinaryReader inf;
            typdiritem[] dir;
            typhdr hdr;
            string path = SystemConfiguration.AppPath + tof;
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            System.IO.FileStream str1 = new System.IO.FileStream(from, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

            inf = new System.IO.BinaryReader(str1);
            hdr.id = inf.ReadChars(4);
            hdr.diroffset = inf.ReadInt32();
            hdr.dirlength = inf.ReadInt32();

            inf.BaseStream.Seek(Convert.ToInt64(hdr.diroffset), SeekOrigin.Begin);

            dir = new typdiritem[hdr.dirlength / 16];

            for (f = 0; f < dir.Length; f++)
            {
                dir[f].name = inf.ReadChars(8);
                dir[f].offset = inf.ReadInt32();
                dir[f].size = inf.ReadInt32();
            }

            for (f = 0; f < dir.Length; f++)
            {
                inf.BaseStream.Seek(Convert.ToInt64(dir[f].offset), SeekOrigin.Begin);

                string filename = path + "\\" + new string(dir[f].name);
                filename = filename.TrimEnd('\0');
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                System.IO.FileStream strCur = new System.IO.FileStream(filename, (System.IO.File.Exists(filename) ? System.IO.FileMode.Create : 0) | System.IO.FileMode.CreateNew);
                System.IO.BinaryWriter bw = new System.IO.BinaryWriter(strCur);
                byte[] data = inf.ReadBytes(dir[f].size);
                bw.Write(data);
                bw.Flush();
                bw.Close();
            }
            inf.Close();

        }
        
        public static void convertAll(string path)
        {
            //string[] filenames = System.IO.Directory.GetFiles(SystemConfiguration.AppPath + path);
            /* for (int i = 1427; i < filenames.Length; i++)
                 if (isImagePaletted(filenames[i]))
                     convertPalettedImage(filenames[i]);
                 else
                     convertSimpleImage(filenames[i]);*/
            FileStream str1 = new FileStream("D:\\GAME\\MAX\\MAXNew\\MAXNew\\MAXNew\\bin\\x86\\Debug\\unpacked\\ALNTANK", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            BinaryReader inf = new BinaryReader(str1);
            LoadMultiImage(inf);
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

        public static void convertSimpleImage(string name)
        {
            System.IO.FileStream str1 = new System.IO.FileStream(name, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            BinaryReader source = new System.IO.BinaryReader(str1);
            if (source.BaseStream.Length == 0)
            {
                source.Close();
                return;
            }


            ushort width = source.ReadUInt16();
            ushort height = source.ReadUInt16();
            if ((width > max_width || height > max_height) || (width * height == 0))
            {
                source.Close();
                return;
            }

            short center_x = source.ReadInt16();
            short center_y = source.ReadInt16();

            int img_size = width * height;
            byte[] pixels = source.ReadBytes(img_size);

            System.Drawing.Bitmap bt = new System.Drawing.Bitmap(width, height);


            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    int pixelnumber = j * Convert.ToInt32(width) + i;
                    int colornumber = pixels[pixelnumber];
                    bt.SetPixel(i, j, System.Drawing.Color.FromArgb(Palette.default_palette[colornumber][0], Palette.default_palette[colornumber][1], Palette.default_palette[colornumber][2]));
                }
            string path = SystemConfiguration.AppPath + "\\finished";

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string d = name.Replace("\\unpacked", "\\finished") + ".png";
            bt.Save(d, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static void convertPalettedImage(string name)
        {
            FileStream str1 = new FileStream(name, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
            BinaryReader inf = new BinaryReader(str1);
            if (inf.BaseStream.Length == 0)
            {
                inf.Close();
                return;
            }

            int f = inf.ReadInt32();
            if (f != 0)
            {
                inf.Close();
                return;
            }

            short w = inf.ReadInt16();
            short h = inf.ReadInt16();

            byte[] pixels = new byte[w * h];
            byte[] pallete = inf.ReadBytes(pal_size);

          
            MemoryStream dest = new MemoryStream(pixels);
            short block_size;
            byte buf;
            byte[] fill;
            short m1 = -1;

            while (dest.Position < dest.Length)
            {
                block_size = inf.ReadInt16();

                if (block_size > 0)
                    dest.Write(inf.ReadBytes(block_size), 0, block_size);
                else
                {
                    block_size = Convert.ToInt16((int)m1 * (int)block_size);
                    buf = inf.ReadByte();

                    fill = new byte[block_size];
                    for (int i = 0; i < block_size; i++)
                        fill[i] = buf;

                    dest.Write(fill, 0, fill.Length);
                }
            }
            System.Drawing.Bitmap bt = new System.Drawing.Bitmap(w, h);


            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int colornumber = pixels[j * w + i];
                    bt.SetPixel(i, j, System.Drawing.Color.FromArgb(pallete[colornumber * 3], pallete[colornumber * 3 + 1], pallete[colornumber * 3 + 2]));
                }

            string path = SystemConfiguration.AppPath + "\\finished";

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string newName = name.Replace("\\unpacked", "\\finished") + ".png";
            bt.Save(newName, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static void LoadFrame(BinaryReader source, int index, GraphicUnit target)
        {
            byte[] pixels;

            ushort width = source.ReadUInt16();
            ushort height = source.ReadUInt16();
            short center_x = source.ReadInt16();
            short center_y = source.ReadInt16();

            target.frames[index].centerDelta.X = center_x;
            target.frames[index].centerDelta.Y = center_y;
 

            int size = width * height;
            if (size == 0)
                return;

            pixels = new byte[size];

            // Rows offsets.
            uint[] rows = new uint[height];

            byte[] rowbytes = source.ReadBytes(rows.Length * 4);
            Buffer.BlockCopy(rowbytes, 0, rows, 0, rowbytes.Length);

            MemoryStream dest = new MemoryStream(pixels);

            byte buf;

            for (int i = 0; i < rows.Length;i++ )
            {
                source.BaseStream.Seek(rows[i],SeekOrigin.Begin);
                buf = source.ReadByte();

                while (buf != 0xff)
                {
                    dest.Seek(buf,SeekOrigin.Current);
                    buf = source.ReadByte();
                    dest.Write(source.ReadBytes(buf), 0, buf);
                    buf = source.ReadByte();
                }

                int new_pos = (i + 1) * width;
                
                dest.Seek(new_pos, SeekOrigin.Begin);
            }
            
            target.textures[index] = GraphicTools.TextureFromIndexAndDefaultPalette(width, height, pixels);
        }

        public static GraphicUnit LoadMultiImage(BinaryReader inf)
        {
            byte[] buf = inf.ReadBytes((int)inf.BaseStream.Length);
            short picCount = (short)(buf[0] + 256 * buf[1]);
            if (inf.BaseStream.Length < Convert.ToInt64(picCount) * 12 + 2)
                return null;
            int[] picbounds = new int[picCount];

            for (int picIndex = 0; picIndex < picCount; picIndex++)
            {
                picbounds[picIndex] = 
                    buf[2 + picIndex * 4] +
                    256 * buf[3 + picIndex * 4] + 
                    65536 * (buf[4 + picIndex * 4] + 256 * buf[5 + picIndex * 4]);

                if (picbounds[picIndex] > inf.BaseStream.Length)
                    return null;
            }


            GraphicUnit gu = new GraphicUnit(picCount);
            for (int picIndex = 0; picIndex < picCount; picIndex++)
            {
                inf.BaseStream.Seek(picbounds[picIndex], SeekOrigin.Begin);
                LoadFrame(inf, picIndex, gu);
            }


            return gu;
        }
    }
}
