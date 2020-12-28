using GLOM;
using Microsoft.JSInterop;

namespace Proteus
{
    public class PLabel:ProteusComponent
    {
        public PLabel(ProteusContext ctxt, string labelText) : base(
            ctxt,MakeHTML(labelText))
        {
        }

        private static string MakeHTML(string labelText)
        {
            return "<span>" + labelText + "</span>";
        }
    }
}