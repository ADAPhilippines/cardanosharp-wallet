﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoSharp.Wallet.Common
{
    public class BigEndianBuffer
    {
        readonly List<byte> _bytes = new List<byte>();

        public void WriteUInt(uint i)
        {
            _bytes.Add((byte)((i >> 0x18) & 0xff));
            _bytes.Add((byte)((i >> 0x10) & 0xff));
            _bytes.Add((byte)((i >> 8) & 0xff));
            _bytes.Add((byte)(i & 0xff));
        }

        public void Write(byte b)
        {
            _bytes.Add(b);
        }

        public void Write(byte[] bytes)
        {
            Write(bytes, 0, bytes.Length);
        }

        public void Write(byte[] bytes, int offset, int count)
        {
            var newBytes = new byte[count];
            Array.Copy(bytes, offset, newBytes, 0, count);

            _bytes.AddRange(newBytes);
        }

        public byte[] ToArray()
        {
            return _bytes.ToArray();
        }
    }
}
