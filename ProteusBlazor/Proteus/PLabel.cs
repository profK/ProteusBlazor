using Microsoft.JSInterop;

namespace Proteus
{
    public class PLabel:ProteusComponent
    {
        public PLabel(IJSRuntime runtime, string labelText) : base(
            runtime,MakeHtml(labelText))
        {
        }

        private static string MakeHtml(string labelText)
        {
            return "<span>" + labelText + "</span>";
        }
    }
}