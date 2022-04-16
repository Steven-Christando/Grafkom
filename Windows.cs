using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
namespace UTSgrafkom
{
    static class Constants
    {
        public const string path = "D:../../../shader/";
    }
    internal class Windows : GameWindow
    {
        float degr = 0;
        double time;
        List<Asset3d> listObject = new List<Asset3d>();
        float x = 0;
        Karakter karakter;
        ruangan room;
        Camera camera;

        Matrix4 temp2 = Matrix4.Identity;

        public Windows(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            
        }

        protected override void OnLoad()
        {

            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            room = new ruangan(new Vector3(0.6f, 0.5f, 0.5f));
            room.createBoxVertices(0, 0, 0);
            karakter = new Karakter(0f, 0f, 0f, new Vector3(0, 0.5f, 1));
            karakter.load(Size.X,Size.Y);
            /*room.load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);*/
            camera = new Camera(new Vector3(0, 0, 1), Size.X / (float)Size.Y);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            time += 15.0 * time;
            Matrix4 temp = Matrix4.Identity;
            degr = MathHelper.DegreesToRadians(0.5f);
            temp = Matrix4.CreateRotationY(degr);

            x += 0.001f;
            temp2 *= Matrix4.CreateTranslation(new Vector3(0.0f, 0f,0f));

            /*room.render(1, temp, time, camera.GetViewMatrix(), camera.GetProjectionMatrix());*/
            karakter.render(args.Time,temp * temp2, camera.GetViewMatrix(), camera.GetProjectionMatrix());
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            /*Console.WriteLine("halo");*/
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            var input = KeyboardState;
            float cameraSpeed = 0.5f;
            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (input.IsKeyDown(Keys.W))
            {
                camera.Position += camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.A))
            {
                camera.Position -= camera.Right * cameraSpeed * (float)args.Time;
                /*Console.WriteLine("tombol a di release");*/
            }
            if (input.IsKeyDown(Keys.S))
            {
                camera.Position -= camera.Front * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.D))
            {
                camera.Position += camera.Right * cameraSpeed * (float)args.Time;
            }

            /*if (input.IsKeyDown(Keys.Up))
            {
                camera.Position += camera.Pitch * cameraSpeed * (float)args.Time;
            }
            if (input.IsKeyDown(Keys.Down))
            {
                camera.Position -= camera.Pitch * cameraSpeed * (float)args.Time;
            }*/
        }
    }
}
