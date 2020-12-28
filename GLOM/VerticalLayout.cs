using System;
using System.Reflection;
using GLOM.Geometry;



namespace GLOM
{
    public struct VerticalLayoutInfo 
    {
        
    }

    public class VerticalLayout : AbstractContainer<VerticalLayoutInfo>
    {

        public override Size PreferredSize
        {
            get
            {
                
                float w = 0;
                float h = 0;
                foreach (var tuple in Children)
                {
                    w += tuple.Item1.PreferredSize.Width;
                    h = Math.Max(h, tuple.Item1.PreferredSize.Height);
                }

                return new Size(w,h);
            }
        }

        public override Size MinSize
        {
            get
            {
                float w = 0;
                float h = 0;
                foreach (var tuple in Children)
                {
                    w += tuple.Item1.MinSize.Width;
                    h = Math.Max(h, tuple.Item1.MinSize.Height);
                }

                return new Size(w, h);
            }
        }

        public override void Layout(ISystemContext ctxt, Size space)
        {

            Size myPreferredISize = PreferredSize;
            int pad = (int)(space.Height - myPreferredISize.Height) / Children.Count;
            foreach (var tuple in Children)
            {
                IComponent comp = tuple.Item1;
                Size compISize = comp.PreferredSize;
                float w = compISize.Width;
                float h = compISize.Height;
                float yAcc = 0;
                if (ExpandChildenHorizontally)
                {
                    w = myPreferredISize.Width;
                    
                }

                if (ExpandChildrenVertically)
                {
                    h  += pad;
                }

                comp.Size = new Size(w, h);
                comp.Position = new Point((space.Width - comp.Size.Width) / 2,yAcc);
                yAcc += comp.Size.Height;
            }
        }
    }
}