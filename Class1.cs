using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Avem33_PUV
{
    public class PUV
    {
        private readonly List<Vector3> verts = new();
        private readonly List<Vector2> uvs = new();
        private readonly List<Vector3> faces = new();

        static PUV Read(string[] args)
        {
            BinaryReader br = new(File.OpenRead(args[0]));
            int vertCount = br.ReadInt32();
            int faceCount = br.ReadInt32();

            PUV puv = new();
            for (int i = 0; i < vertCount; i++)
            {
                puv.verts.Add(new Vector3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32()));
                puv.uvs.Add(new Vector2(br.ReadInt32(), br.ReadInt32()));
            }

            for (int i = 0; i < faceCount; i++)
                puv.faces.Add(new Vector3(br.ReadInt16(), br.ReadInt16(), br.ReadInt16()));

            return puv;
        }
    }
}
