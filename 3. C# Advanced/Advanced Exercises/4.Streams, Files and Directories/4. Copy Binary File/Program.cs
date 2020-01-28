using System;
using System.IO;

namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using var oldStream = new FileStream(@"../../../copyMe.png", FileMode.Open);
            using var newStream = new FileStream(@"../../../newCopy.png", FileMode.Create);
            var bufer = new byte[1024];

            while (oldStream.CanRead)
            {
                var readByte = oldStream.Read(bufer, 0, bufer.Length);
                if (readByte == 0)
                {
                    break;
                }
                newStream.Write(bufer, 0, bufer.Length);
            }

        }
    }
}
