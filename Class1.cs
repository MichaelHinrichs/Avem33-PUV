using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Avem33_PUV
{
    public class PUV
    {
        private readonly List<Vector3> points = new();
        private readonly List<Vector2> uvs = new();
        private readonly List<Vector3> faces = new();

        static PUV Read(string[] args)
        {
            BinaryReader br = new(File.OpenRead(args[0]));
            int pointCount = br.ReadInt32();
            br.ReadInt32();//Unknown.

            PUV puv = new();
            for (int i = 0; i < pointCount; i++)
            {
                puv.points.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                puv.uvs.Add(new Vector2(br.ReadInt32(), br.ReadInt32()));
            }

            while (br.BaseStream.Position < br.BaseStream.Length)
                puv.faces.Add(new Vector3(br.ReadInt16(), br.ReadInt16(), br.ReadInt16()));

            return puv;
        }
    }
}