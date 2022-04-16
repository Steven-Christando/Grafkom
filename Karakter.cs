using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace UTSgrafkom
{
    internal class Karakter : Asset3d
    {
        float degr = 0;
        double time;
        List<Asset3d> listObject = new List<Asset3d>();
        Asset3d kepala, bokong, google, tas, badan, kakiKiri, kakiKanan;

        float x, y, z;
        static class Constants
        {
            public const string path = "D:../../../shader/";
        }
        public Karakter(float x, float y, float z, Vector3 color) : base(color)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            kepala = new Asset3d(new Vector3(0, 0.5f, 1));
            kepala.createEllipsoid(x + (-0.5f), y + (-0.3f), z + (0), 0.2f, 0.2f, 0.1f, 12, 12);

            bokong = new Asset3d(new Vector3(0, 0.5f, 1));
            bokong.createEllipsoid(x + (-0.5f), y + (-0.55f), z + (0), 0.2f, 0.15f, 0.1f, 12, 12);

            google = new Asset3d(new Vector3(0.8f, 0.8f, 0.8f));
            google.createEllipsoid(x + (-0.412f), y + (-0.3f), z + (0), 0.123f, 0.075f, 0.1f, 12, 12);

            tas = new Asset3d(new Vector3(1f, 0.5f, 1f));
            tas.createBoxVertices(x+(-0.555f),y+(-0.4f),z+(-0.05f));

            badan = new Asset3d(new Vector3(0, 0.5f, 1));
            badan.tabung(x+(-0.5f), y+(0), z + (0.55f), 0.2f, 0.1f, 0.013f);

            kakiKiri = new Asset3d(new Vector3(0, 0.5f, 1f));
            kakiKiri.tabung(x+(-0.62f), y+(0), z + (0.8f), 0.075f, 0.05f, 0.017f);

            kakiKanan = new Asset3d(new Vector3(0, 0.5f, 1f));
            kakiKanan.tabung(x + (-0.3753f), y + (0), y + (0.8f), 0.075f, 0.05f, 0.017f);

            listObject.Add(tas);
            listObject.Add(kakiKanan);
            listObject.Add(kakiKiri);
            listObject.Add(kepala);
            listObject.Add(bokong);
            listObject.Add(badan);
            listObject.Add(google);
        }

        public void load(float SizeX,float SizeY)
        {
            foreach (Asset3d i in listObject)
            {
                i.load(Constants.path + "shader.vert", Constants.path + "shader.frag", SizeX, SizeY);
            }
        }

        public void render(double times, Matrix4 temps, Matrix4 cameraView, Matrix4 cameraProjection)
        {
            time += 15.0 * times;
            Matrix4 temp = Matrix4.Identity;
            for (int i = 0; i < listObject.Count; i++)
            {
                if (i == 1 || i == 2 || i == 5)
                {
                    degr = MathHelper.DegreesToRadians(90f);
                    temp = Matrix4.CreateRotationX(degr)*temps;
                }
                else
                {
                    degr = MathHelper.DegreesToRadians(00f);
                    temp = Matrix4.CreateRotationX(degr)*temps;
                }
                listObject[i].render(1, temp, time, cameraView, cameraProjection);
            }
        }

    }
}
