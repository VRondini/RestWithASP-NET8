using Restapi_WorkingWithFiles.Hypermedia.Abstract;

namespace Restapi_WorkingWithFiles.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
