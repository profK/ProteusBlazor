﻿using System;
using System.Reflection;
using GLOM.Geometry;



namespace GLOM
{
    public struct HorizontalLayoutInfo 
    {
        
    }

    public class HorizontalLayout : AbstractContainer<HorizontalLayoutInfo>
    {

        public  override Size PreferredSize
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

        public  override Size MinSize
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

        public override void Layout(ISystemContext ctxt, Point pos,Size space)
        {
            base.Layout(ctxt,pos,space);
            Size myPreferredISize = PreferredSize;
            int pad = (int)(space.Width - myPreferredISize.Width) / Children.Count;
            float xAcc = 0;
            foreach (var tuple in Children)
            {
                IComponent comp = tuple.Item1;
                Size compISize = comp.PreferredSize;
                float w = compISize.Width;
                float h = compISize.Height;
              
                if (ExpandChildenHorizontally)
                {
                    w += pad;
                }

                if (ExpandChildrenVertically)
                {
                    h = myPreferredISize.Height;
                }

                comp.Layout(ctxt,new Point(xAcc,0),new Size(w,h));
                xAcc += comp.Size.Width;
            }
        }
    }
}