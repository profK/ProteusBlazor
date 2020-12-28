using GLOM;
using GLOM.Geometry;

namespace GLOM
{
    public abstract class AbstractComponent: IComponent
    {
        public Point Position
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
        public Matrix Transformation { get; set; }
        public Size Size { get; set; }
        public Size PreferredSize { get; }
        public Size MinSize { get; }
        
        public abstract void Layout(ISystemContext ctxt, Size space);

        public abstract void Render(ISystemContext ctxt, Matrix parentXform);
    }
}