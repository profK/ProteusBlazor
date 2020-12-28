using System;
using System.Numerics;
using System.Runtime.InteropServices;
using GLOM.Geometry;

namespace GLOM
{
    

    public interface IComponent
    {
        //drawing info
        Point Position { get; set; }
        Matrix Transformation { get; set; }
        Size Size { get; set; }
        // Layout info
        Size PreferredSize { get; }
        Size MinSize { get; }

        public  void Layout(ISystemContext ctxt, Point pos, Size space);
        public void Render(ISystemContext ctxt, Matrix parentXform);

      
    }

    public interface ISystemContext
    {
        public void Log(string s);
    }
} 