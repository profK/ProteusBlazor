
using System.Threading.Tasks;
using System.Transactions;
using GLOM;
using Microsoft.JSInterop;
using GLOM.Geometry;


namespace Proteus


{
    /***
     * This is a basic HTML component support parent for GLOM HTML
     * implemntation.
     * IMPORTANT: The stylistic and content parts of this component are fixed by the HTML when
     * it is created.  To change them, make a new component.
     */
    public abstract class ProteusComponent : AbstractComponent
    {
     
        private readonly IJSObjectReference _htmlElement;
  

        public ProteusComponent(ProteusContext ctxt, string html)
        {
            _htmlElement = ctxt.JsRuntime.Invoke<IJSObjectReference>(
                "Proteus.htmlToElement", html);
            float[] sizeArray = ctxt.JsRuntime.Invoke<float[]>(
                "Proteus.getElementSize", _htmlElement);
            PreferredSize = new Size(sizeArray[0], sizeArray[1]);
            ctxt.Log( "preferred size=" + PreferredSize.Width + "," + PreferredSize.Height);
            MinSize = PreferredSize;
            
        }

        public override void Render(ISystemContext sysCtxt, Matrix parentXform)
        {
            ProteusContext pctxt = sysCtxt as ProteusContext;
        
            pctxt.Log("current\n"+Transformation.ToString());
            Matrix postMult = parentXform.Multiply(Transformation);
            pctxt.Log("post multiply\n"+postMult.ToString());
            Point pos = postMult.TransformPoint(new Point(0,0));
            pctxt.Log("pos="+pos.ToString());
            pctxt.JsRuntime.InvokeVoid("Proteus.setElementLayout",
            _htmlElement,pos.X, pos.Y, Size.Width, Size.Height);
        }

        public override void Layout(ISystemContext ctxt, Point pos, Size space)
        {
            base.Layout(ctxt, pos, space);
            ctxt.Log("layout at "+pos.X+","+pos.Y);
            ctxt.Log("size= "+Size.Width+","+Size.Height);
           
        }

        
        
    }
}