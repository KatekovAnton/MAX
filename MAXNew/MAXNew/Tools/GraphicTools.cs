﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MAXNew.Tools
{
    public sealed class GraphicTools
    {
        public static void palshiftu(Color[] pal, int s, int e)
        {
            Color cl = pal[e];
            for (int i = e; i >= s + 1; i--)
                pal[i] = pal[i - 1];
            pal[s] = cl;
        }

        public static void palshiftd(Color[] pal, int s, int e)
        {
            Color cl = pal[s];
            for (int i = s; i <= e - 1; i++)
                pal[i] = pal[i + 1];
            pal[e] = cl;
        }

        public static void animatePalette(Color[] thepal)
        {
            palshiftd(thepal, 9, 12);//3
            palshiftu(thepal, 13, 16);//3
            palshiftu(thepal, 17, 20);//3
            palshiftu(thepal, 21, 24);//3

            palshiftu(thepal, 25, 30);//5
            //palblnkd(thepal, 31, 1 - frac(gct), gclgreen);

            palshiftu(thepal, 96, 102);//6
            palshiftu(thepal, 103, 109);//6
            palshiftu(thepal, 110, 116);//6
            palshiftu(thepal, 117, 122);//5
            palshiftu(thepal, 123, 127);//4
        }

        public static Texture2D[] CreatePalette(byte[] palette)
        {
            //30
            Color[] colors = new Color[256];
            for (int i = 0; i < colors.Length; i++)
                colors[i] = new Microsoft.Xna.Framework.Color(palette[i * 3], palette[i * 3 + 1], palette[i * 3 + 2]);
            Texture2D[] result = new Texture2D[30];
            for(int i = 0;i<30;i++)
            {
                result[i] = new Texture2D(Game1.device, 256, 1);
                result[i].SetData(colors);
                if (i != 29)
                    GraphicTools.animatePalette(colors);
            }
            return result;
        }

        public static Texture2D TextureIndexedFromIndexes(int w, int h, byte[] indexes)
        {
            Texture2D result = new Texture2D(Game1.device, w, h, false, SurfaceFormat.Color);
            int[] datares = new int[indexes.Length];
            for (int i = 0; i < datares.Length; i++)
                datares[i] = (int)indexes[i];
            result.SetData(datares);
            return result;
        }

        public static Texture2D TextureFromIndexAndPalette(int w, int h, byte[] indexes, byte[] palette)
        {
            Texture2D result = new Texture2D(Game1.device, w, h, false, SurfaceFormat.Color);
            Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[w * h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int colornumber = indexes[j * w + i];
                    colors[j * w + i] = new Microsoft.Xna.Framework.Color(palette[colornumber * 3], palette[colornumber * 3 + 1], palette[colornumber * 3 + 2]);
                }
            result.SetData(colors);
            return result;
        }

        public static Texture2D TextureFromIndexAndDefaultPalette(int w, int h, byte[] indexes)
        {
            Texture2D result = new Texture2D(Game1.device, w, h, false, SurfaceFormat.Color);
            Microsoft.Xna.Framework.Color[] colors = new Microsoft.Xna.Framework.Color[w * h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int colornumber = indexes[j * w + i];
                    colors[j * w + i] = new Microsoft.Xna.Framework.Color(Palette.default_palette[colornumber][0], Palette.default_palette[colornumber][1], Palette.default_palette[colornumber][2], colornumber == 0 ? 0 : 255);
                }
            result.SetData(colors);
            return result;
        }
    }

    public sealed class Palette
    {
        public static byte[][] default_palette = new byte[][]
        {
        new byte[]{0x00, 0x00, 0x00, 0x00}, //0
        new byte[]{0xff, 0x00, 0x00, 0x00}, //1
        new byte[]{0x00, 0xff, 0x00, 0x00}, //2
        new byte[]{0x00, 0x00, 0xff, 0x00}, //3
        new byte[]{0xff, 0xff, 0x00, 0x00}, //4
        new byte[]{0xff, 0xab, 0x00, 0x00}, //5
        new byte[]{0x83, 0x83, 0xa3, 0x00}, //6
        new byte[]{0xff, 0x47, 0x00, 0x00}, //7
        new byte[]{0xff, 0xff, 0x93, 0x00}, //8

        new byte[]{0xff, 0xff, 0xff, 0x00}, //9
        new byte[]{0xff, 0xff, 0xff, 0x00}, //10
        new byte[]{0xff, 0xff, 0xff, 0x00}, //11
        new byte[]{0xff, 0xff, 0xff, 0x00}, //12

        new byte[]{0xff, 0xff, 0xff, 0x00}, //13
        new byte[]{0xff, 0xff, 0xff, 0x00}, //14
        new byte[]{0xff, 0xff, 0xff, 0x00}, //15
        new byte[]{0xff, 0xff, 0xff, 0x00}, //16

        new byte[]{0xff, 0xff, 0xff, 0x00}, //17
        new byte[]{0xff, 0xff, 0xff, 0x00}, //18
        new byte[]{0xff, 0xff, 0xff, 0x00}, //19
        new byte[]{0xff, 0xff, 0xff, 0x00}, //20

        new byte[]{0xff, 0xff, 0xff, 0x00}, //21
        new byte[]{0xff, 0xff, 0xff, 0x00}, //22
        new byte[]{0xff, 0xff, 0xff, 0x00}, //23
        new byte[]{0xff, 0xff, 0xff, 0x00}, //24

        new byte[]{0xff, 0xff, 0xff, 0x00}, //25
        new byte[]{0xff, 0xff, 0xff, 0x00}, //26
        new byte[]{0xff, 0xff, 0xff, 0x00}, //27
        new byte[]{0xff, 0xff, 0xff, 0x00}, //28
        new byte[]{0xff, 0xff, 0xff, 0x00}, //29
        new byte[]{0xff, 0xff, 0xff, 0x00}, //30

        new byte[]{0x00, 0x00, 0x00, 0x00}, //31
        new byte[]{0x83, 0xbb, 0x1b, 0x00}, //32
        new byte[]{0x6f, 0xab, 0x0f, 0x00}, //33
        new byte[]{0x5f, 0x9f, 0x0b, 0x00}, //34
        new byte[]{0x4f, 0x93, 0x07, 0x00}, //35
        new byte[]{0x43, 0x77, 0x07, 0x00}, //36
        new byte[]{0x33, 0x5f, 0x07, 0x00}, //37
        new byte[]{0x27, 0x43, 0x07, 0x00}, //38
        new byte[]{0x1b, 0x2b, 0x07, 0x00}, //39
        new byte[]{0xbb, 0xbb, 0x07, 0x00}, //40
        new byte[]{0xb3, 0x87, 0x07, 0x00}, //41
        new byte[]{0xab, 0x57, 0x07, 0x00}, //42
        new byte[]{0xa3, 0x2f, 0x07, 0x00}, //43
        new byte[]{0xff, 0xff, 0xff, 0x00}, //44
        new byte[]{0x67, 0x07, 0x7b, 0x00}, //45
        new byte[]{0x7b, 0x37, 0x07, 0x00}, //46
        new byte[]{0x93, 0xbb, 0x0f, 0x00}, //47
        new byte[]{0x6b, 0x9f, 0xbb, 0x00}, //48
        new byte[]{0x47, 0x87, 0xab, 0x00}, //49
        new byte[]{0x2f, 0x73, 0x97, 0x00}, //50
        new byte[]{0x17, 0x63, 0x87, 0x00}, //51
        new byte[]{0x0f, 0x4f, 0x6f, 0x00}, //52
        new byte[]{0x0b, 0x3b, 0x57, 0x00}, //53
        new byte[]{0x07, 0x2b, 0x43, 0x00}, //54
        new byte[]{0x07, 0x1b, 0x2b, 0x00}, //55
        new byte[]{0xbb, 0x7b, 0x57, 0x00}, //56
        new byte[]{0xaf, 0x63, 0x37, 0x00}, //57
        new byte[]{0xa3, 0x4f, 0x1b, 0x00}, //58
        new byte[]{0x97, 0x3b, 0x07, 0x00}, //59
        new byte[]{0x7b, 0x2f, 0x07, 0x00}, //60
        new byte[]{0x63, 0x27, 0x07, 0x00}, //61
        new byte[]{0x47, 0x1b, 0x07, 0x00}, //62
        new byte[]{0x27, 0x0f, 0x07, 0x00}, //63
        new byte[]{0x00, 0x00, 0x00, 0x00}, //64
        new byte[]{0x00, 0x00, 0x00, 0x00}, //65
        new byte[]{0x00, 0x00, 0x00, 0x00}, //66
        new byte[]{0x00, 0x00, 0x00, 0x00}, //67
        new byte[]{0x00, 0x00, 0x00, 0x00}, //68
        new byte[]{0x00, 0x00, 0x00, 0x00}, //69
        new byte[]{0x00, 0x00, 0x00, 0x00}, //70
        new byte[]{0x00, 0x00, 0x00, 0x00}, //71
        new byte[]{0x00, 0x00, 0x00, 0x00}, //72
        new byte[]{0x00, 0x00, 0x00, 0x00}, //73
        new byte[]{0x00, 0x00, 0x00, 0x00}, //74
        new byte[]{0x00, 0x00, 0x00, 0x00}, //75
        new byte[]{0x00, 0x00, 0x00, 0x00}, //76
        new byte[]{0x00, 0x00, 0x00, 0x00}, //77
        new byte[]{0x00, 0x00, 0x00, 0x00}, //78
        new byte[]{0x00, 0x00, 0x00, 0x00}, //79
        new byte[]{0x00, 0x00, 0x00, 0x00}, //80
        new byte[]{0x00, 0x00, 0x00, 0x00}, //81
        new byte[]{0x00, 0x00, 0x00, 0x00}, //82
        new byte[]{0x00, 0x00, 0x00, 0x00}, //83
        new byte[]{0x00, 0x00, 0x00, 0x00}, //84
        new byte[]{0x00, 0x00, 0x00, 0x00}, //85
        new byte[]{0x00, 0x00, 0x00, 0x00}, //86
        new byte[]{0x00, 0x00, 0x00, 0x00}, //87
        new byte[]{0x00, 0x00, 0x00, 0x00}, //88
        new byte[]{0x00, 0x00, 0x00, 0x00}, //89
        new byte[]{0x00, 0x00, 0x00, 0x00}, //90
        new byte[]{0x00, 0x00, 0x00, 0x00}, //91
        new byte[]{0x00, 0x00, 0x00, 0x00}, //92
        new byte[]{0x00, 0x00, 0x00, 0x00}, //93
        new byte[]{0x00, 0x00, 0x00, 0x00}, //94
        new byte[]{0x00, 0x00, 0x00, 0x00}, //95
        new byte[]{0x00, 0x00, 0x00, 0x00}, //96
        new byte[]{0x00, 0x00, 0x00, 0x00}, //97
        new byte[]{0x00, 0x00, 0x00, 0x00}, //98
        new byte[]{0x00, 0x00, 0x00, 0x00}, //99
        new byte[]{0x00, 0x00, 0x00, 0x00}, //100
        new byte[]{0x00, 0x00, 0x00, 0x00}, //101
        new byte[]{0x00, 0x00, 0x00, 0x00}, //102
        new byte[]{0x00, 0x00, 0x00, 0x00}, //103
        new byte[]{0x00, 0x00, 0x00, 0x00}, //104
        new byte[]{0x00, 0x00, 0x00, 0x00}, //105
        new byte[]{0x00, 0x00, 0x00, 0x00}, //106
        new byte[]{0x00, 0x00, 0x00, 0x00}, //107
        new byte[]{0x00, 0x00, 0x00, 0x00}, //108
        new byte[]{0x00, 0x00, 0x00, 0x00}, //109
        new byte[]{0x00, 0x00, 0x00, 0x00}, //110
        new byte[]{0x00, 0x00, 0x00, 0x00}, //111
        new byte[]{0x00, 0x00, 0x00, 0x00}, //112
        new byte[]{0x00, 0x00, 0x00, 0x00}, //113
        new byte[]{0x00, 0x00, 0x00, 0x00}, //114
        new byte[]{0x00, 0x00, 0x00, 0x00}, //115
        new byte[]{0x00, 0x00, 0x00, 0x00}, //116
        new byte[]{0x00, 0x00, 0x00, 0x00}, //117
        new byte[]{0x00, 0x00, 0x00, 0x00}, //118
        new byte[]{0x00, 0x00, 0x00, 0x00}, //119
        new byte[]{0x00, 0x00, 0x00, 0x00}, //120
        new byte[]{0x00, 0x00, 0x00, 0x00}, //121
        new byte[]{0x00, 0x00, 0x00, 0x00}, //122
        new byte[]{0x00, 0x00, 0x00, 0x00}, //123
        new byte[]{0x00, 0x00, 0x00, 0x00}, //124
        new byte[]{0x00, 0x00, 0x00, 0x00}, //125
        new byte[]{0x00, 0x00, 0x00, 0x00}, //126
        new byte[]{0x00, 0x00, 0x00, 0x00}, //127
        new byte[]{0x00, 0x00, 0x00, 0x00}, //128
        new byte[]{0x00, 0x00, 0x00, 0x00}, //129
        new byte[]{0x00, 0x00, 0x00, 0x00}, //130
        new byte[]{0x00, 0x00, 0x00, 0x00}, //131
        new byte[]{0x00, 0x00, 0x00, 0x00}, //132
        new byte[]{0x00, 0x00, 0x00, 0x00}, //133
        new byte[]{0x00, 0x00, 0x00, 0x00}, //134
        new byte[]{0x00, 0x00, 0x00, 0x00}, //135
        new byte[]{0x00, 0x00, 0x00, 0x00}, //136
        new byte[]{0x00, 0x00, 0x00, 0x00}, //137
        new byte[]{0x00, 0x00, 0x00, 0x00}, //138
        new byte[]{0x00, 0x00, 0x00, 0x00}, //139
        new byte[]{0x00, 0x00, 0x00, 0x00}, //140
        new byte[]{0x00, 0x00, 0x00, 0x00}, //141
        new byte[]{0x00, 0x00, 0x00, 0x00}, //142
        new byte[]{0x00, 0x00, 0x00, 0x00}, //143
        new byte[]{0x00, 0x00, 0x00, 0x00}, //144
        new byte[]{0x00, 0x00, 0x00, 0x00}, //145
        new byte[]{0x00, 0x00, 0x00, 0x00}, //146
        new byte[]{0x00, 0x00, 0x00, 0x00}, //147
        new byte[]{0x00, 0x00, 0x00, 0x00}, //148
        new byte[]{0x00, 0x00, 0x00, 0x00}, //149
        new byte[]{0x00, 0x00, 0x00, 0x00}, //150
        new byte[]{0x00, 0x00, 0x00, 0x00}, //151
        new byte[]{0x00, 0x00, 0x00, 0x00}, //152
        new byte[]{0x00, 0x00, 0x00, 0x00}, //153
        new byte[]{0x00, 0x00, 0x00, 0x00}, //154
        new byte[]{0x00, 0x00, 0x00, 0x00}, //155
        new byte[]{0x00, 0x00, 0x00, 0x00}, //156
        new byte[]{0x00, 0x00, 0x00, 0x00}, //157
        new byte[]{0x00, 0x00, 0x00, 0x00}, //158
        new byte[]{0x00, 0x00, 0x00, 0x00}, //159
        new byte[]{0xff, 0xfb, 0xf7, 0x00}, //160
        new byte[]{0xf3, 0xdf, 0xd3, 0x00}, //161
        new byte[]{0xf3, 0xdb, 0xbb, 0x00}, //162
        new byte[]{0xdf, 0xc7, 0xaf, 0x00}, //163
        new byte[]{0xdf, 0xc3, 0x9b, 0x00}, //164
        new byte[]{0xdb, 0xb7, 0x8f, 0x00}, //165
        new byte[]{0xc7, 0xa7, 0x7f, 0x00}, //166
        new byte[]{0xb7, 0xa3, 0x83, 0x00}, //167
        new byte[]{0xab, 0x9b, 0x7b, 0x00}, //168
        new byte[]{0x9f, 0x97, 0x8b, 0x00}, //169
        new byte[]{0xaf, 0xa7, 0x93, 0x00}, //170
        new byte[]{0xbf, 0xab, 0x97, 0x00}, //171
        new byte[]{0xc7, 0xbb, 0xaf, 0x00}, //172
        new byte[]{0xcf, 0xa3, 0x6b, 0x00}, //173
        new byte[]{0xbf, 0x9b, 0x67, 0x00}, //174
        new byte[]{0xab, 0x8b, 0x5f, 0x00}, //175
        new byte[]{0xa3, 0x8b, 0x6b, 0x00}, //176
        new byte[]{0x9b, 0x87, 0x63, 0x00}, //177
        new byte[]{0x93, 0x87, 0x73, 0x00}, //178
        new byte[]{0x83, 0x7f, 0x77, 0x00}, //179
        new byte[]{0x7b, 0x73, 0x67, 0x00}, //180
        new byte[]{0x83, 0x73, 0x5b, 0x00}, //181
        new byte[]{0x8b, 0x7b, 0x63, 0x00}, //182
        new byte[]{0x93, 0x77, 0x53, 0x00}, //183
        new byte[]{0x9f, 0x7f, 0x4b, 0x00}, //184
        new byte[]{0xab, 0x83, 0x4b, 0x00}, //185
        new byte[]{0xb3, 0x8b, 0x53, 0x00}, //186
        new byte[]{0xc3, 0x93, 0x53, 0x00}, //187
        new byte[]{0xc7, 0x8b, 0x43, 0x00}, //188
        new byte[]{0xb3, 0x7f, 0x3b, 0x00}, //189
        new byte[]{0xa7, 0x73, 0x37, 0x00}, //190
        new byte[]{0x93, 0x6f, 0x3b, 0x00}, //191
        new byte[]{0x83, 0x6b, 0x3b, 0x00}, //192
        new byte[]{0x7b, 0x63, 0x47, 0x00}, //193
        new byte[]{0x73, 0x63, 0x3b, 0x00}, //194
        new byte[]{0x73, 0x57, 0x2b, 0x00}, //195
        new byte[]{0x67, 0x53, 0x2f, 0x00}, //196
        new byte[]{0x5b, 0x4f, 0x3b, 0x00}, //197
        new byte[]{0x53, 0x47, 0x33, 0x00}, //198
        new byte[]{0x53, 0x3f, 0x2b, 0x00}, //199
        new byte[]{0x4b, 0x3b, 0x27, 0x00}, //200
        new byte[]{0x43, 0x3b, 0x2b, 0x00}, //201
        new byte[]{0x3b, 0x33, 0x27, 0x00}, //202
        new byte[]{0x33, 0x2b, 0x1f, 0x00}, //203
        new byte[]{0x2b, 0x27, 0x23, 0x00}, //204
        new byte[]{0x27, 0x23, 0x1f, 0x00}, //205
        new byte[]{0x1f, 0x1b, 0x17, 0x00}, //206
        new byte[]{0x0f, 0x0f, 0x0f, 0x00}, //207
        new byte[]{0x37, 0x1f, 0x1f, 0x00}, //208
        new byte[]{0x2f, 0x2b, 0x2b, 0x00}, //209
        new byte[]{0x37, 0x33, 0x33, 0x00}, //210
        new byte[]{0x3f, 0x3b, 0x3b, 0x00}, //211
        new byte[]{0x4b, 0x47, 0x47, 0x00}, //212
        new byte[]{0x57, 0x53, 0x53, 0x00}, //213
        new byte[]{0x5f, 0x5b, 0x5b, 0x00}, //214
        new byte[]{0x67, 0x63, 0x63, 0x00}, //215
        new byte[]{0x6f, 0x6b, 0x6b, 0x00}, //216
        new byte[]{0x73, 0x67, 0x53, 0x00}, //217
        new byte[]{0x6b, 0x5f, 0x4b, 0x00}, //218
        new byte[]{0x63, 0x57, 0x43, 0x00}, //219
        new byte[]{0x57, 0x43, 0x23, 0x00}, //220
        new byte[]{0x4b, 0x2b, 0x2b, 0x00}, //221
        new byte[]{0x2f, 0x2b, 0x3b, 0x00}, //222
        new byte[]{0x83, 0x63, 0x2b, 0x00}, //223
        new byte[]{0x83, 0x6b, 0x4b, 0x00}, //224
        new byte[]{0xcf, 0x83, 0x6b, 0x00}, //225
        new byte[]{0xab, 0x6f, 0x5b, 0x00}, //226
        new byte[]{0xbb, 0x53, 0x37, 0x00}, //227
        new byte[]{0x7b, 0x4f, 0x43, 0x00}, //228
        new byte[]{0x9b, 0x3f, 0x2f, 0x00}, //229
        new byte[]{0x73, 0x27, 0x23, 0x00}, //230
        new byte[]{0x4b, 0x1f, 0x17, 0x00}, //231
        new byte[]{0x1f, 0x0f, 0x0f, 0x00}, //232
        new byte[]{0x8b, 0xab, 0x63, 0x00}, //233
        new byte[]{0x73, 0x93, 0x4f, 0x00}, //234
        new byte[]{0x57, 0x93, 0x3b, 0x00}, //235
        new byte[]{0x5f, 0x73, 0x43, 0x00}, //236
        new byte[]{0x43, 0x6b, 0x2f, 0x00}, //237
        new byte[]{0x3b, 0x53, 0x23, 0x00}, //238
        new byte[]{0x2b, 0x43, 0x1b, 0x00}, //239
        new byte[]{0x17, 0x1b, 0x0f, 0x00}, //240
        new byte[]{0x77, 0x6f, 0x9f, 0x00}, //241
        new byte[]{0x63, 0x57, 0x83, 0x00}, //242
        new byte[]{0x3b, 0x43, 0x8b, 0x00}, //243
        new byte[]{0x43, 0x43, 0x6b, 0x00}, //244
        new byte[]{0x2f, 0x33, 0x6b, 0x00}, //245
        new byte[]{0x43, 0x3b, 0x4f, 0x00}, //246
        new byte[]{0x1f, 0x23, 0x4b, 0x00}, //247
        new byte[]{0x0f, 0x13, 0x2b, 0x00}, //248
        new byte[]{0xb7, 0x67, 0x00, 0x00}, //249
        new byte[]{0x87, 0x4b, 0x00, 0x00}, //250
        new byte[]{0x5b, 0x33, 0x00, 0x00}, //251
        new byte[]{0x9b, 0x9b, 0x00, 0x00}, //252
        new byte[]{0x6f, 0x6f, 0x00, 0x00}, //253
        new byte[]{0x43, 0x43, 0x00, 0x00}, //254
        new byte[]{0xff, 0xff, 0xff, 0x00}, //255
        };
    }
}
