using Microsoft.JSInterop;

namespace LargeDiagram.Components.Pages
{

    public class FileUtil
    {
        public async static Task SaveAs(IJSRuntime js, string data, string fileName)
        {
            await js.InvokeAsync<object>(
                "saveDiagram",
                Convert.ToString(data), fileName).ConfigureAwait(true);
        }
        public async static Task Click(IJSRuntime js)
        {
            await js.InvokeAsync<object>(
                "click").ConfigureAwait(true);
        }
        public async static Task<string> LoadFile(IJSRuntime js, object data)
        {
            return await js.InvokeAsync<string>(
                  "loadFile", data).ConfigureAwait(true);
        }
    }
}
