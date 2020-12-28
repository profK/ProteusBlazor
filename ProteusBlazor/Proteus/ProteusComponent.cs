using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using IComponent = GLOM.IComponent;

namespace Proteus


{
    /***
     * This is a basic HTML component support parent for GLOM HTML
     * implemntation.
     * IMPORTANT: The stylistic and content parts of this component are fixed by the HTML when
     * it is created.  To change them, make a new component.
     */
    public class ProteusComponent : IComponent
    {
        
      
        public IJSRuntime JSRuntime { get; set; }
        
        private readonly IJSObjectReference _htmlElement;

        public ProteusComponent(IJSRuntime runtime,string html)
        {
            JSRuntime = runtime;   
            // cant be asynch in constructor, simpelr if it
            // isnt anyway
         
            // force this to by synchronous because it wont work ti this is done
            _htmlElement = runtime.InvokeAsync<IJSObjectReference>(
                "Proteus.htmlToElement", html).GetAwaiter().GetResult();
            var preferredSizeArray = runtime.InvokeAsync<int[]>(
                    "Proteus. getElementSize", _htmlElement).GetAwaiter().GetResult();
            PreferredSize = new Size(preferredSizeArray[0], preferredSizeArray[1]);
            MinSize = PreferredSize; //this is a guess that it starts at min size
        }

     
        public async void Render(Matrix parentXform)
        {
            parentXform.Multiply(Transformation);
            Point[] pos =
            {
                new Point(Position.X, Position.Y)
            };
            parentXform.TransformPoints(pos);
            //throw new System.NotImplementedException();
            await JSRuntime.InvokeVoidAsync("Proteus.setElementLayout",
                pos[0].X, pos[1].Y, Size.Width, Size.Height);
        }

        public Point Position { get; set; }

        public Matrix Transformation { get; set; }
        public Size Size { get; set; }
        public Size PreferredSize { get; }
        public Size MinSize { get; }
    }
}