using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignature
{
    public class myMD5
    {
        /// <summary>
        /// MD5 context
        /// </summary>
        private class MD5_CTX
        {
            /// <summary>
            /// state (ABCD)
            /// </summary>
            public UInt32[] state = new UInt32[4];
            /// <summary>
            /// number of bits, modulo 2^64 (lsb first)
            /// </summary>
            public UInt32[] count = new UInt32[2];
            /// <summary>
            /// input buffer
            /// </summary>
            public Byte[] buffer = new Byte[64];
        }

        /// <summary>
        /// Constants
        /// </summary>
        static private class Constants
        {
            public static int[,] r = { { 7, 12, 17, 22 }, { 5, 9, 14, 20 }, { 4, 11, 16, 23 }, { 6, 10, 15, 21 } };

            public static byte[] PADDING = {
                            0x80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            static private uint ROTATE_LEFT(uint x, int n) { return (uint)(((x) << (n)) | ((x) >> (32 - (n)))); }

            static public uint FF(uint a, uint b, uint c, uint d, uint x, int s, uint ac)
            {
                (a) += (((b) & (c)) | ((~b) & (d))) + (x) + (ac);
                (a) = ROTATE_LEFT((a), (s));
                (a) += (b);
                return a;
            }

            static public uint GG(uint a, uint b, uint c, uint d, uint x, int s, uint ac)
            {
                (a) += (((b) & (d)) | ((c) & (~d))) + (x) + (ac);
                (a) = ROTATE_LEFT((a), (s));
                (a) += (b);
                return a;
            }

            static public uint HH(uint a, uint b, uint c, uint d, uint x, int s, uint ac)
            {
                (a) += ((b) ^ (c) ^ (d)) + (x) + (ac);
                (a) = ROTATE_LEFT((a), (s));
                (a) += (b);
                return a;
            }

            static public uint II(uint a, uint b, uint c, uint d, uint x, int s, uint ac)
            {
                (a) += ((c) ^ ((b) | (~d))) + (x) + (ac);
                (a) = ROTATE_LEFT((a), (s));
                (a) += (b);
                return a;
            }
        }

        private MD5_CTX context;
        private string digest;

        /// <summary>
        /// Init
        /// </summary>
        private myMD5()
        {
            context = new MD5_CTX();

            context.count[0] = context.count[1] = 0;
            context.state[0] = 0x67452301; /*word A: 01 23 45 67*/
            context.state[1] = 0xefcdab89; /*word B: 89 ab cd ef*/
            context.state[2] = 0x98badcfe; /*word C: fe dc ba 98*/
            context.state[3] = 0x10325476; /*word D: 76 54 32 10*/
        }

        public myMD5(int i, string s) :
            this()
        {
            byte[] ditgest = new byte[16];
            if (i == 1)
            {
                const int BufferSize = 1024*1024*5;
                int bytesRead = 0;
                using (FileStream fileStream = new FileStream(s,FileMode.Open,FileAccess.Read))
                {
                    byte[] buffer = new byte[BufferSize];
                    do
                    {
                        bytesRead = fileStream.Read(buffer, 0, BufferSize);
                        MD5Update(buffer, (uint)bytesRead);
                    } while (bytesRead == BufferSize);
                    MD5Final(ditgest);
                }

            }
            else
            {
                byte[] input = System.Text.Encoding.Default.GetBytes(s);
                uint inputLen = Convert.ToUInt32(input.Length);
                MD5Update(input, inputLen);
                MD5Final(ditgest);
            }
            
            StringBuilder sb = new StringBuilder();
            foreach (byte item in ditgest)
            {
                sb.Append(String.Format("{0:x2}", item));
            }
            this.digest = sb.ToString();
        }

        public string getMD5()
        {
            return this.digest;
        }

        private void MD5Update(byte[] input, uint inputLen)
        {
            uint i, index, partLen;

            /* Compute number of bytes mod 64 */
            index = (uint)((context.count[0] >> 3) & 0x3F);

            /* Update number of bits */
            if ((context.count[0] += ((uint)inputLen << 3)) < ((uint)inputLen << 3))
                context.count[1]++;
            context.count[1] += ((uint)inputLen >> 29);

            partLen = 64 - index;

            /* Transform as many times as possible.
            */
            if (inputLen >= partLen)
            {
                MD5_memcpy(context.buffer, index, input, 0, partLen);
                MD5Transform();

                for (i = partLen; i + 63 < inputLen; i += 64)
                {
                    MD5_memcpy(context.buffer, 0, input, i, 64);
                    MD5Transform();
                }

                index = 0;
            }
            else
                i = 0;

            /* Buffer remaining input */
            MD5_memcpy(context.buffer, index, input, i, inputLen - i);
        }

        /// <summary>
        /// MD5 finalization.Ends an MD5 message-digest operation, writing the the message digest and zeroizing the context.*/
        /// </summary>
        /// <param name="digest"></param>
        private void MD5Final(byte[] digest)
        {
            byte[] bits = new byte[8];
            uint index, padLen;

            /* Save number of bits */
            Encode(bits, context.count, 8);

            /* Pad out to 56 mod 64.*/
            index = (uint)((context.count[0] >> 3) & 0x3f);
            padLen = (index < 56) ? (56 - index) : (120 - index);
            MD5Update(Constants.PADDING, padLen);

            /* Append length (before padding) */
            MD5Update(bits, 8);

            /* Store state in digest */
            Encode(digest, context.state, 16);
        }


        /// <summary>
        /// MD5 basic transformation. Transforms state based on block.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="block"></param>
        private void MD5Transform()
        {
            uint a = context.state[0], b = context.state[1], c = context.state[2], d = context.state[3];
            uint[] x = new uint[16];

            Decode(x, context.buffer, 64);

            /* Round 1 */
            a = Constants.FF(a, b, c, d, x[0], Constants.r[0, 0], 0xd76aa478);  /* 1 */
            d = Constants.FF(d, a, b, c, x[1], Constants.r[0, 1], 0xe8c7b756);  /* 2 */
            c = Constants.FF(c, d, a, b, x[2], Constants.r[0, 2], 0x242070db);  /* 3 */
            b = Constants.FF(b, c, d, a, x[3], Constants.r[0, 3], 0xc1bdceee);  /* 4 */
            a = Constants.FF(a, b, c, d, x[4], Constants.r[0, 0], 0xf57c0faf);  /* 5 */
            d = Constants.FF(d, a, b, c, x[5], Constants.r[0, 1], 0x4787c62a);  /* 6 */
            c = Constants.FF(c, d, a, b, x[6], Constants.r[0, 2], 0xa8304613);  /* 7 */
            b = Constants.FF(b, c, d, a, x[7], Constants.r[0, 3], 0xfd469501);  /* 8 */
            a = Constants.FF(a, b, c, d, x[8], Constants.r[0, 0], 0x698098d8);  /* 9 */
            d = Constants.FF(d, a, b, c, x[9], Constants.r[0, 1], 0x8b44f7af);  /* 10 */
            c = Constants.FF(c, d, a, b, x[10], Constants.r[0, 2], 0xffff5bb1); /* 11 */
            b = Constants.FF(b, c, d, a, x[11], Constants.r[0, 3], 0x895cd7be); /* 12 */
            a = Constants.FF(a, b, c, d, x[12], Constants.r[0, 0], 0x6b901122); /* 13 */
            d = Constants.FF(d, a, b, c, x[13], Constants.r[0, 1], 0xfd987193); /* 14 */
            c = Constants.FF(c, d, a, b, x[14], Constants.r[0, 2], 0xa679438e); /* 15 */
            b = Constants.FF(b, c, d, a, x[15], Constants.r[0, 3], 0x49b40821); /* 16 */

            /* Round 2 */
            a = Constants.GG(a, b, c, d, x[1], Constants.r[1, 0], 0xf61e2562);  /* 17 */
            d = Constants.GG(d, a, b, c, x[6], Constants.r[1, 1], 0xc040b340);  /* 18 */
            c = Constants.GG(c, d, a, b, x[11], Constants.r[1, 2], 0x265e5a51); /* 19 */
            b = Constants.GG(b, c, d, a, x[0], Constants.r[1, 3], 0xe9b6c7aa);  /* 20 */
            a = Constants.GG(a, b, c, d, x[5], Constants.r[1, 0], 0xd62f105d);  /* 21 */
            d = Constants.GG(d, a, b, c, x[10], Constants.r[1, 1], 0x2441453);  /* 22 */
            c = Constants.GG(c, d, a, b, x[15], Constants.r[1, 2], 0xd8a1e681); /* 23 */
            b = Constants.GG(b, c, d, a, x[4], Constants.r[1, 3], 0xe7d3fbc8);  /* 24 */
            a = Constants.GG(a, b, c, d, x[9], Constants.r[1, 0], 0x21e1cde6);  /* 25 */
            d = Constants.GG(d, a, b, c, x[14], Constants.r[1, 1], 0xc33707d6); /* 26 */
            c = Constants.GG(c, d, a, b, x[3], Constants.r[1, 2], 0xf4d50d87);  /* 27 */
            b = Constants.GG(b, c, d, a, x[8], Constants.r[1, 3], 0x455a14ed);  /* 28 */
            a = Constants.GG(a, b, c, d, x[13], Constants.r[1, 0], 0xa9e3e905); /* 29 */
            d = Constants.GG(d, a, b, c, x[2], Constants.r[1, 1], 0xfcefa3f8);  /* 30 */
            c = Constants.GG(c, d, a, b, x[7], Constants.r[1, 2], 0x676f02d9);  /* 31 */
            b = Constants.GG(b, c, d, a, x[12], Constants.r[1, 3], 0x8d2a4c8a); /* 32 */

            /* Round 3 */
            a = Constants.HH(a, b, c, d, x[5], Constants.r[2, 0], 0xfffa3942);  /* 33 */
            d = Constants.HH(d, a, b, c, x[8], Constants.r[2, 1], 0x8771f681);  /* 34 */
            c = Constants.HH(c, d, a, b, x[11], Constants.r[2, 2], 0x6d9d6122); /* 35 */
            b = Constants.HH(b, c, d, a, x[14], Constants.r[2, 3], 0xfde5380c); /* 36 */
            a = Constants.HH(a, b, c, d, x[1], Constants.r[2, 0], 0xa4beea44);  /* 37 */
            d = Constants.HH(d, a, b, c, x[4], Constants.r[2, 1], 0x4bdecfa9);  /* 38 */
            c = Constants.HH(c, d, a, b, x[7], Constants.r[2, 2], 0xf6bb4b60);  /* 39 */
            b = Constants.HH(b, c, d, a, x[10], Constants.r[2, 3], 0xbebfbc70); /* 40 */
            a = Constants.HH(a, b, c, d, x[13], Constants.r[2, 0], 0x289b7ec6); /* 41 */
            d = Constants.HH(d, a, b, c, x[0], Constants.r[2, 1], 0xeaa127fa);  /* 42 */
            c = Constants.HH(c, d, a, b, x[3], Constants.r[2, 2], 0xd4ef3085);  /* 43 */
            b = Constants.HH(b, c, d, a, x[6], Constants.r[2, 3], 0x4881d05);   /* 44 */
            a = Constants.HH(a, b, c, d, x[9], Constants.r[2, 0], 0xd9d4d039);  /* 45 */
            d = Constants.HH(d, a, b, c, x[12], Constants.r[2, 1], 0xe6db99e5); /* 46 */
            c = Constants.HH(c, d, a, b, x[15], Constants.r[2, 2], 0x1fa27cf8); /* 47 */
            b = Constants.HH(b, c, d, a, x[2], Constants.r[2, 3], 0xc4ac5665);  /* 48 */

            /* Round 4 */
            a = Constants.II(a, b, c, d, x[0], Constants.r[3, 0], 0xf4292244);  /* 49 */
            d = Constants.II(d, a, b, c, x[7], Constants.r[3, 1], 0x432aff97);  /* 50 */
            c = Constants.II(c, d, a, b, x[14], Constants.r[3, 2], 0xab9423a7); /* 51 */
            b = Constants.II(b, c, d, a, x[5], Constants.r[3, 3], 0xfc93a039);  /* 52 */
            a = Constants.II(a, b, c, d, x[12], Constants.r[3, 0], 0x655b59c3); /* 53 */
            d = Constants.II(d, a, b, c, x[3], Constants.r[3, 1], 0x8f0ccc92);  /* 54 */
            c = Constants.II(c, d, a, b, x[10], Constants.r[3, 2], 0xffeff47d); /* 55 */
            b = Constants.II(b, c, d, a, x[1], Constants.r[3, 3], 0x85845dd1);  /* 56 */
            a = Constants.II(a, b, c, d, x[8], Constants.r[3, 0], 0x6fa87e4f);  /* 57 */
            d = Constants.II(d, a, b, c, x[15], Constants.r[3, 1], 0xfe2ce6e0); /* 58 */
            c = Constants.II(c, d, a, b, x[6], Constants.r[3, 2], 0xa3014314);  /* 59 */
            b = Constants.II(b, c, d, a, x[13], Constants.r[3, 3], 0x4e0811a1); /* 60 */
            a = Constants.II(a, b, c, d, x[4], Constants.r[3, 0], 0xf7537e82);  /* 61 */
            d = Constants.II(d, a, b, c, x[11], Constants.r[3, 1], 0xbd3af235); /* 62 */
            c = Constants.II(c, d, a, b, x[2], Constants.r[3, 2], 0x2ad7d2bb);  /* 63 */
            b = Constants.II(b, c, d, a, x[9], Constants.r[3, 3], 0xeb86d391);  /* 64 */

            context.state[0] += a;
            context.state[1] += b;
            context.state[2] += c;
            context.state[3] += d;
        }

        /// <summary>
        /// Encodes input (UINT4) into output (unsigned char). Assumes len is a multiple of 4.
        /// </summary>
        static void Encode(byte[] output, uint[] input, uint len)
        {
            uint i, j;

            for (i = 0, j = 0; j < len; i++, j += 4)
            {
                output[j] = (byte)(input[i] & 0xff);
                output[j + 1] = (byte)((input[i] >> 8) & 0xff);
                output[j + 2] = (byte)((input[i] >> 16) & 0xff);
                output[j + 3] = (byte)((input[i] >> 24) & 0xff);
            }
        }


        /// <summary>
        /// Decodes input(unsigned char) into output(UINT4). Assumes len is a multiple of 4.
        /// </summary>
        /// <param name="">x[16]</param>
        /// <param name="">block</param>
        /// <param name="">64/4=16</param>
        static void Decode(uint[] output, byte[] input, uint len)
        {
            uint i, j;
            for (i = 0, j = 0; j < len; i++, j += 4)
                output[i] = ((uint)input[j]) | (((uint)input[j + 1]) << 8) |
                            (((uint)input[j + 2]) << 16) | (((uint)input[j + 3]) << 24);
        }

        /// <summary>
        /// Note: Replace "for loop" with standard memcpy if possible.
        /// </summary>
        static void MD5_memcpy(byte[] output, uint indexOut, byte[] input, uint indexIn, uint len)
        {
            uint i;

            for (i = 0; i < len; i++)
                output[indexOut + i] = input[indexIn + i];
        }
    }
}
