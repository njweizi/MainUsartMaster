using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainSender
{
    public class verify
    {
        /// WIDTH：宽度，即CRC比特数。
        /// POLY：生成项的简写，以16进制表示。例如：CRC-32即是0x04C11DB7，忽略了最高位的"1"，即完整的生成项是0x104C11DB7。
        /// INIT：这是算法开始时寄存器（crc）的初始化预置值，十六进制表示。
        /// REFIN：待测数据的每个字节是否按位反转，True或False。
        /// REFOUT：在计算后之后，异或输出之前，整个数据是否按位反转，True或False。
        /// XOROUT：计算结果与此参数异或后得到最终的CRC值。

        ///******************************************************************************
        /// * Name:    CRC-4/ITU           x4+x+1
        /// * Poly:    0x03
        /// * Init:    0x00
        /// * Refin:   True
        /// * Refout:  True
        /// * Xorout:  0x00
        /// * Note:
        /// *****************************************************************************/
        public byte[] CRC4_ITU(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            byte crc = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (byte)((crc >> 1) ^ 0x0C);
                    else
                        crc = (byte)(crc >> 1);
                }
            }
            return new byte[] { crc };
        }

        /// **********************************************************************
        /// Name: CRC-5/EPC    x5+x3+1
        /// Poly: 0x09
        /// Init: 0x09
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC5_EPC(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0x48;// Initial value: 0x48 = 0x09<<(8-5)
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x80) > 0)
                        crc = (byte)((crc << 1) ^ 0x48);// 0x48 = 0x09<<(8-5)
                    else
                        crc = (byte)(crc << 1);
                }
            }
            return new byte[] { (byte)(crc >> 3) };
        }

        /// **********************************************************************
        /// Name: CRC-5/ITU    x5+x4+x2+1
        /// Poly: 0x15
        /// Init: 0x00
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC5_ITU(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (byte)((crc >> 1) ^ 0x15);// 0x15 = (reverse 0x15)>>(8-5)
                    else
                        crc = (byte)(crc >> 1);
                }
            }
            return new byte[] { crc };
        }

        /// **********************************************************************
        /// Name: CRC-5/USB    x5+x2+1
        /// Poly: 0x05
        /// Init: 0x1F
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x1F
        ///*************************************************************************
        public byte[] CRC5_USB(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0x1F;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (byte)((crc >> 1) ^ 0x14);// 0x14 = (reverse 0x05)>>(8-5)
                    else
                        crc = (byte)(crc >> 1);
                }
            }
            return new byte[] { (byte)(crc ^ 0x1F) };
        }

        /// **********************************************************************
        /// Name: CRC-6/ITU    x6+x+1
        /// Poly: 0x03
        /// Init: 0x00
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC6_ITU(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (byte)((crc >> 1) ^ 0x30);// 0x30 = (reverse 0x03)>>(8-6)
                    else
                        crc = (byte)(crc >> 1);
                }
            }
            return new byte[] { crc };
        }

        /// **********************************************************************
        /// Name: CRC-7/MMC    x7+x3+1
        /// Poly: 0x09
        /// Init: 0x00
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC7_MMC(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x80) > 0)
                        crc = (byte)((crc << 1) ^ 0x12);// 0x12 = 0x09<<(8-7)
                    else
                        crc = (byte)(crc << 1);
                }
            }
            return new byte[] { (byte)(crc >> 1) };
        }

        /// **********************************************************************
        /// Name: CRC8    x8+x2+x+1
        /// Poly: 0x07
        /// Init: 0x00
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC8(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x80) > 0)
                        crc = (byte)((crc << 1) ^ 0x07);
                    else
                        crc = (byte)(crc << 1);
                }
            }
            return new byte[] { crc };
        }

        /// **********************************************************************
        /// Name: CRC-8/ITU    x8+x2+x+1
        /// Poly: 0x07
        /// Init: 0x00
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x55
        ///*************************************************************************
        public byte[] CRC8_ITU(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x80) > 0)
                        crc = (byte)((crc << 1) ^ 0x07);
                    else
                        crc = (byte)(crc << 1);
                }
            }
            return new byte[] { (byte)(crc ^ 0x55) };
        }

        /// **********************************************************************
        /// Name: CRC-8/ROHC    x8+x2+x+1
        /// Poly: 0x07
        /// Init: 0xFF
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC8_ROHC(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0xFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (byte)((crc >> 1) ^ 0xE0);// 0xE0 = reverse 0x07
                    else
                        crc = (byte)(crc >> 1);
                }
            }
            return new byte[] { crc };
        }

        /// **********************************************************************
        /// Name: CRC-8/MAXIM    x8+x5+x4+1
        /// Poly: 0x31
        /// Init: 0x00
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x00
        ///*************************************************************************
        public byte[] CRC8_MAXIM(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            byte crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (byte)((crc >> 1) ^ 0x8C);// 0x8C = reverse 0x31
                    else
                        crc = (byte)(crc >> 1);
                }
            }
            return new byte[] { crc };
        }

        /// **********************************************************************
        /// Name: CRC-16/IBM    x16+x15+x2+1
        /// Poly: 0x8005
        /// Init: 0x0000
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x0000
        ///*************************************************************************
        public byte[] CRC16_IBM(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0xA001);// 0xA001 = reverse 0x8005
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/MAXIM    x16+x15+x2+1
        /// Poly: 0x8005
        /// Init: 0x0000
        /// Refin: true
        /// Refout: true
        /// Xorout: 0xFFFF
        ///*************************************************************************
        public byte[] CRC16_MAXIM(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0xA001);// 0xA001 = reverse 0x8005
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes((ushort)~crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/USB    x16+x15+x2+1
        /// Poly: 0x8005
        /// Init: 0xFFFF
        /// Refin: true
        /// Refout: true
        /// Xorout: 0xFFFF
        ///*************************************************************************
        public byte[] CRC16_USB(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0xFFFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0xA001);// 0xA001 = reverse 0x8005
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes((ushort)~crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/MODBUS    x16+x15+x2+1
        /// Poly: 0x8005
        /// Init: 0xFFFF
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x0000
        ///*************************************************************************
        public byte[] CRC16_MODBUS(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0xFFFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0xA001);// 0xA001 = reverse 0x8005
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/CCITT    x16+x12+x5+1
        /// Poly: 0x1021
        /// Init: 0x0000
        /// Refin: true
        /// Refout: true
        /// Xorout: 0x0000
        ///*************************************************************************
        public byte[] CRC16_CCITT(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0x8408);// 0x8408 = reverse 0x1021
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/CCITT FALSE    x16+x12+x5+1
        /// Poly: 0x1021
        /// Init: 0xFFFF
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x0000
        ///*************************************************************************
        public byte[] CRC16_CCITT_FALSE(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0xFFFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= (ushort)(buffer[i] << 8);
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x8000) > 0)
                        crc = (ushort)((crc << 1) ^ 0x1021);
                    else
                        crc = (ushort)(crc << 1);
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/X25    x16+x12+x5+1
        /// Poly: 0x1021
        /// Init: 0xFFFF
        /// Refin: true
        /// Refout: true
        /// Xorout: 0xFFFF
        ///*************************************************************************
        public byte[] CRC16_X25(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0xFFFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0x8408);// 0x8408 = reverse 0x1021
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes((ushort)~crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/XMODEM    x16+x12+x5+1
        /// Poly: 0x1021
        /// Init: 0x0000
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x0000
        ///*************************************************************************
        public byte[] CRC16_XMODEM(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= (ushort)(buffer[i] << 8);
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x8000) > 0)
                        crc = (ushort)((crc << 1) ^ 0x1021);
                    else
                        crc = (ushort)(crc << 1);
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC-16/DNP    x16+x13+x12+x11+x10+x8+x6+x5+x2+1
        /// Poly: 0x3D65
        /// Init: 0x0000
        /// Refin: true
        /// Refout: true
        /// Xorout: 0xFFFF
        ///*************************************************************************
        public byte[] CRC16_DNP(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            ushort crc = 0;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (ushort)((crc >> 1) ^ 0xA6BC);// 0xA6BC = reverse 0x3D65
                    else
                        crc = (ushort)(crc >> 1);
                }
            }
            byte[] ret = BitConverter.GetBytes((ushort)~crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC32    x32+x26+x23+x22+x16+x12+x11+x10+x8+x7+x5+x4+x2+x+1
        /// Poly: 0x04C11DB7
        /// Init: 0xFFFFFFFF
        /// Refin: true
        /// Refout: true
        /// Xorout: 0xFFFFFFFF
        ///*************************************************************************
        public byte[] CRC32(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            uint crc = 0xFFFFFFFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 1) > 0)
                        crc = (crc >> 1) ^ 0xEDB88320;// 0xEDB88320= reverse 0x04C11DB7
                    else
                        crc = crc >> 1;
                }
            }
            byte[] ret = BitConverter.GetBytes(~crc);
            Array.Reverse(ret);
            return ret;
        }

        /// **********************************************************************
        /// Name: CRC32/MPEG-2    x32+x26+x23+x22+x16+x12+x11+x10+x8+x7+x5+x4+x2+x+1
        /// Poly: 0x04C11DB7
        /// Init: 0xFFFFFFFF
        /// Refin: false
        /// Refout: false
        /// Xorout: 0x00000000
        ///*************************************************************************
        public byte[] CRC32_MPEG2(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            int length = buffer.Length;
            uint crc = 0xFFFFFFFF;// Initial value
            for (int i = 0; i < length; i++)
            {
                crc ^= (uint)(buffer[i] << 24);
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x80000000) > 0)
                        crc = (crc << 1) ^ 0x04C11DB7;
                    else
                        crc = crc << 1;
                }
            }
            byte[] ret = BitConverter.GetBytes(crc);
            Array.Reverse(ret);
            return ret;
        }

        // 纵向冗余校验（Longitudinal Redundancy Check，简称：LRC）是通信中常用的一种校验形式，也称LRC校验或纵向校验。 
        // 它是一种从纵向通道上的特定比特串产生校验比特的错误检测方法。在行列格式中（如磁带），LRC经常是与VRC一起使用，
        // 这样就会为每个字符校验码。在工业领域Modbus协议Ascii模式采用该算法。 LRC计算校验码,具体算法如下：
        /// 1、对需要校验的数据（2n个字符）两两组成一个16进制的数值求和。
        /// 2、将求和结果与256求模。
        /// 3、用256减去所得模值得到校验结果（另一种方法：将模值按位取反然后加1）。
        public byte[] LRC(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            byte lrc = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                lrc += buffer[i];
            }
            lrc = (byte)((lrc ^ 0xFF) + 1);
            return new byte[] { lrc };
        }

        // BCC(Block Check Character/信息组校验码)，因校验码是将所有数据异或得出，故俗称异或校验。
        // 具体算法是：将每一个字节的数据（一般是两个16进制的字符）进行异或后即得到校验码。
        public byte[] BCC(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) return null;
            byte bcc = 0;// Initial value
            for (int i = 0; i < buffer.Length; i++)
            {
                bcc ^= buffer[i];
            }
            return new byte[] { bcc };
        }

        /// <summary>
        /// 和校验
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public byte CheckSum(byte[] buffer, int len)
        {
            if (buffer == null || len == 0) return 0;
            int value = 0;
            for (int i = 0; i < len; i++)
            {
                value += buffer[i];
            }
            byte bcc = (byte)(value & 0x00FF);
            return bcc;
        }

        /********************************************************************************
       * 函数名称 ：CRC16Caculate
       * 函数功能 ：计算CRC16的校验和 半字计算法
       * 参 数 ：AP:要计算的数据指针 LEN：数据长度 CRC16_Type：约定为0x1324
       * 返 回 值 ：校验结果
       * 注 意 ：
       ********************************************************************************/

        public UInt16 CRC16Caculate(byte[] AP, int LEN)
        {
            UInt16 CRC16;
            UInt16 i;
            byte CRC_H4;
            UInt16[] CRCTable ={0x0000,0x1021,0x2042,0x3063,0x4084,0x50A5,0x60C6,0x70E7,
                                  0x8108,0x9129,0xA14A,0xB16B,0xC18C,0xD1AD,0xE1CE,0xF1EF};
            CRC16 = 0xFFFF - 0x1324;
            for (i = 0; i < LEN; i++)
            {
                CRC_H4 = (byte)(CRC16 >> 12);
                CRC16 = (UInt16)(CRC16 << 4);
                CRC16 = (UInt16)(CRC16 ^ CRCTable[CRC_H4 ^ (AP[i] >> 4)]);
                CRC_H4 = (byte)(CRC16 >> 12);
                CRC16 = (UInt16)(CRC16 << 4);
                CRC16 = (UInt16)(CRC16 ^ CRCTable[CRC_H4 ^ (AP[i] & 0x0F)]);
               
            }
            return CRC16;
        }

    }
}
