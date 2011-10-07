﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.TextureCache
{
    public class MAXRESImageProvider
    {
        private struct typhdr
        {
            public char[] id;
            public int diroffset;
            public int dirlength;
        }

        private struct typdiritem
        {
            public string name;
            public int offset;
            public int size;
        }

        private BinaryReader inf;
        private typdiritem[] dir;
        private typhdr hdr;

        const int pal_size = 0x300;
        public static MAXRESImageProvider Instance;

        public MAXRESImageProvider()
        {
            Instance = this;
            maxresunpak(SystemConfiguration.AppPath + "\\data\\Max.res");
        }

        public int findImage(string name)
        {
            int index = -1;
            for (int i = 0; i < dir.Length; i++)
                if (name.CompareTo(dir[i].name) == 0)
                {
                    index = i;
                    break;
                }
            if (index == -1)
                throw new Exception("image not found \"" + name + "\"!!!");

            return index;
        }

        public Texture2D loadSimpleImage(string name)
        {
            int index = findImage(name);
            inf.BaseStream.Seek(dir[index].offset, SeekOrigin.Begin);
            return convertSimpleImage(inf);
        }

        public Texture2D loadPalettedImage(string name)
        {
            int index = findImage(name);
            inf.BaseStream.Seek(dir[index].offset, SeekOrigin.Begin);
            return convertPalettedImage(inf);
        }

        public MAXNew.Game.Graphic.GraphicUnit loadMultiImage(string name)
        {
            int index = findImage(name);
            inf.BaseStream.Seek(dir[index].offset, SeekOrigin.Begin);
            return convertMultiImage(inf, dir[index].size);
        }

        private void maxresunpak(string from)
        {
            System.IO.FileStream str1 = new System.IO.FileStream(from, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

            inf = new System.IO.BinaryReader(str1);
            hdr.id = inf.ReadChars(4);
            hdr.diroffset = inf.ReadInt32();
            hdr.dirlength = inf.ReadInt32();

            inf.BaseStream.Seek(Convert.ToInt64(hdr.diroffset), SeekOrigin.Begin);

            dir = new typdiritem[hdr.dirlength / 16];

            for (int f = 0; f < dir.Length; f++)
            {
                dir[f].name = new string( inf.ReadChars(8));
                if (dir[f].name.IndexOf('6') != -1)
                {
                    int a = 0;
                    a++;
                }
                dir[f].offset = inf.ReadInt32();
                dir[f].size = inf.ReadInt32();
            }
        }

        ~MAXRESImageProvider()
        {
            inf.Close();
        }

        private Texture2D convertSimpleImage(BinaryReader source)
        {
            ushort width = source.ReadUInt16();
            ushort height = source.ReadUInt16();

            short center_x = source.ReadInt16();
            short center_y = source.ReadInt16();

            int img_size = width * height;
            byte[] pixels = source.ReadBytes(img_size);

            return MAXNew.Tools.GraphicTools.TextureFromIndexAndDefaultPalette(width, height, pixels);
        }

        private Texture2D convertPalettedImage(BinaryReader inf)
        {
            int f = inf.ReadInt32();
            if (f != 0)
                throw new Exception("f!=0!!!!!");

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
            return MAXNew.Tools.GraphicTools.TextureFromIndexAndPalette(w, h, pixels, pallete);
        }

        private void LoadFrame(BinaryReader source, int index, MAXNew.Game.Graphic.GraphicUnit target, long baseOffset)
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

            for (int i = 0; i < rows.Length; i++)
            {
                source.BaseStream.Seek(rows[i] + baseOffset, SeekOrigin.Begin);
                buf = source.ReadByte();

                while (buf != 0xff)
                {
                    dest.Seek(buf, SeekOrigin.Current);
                    buf = source.ReadByte();
                    dest.Write(source.ReadBytes(buf), 0, buf);
                    buf = source.ReadByte();
                }

                int new_pos = (i + 1) * width;

                dest.Seek(new_pos, SeekOrigin.Begin);
            }

            target.textures[index] = MAXNew.Tools.GraphicTools.TextureFromIndexAndDefaultPalette(width, height, pixels);
        }

        private MAXNew.Game.Graphic.GraphicUnit convertMultiImage(BinaryReader inf, int length)
        {
            long baseOffset = inf.BaseStream.Position;
            byte[] buf = inf.ReadBytes(length);
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


            MAXNew.Game.Graphic.GraphicUnit gu = new MAXNew.Game.Graphic.GraphicUnit(picCount);
            for (int picIndex = 0; picIndex < picCount; picIndex++)
            {
                inf.BaseStream.Seek(picbounds[picIndex] + baseOffset, SeekOrigin.Begin);
                LoadFrame(inf, picIndex, gu, baseOffset);
            }


            return gu;
        }
    }
}