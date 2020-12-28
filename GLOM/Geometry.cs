using System;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace GLOM.Geometry

{

    public readonly struct Point
    {
        internal readonly Vector2 _vec2;

        public float X
        {
            get { return _vec2.X; }
        }

        public float Y
        {
            get { return _vec2.Y; }
        }

        public Point(float x, float y)
        {
            _vec2 = new Vector2(x, y);
        }

        public Point(Vector2 vec)
        {
            _vec2 = vec;
        }
    }

    public readonly struct Size
    {
        internal readonly Vector2 _vec2;

        public float Width
        {
            get { return _vec2.X; }
        }

        public float Height
        {
            get { return _vec2.Y; }
        }

        public Size(float width, float height)
        {
            _vec2 = new Vector2(width, height);
        }
    }

    public readonly struct Matrix
    {
        private readonly Matrix4x4 _mat;

        public Matrix(Matrix4x4 matrix)
        {
            _mat = matrix;
        }

        public Point Position
        {
            get
            {
                Vector3 p = _mat.Translation;
                return new Point(p.X,p.Y);
            }
           
        }

        public Point TransformPoint(Point pt)
        {
            return new Point(Vector2.Transform(pt._vec2, _mat));

        }

        public Matrix AtPosition(Point p)
        {
            Matrix4x4 newMat = _mat;
            newMat.Translation = new Vector3(p.X,p.Y,0);
            return new Matrix(newMat);
        }

        public Matrix Multiply(in Matrix transformation)
        {
            return new Matrix(Matrix4x4.Multiply(transformation._mat,_mat));
        }
    }
}