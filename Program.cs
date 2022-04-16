/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");*/
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTSgrafkom
{
    class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(1500, 1500),
                Title = "Fall Guys"
            };
            using (var window = new Windows(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        } 
    }
}