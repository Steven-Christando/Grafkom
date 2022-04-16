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
    internal class ruangan : Asset3d
    {
        public ruangan(Vector3 color) : base(color)
        {
        }

        public void render(int pilihan, Matrix4 temp, double time, Matrix4 cameraView, Matrix4 cameraProjection) 
        {
            base.render(pilihan, temp, time, cameraView, cameraProjection);

            _shader.SetVector3("ourColor", new Vector3(0.0f, 0f, 0f));
            GL.DrawElements(PrimitiveType.LineLoop, _indices.Count, DrawElementsType.UnsignedInt, 0);
    
        }


        public void createBoxVertices(float x, float y, float z)
        {
            //biar lebih fleksibel jangan inisialiasi posisi dan 
            //panjang kotak didalam tapi ditaruh ke parameter
            float _positionX = x;
            float _positionY = y;
            float _positionZ = z;

            float _boxLength = 0.7f;

            //Buat temporary vector
            Vector3 temp_vector;
            //1. Inisialisasi vertex
            // Titik 1
            temp_vector.X = _positionX - _boxLength; // x 
            temp_vector.Y = _positionY + _boxLength; // y
            temp_vector.Z = _positionZ - _boxLength; // z

            _vertices.Add(temp_vector);

            // Titik 2
            temp_vector.X = _positionX + _boxLength; // x
            temp_vector.Y = _positionY + _boxLength; // y
            temp_vector.Z = _positionZ - _boxLength; // z

            _vertices.Add(temp_vector);
            // Titik 3
            temp_vector.X = _positionX - _boxLength; // x
            temp_vector.Y = _positionY - _boxLength; // y
            temp_vector.Z = _positionZ - _boxLength; // z
            _vertices.Add(temp_vector);

            // Titik 4
            temp_vector.X = _positionX + _boxLength; // x
            temp_vector.Y = _positionY - _boxLength; // y
            temp_vector.Z = _positionZ - _boxLength; // z

            _vertices.Add(temp_vector);

            // Titik 5
            temp_vector.X = _positionX - _boxLength; // x
            temp_vector.Y = _positionY + _boxLength; // y
            temp_vector.Z = _positionZ + _boxLength; // z

            _vertices.Add(temp_vector);

            // Titik 6
            temp_vector.X = _positionX + _boxLength; // x
            temp_vector.Y = _positionY + _boxLength; // y
            temp_vector.Z = _positionZ + _boxLength; // z

            _vertices.Add(temp_vector);

            // Titik 7
            temp_vector.X = _positionX - _boxLength; // x
            temp_vector.Y = _positionY - _boxLength; // y
            temp_vector.Z = _positionZ + _boxLength; // z

            _vertices.Add(temp_vector);

            // Titik 8
            temp_vector.X = _positionX + _boxLength; // x
            temp_vector.Y = _positionY - _boxLength; //y
            temp_vector.Z = _positionZ + _boxLength; // z

            _vertices.Add(temp_vector);
            //2. Inisialisasi index vertex
            _indices = new List<uint> {
                // Segitiga Depan 1
                0, 1, 2,
                // Segitiga Depan 2
                1, 2, 3,
                // Segitiga Atas 1
                0, 4, 5,
                // Segitiga Atas 2
                0, 1, 5,
                // Segitiga Kanan 1
                1, 3, 5,
                // Segitiga Kanan 2
                3, 5, 7,
                // Segitiga Kiri 1
                0, 2, 4,
                // Segitiga Kiri 2
                2, 4, 6,
                // Segitiga Belakang 1
                4, 5, 6,
                // Segitiga Belakang 2
                5, 6, 7,
                // Segitiga Bawah 1
                2, 3, 6,
                // Segitiga Bawah 2
                3, 6, 7
            };
        }
        
    }
}
