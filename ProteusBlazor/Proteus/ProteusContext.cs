using Microsoft.JSInterop;

namespace Proteus
{
    public class ProteusContext:GLOM.ISystemContext
    {
        public readonly IJSInProcessRuntime JsRuntime;
        public ProteusContext(IJSInProcessRuntime jsRunTime)
        {
            JsRuntime = jsRunTime;
        }

        public void Log(string s)
        {
         
            JsRuntime.InvokeVoid("Proteus.log",s);
        }
    }
}