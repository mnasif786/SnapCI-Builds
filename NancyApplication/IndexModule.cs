using System.Web.UI.WebControls;

namespace NancyApplication
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters => View["index"];
        }
    }
}