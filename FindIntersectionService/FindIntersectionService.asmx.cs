using System;
using System.Drawing;
using System.Web.Script.Services;
using System.Web.Services;

namespace App1
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class FindIntersectionService : WebService
    {

        [WebMethod]
        public PointF FindIntersection(
           float x1, float y1, float x2, float y2,
           float x3, float y3, float x4, float y4)
        {
            float denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (denominator == 0)
            {
                throw new InvalidOperationException("Прямі паралельні або співпадають.");
            }

            float px = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominator;
            float py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominator;

            return new PointF(px, py);
        }
    }
}
