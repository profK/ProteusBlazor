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

        public void Layout(ISystemContext ctxt,Size space);
        public void Render(ISystemContext ctxt, Matrix parentXform);

      
    }

    public interface ISystemContext
    {
        //This is an empty marker interface.  it should be instantiated
        //by the render system in order to hold any context necessary
        //for its operation.
    }
} 