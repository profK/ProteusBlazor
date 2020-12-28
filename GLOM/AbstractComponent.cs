using System.Diagnostics;
using System.Numerics;
using GLOM;
using GLOM.Geometry;

namespace GLOM
{
    public abstract class AbstractComponent: IComponent
    {
        public virtual Point Position
        {
            get
            {
                return Transformation.Position;
            }
            set
            {
                Transformation = Transformation.AtPosition(value);
            }
        }
        public virtual Matrix Transformation { get; set; }
        public virtual Size Size { get; set; }
        public virtual Size PreferredSize { get; protected set; }
        public virtual Size MinSize { get; protected set; }

        public AbstractComponent()
        {
            Transformation = new Matrix(Matrix4x4.Identity);
        }
        
        public virtual void Layout(ISystemContext ctxt, Point pos, Size space)
        {
            ctxt.Log("!!!in Abstract Layout");
            Position = pos;
            Size = space;
        }

        public abstract void Render(ISystemContext ctxt, Matrix parentXform);
    }
}