using System;
using System.Collections.Generic;
using System.Drawing;

namespace GLOM
{
    public interface IContainer<TLayoutInfo>
    {
        
        public bool ExpandChildrenVertically { get; set; }
        public bool ExpandChildenHorizontally { get; set; }
        
        public void Add(IComponent component, TLayoutInfo layoutInfo = default(TLayoutInfo));
        public void Remove(IComponent component);
        public List<Tuple<IComponent,TLayoutInfo>> Children { get; }
    }
}