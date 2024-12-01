using System.Web.Script.Services;
using System.Web.Services;

namespace RenderGraphService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class RenderGraphService : WebService
    {
        [WebMethod]
        public string RenderGraph(
            float x1, float y1, float x2, float y2,
            float x3, float y3, float x4, float y4,
            float px, float py)
        {
            return $@"
            <svg width='500' height='500' xmlns='http://www.w3.org/2000/svg'>
                <line x1='{x1 * 50}' y1='{y1 * 50}' x2='{x2 * 50}' y2='{y2 * 50}' stroke='blue' />
                <line x1='{x3 * 50}' y1='{y3 * 50}' x2='{x4 * 50}' y2='{y4 * 50}' stroke='red' />
                <circle cx='{px * 50}' cy='{py * 50}' r='5' fill='green' />
            </svg>";
        }
    }
}
