using System;
using System.Collections.Generic;
using GLOM.Geometry;

namespace GLOM
{
    public abstract class AbstractContainer<TLayoutInfo> : AbstractComponent,
        IContainer<TLayoutInfo>
    {
        public bool ExpandChildrenVertically { get; set; }
        public bool ExpandChildenHorizontally { get; set; }

        public AbstractContainer()
        {
            Children = new List<Tuple<IComponent, TLayoutInfo>>();
        }

        
        public override void Render(ISystemContext ctxt, Matrix parentMatrix)
        { 
            parentMatrix = parentMatrix.Multiply(Transformation);
            foreach (var tuple in Children)
            {
                tuple.Item1.Render(ctxt, parentMatrix);
            }
        }



        public void Add(IComponent component, TLayoutInfo layoutInfo = default(TLayoutInfo))
        {
           Children.Add(new Tuple<IComponent,TLayoutInfo>(component,layoutInfo));
        }

        public void Remove(IComponent component)
        {
            foreach (var tuple in Children)
            {
                if (tuple.Item1 == component)
                {
                    Children.Remove(tuple);
                    return;
                }
            }
        }

        public List<Tuple<IComponent, TLayoutInfo>> Children { get; private set; }
    }
}