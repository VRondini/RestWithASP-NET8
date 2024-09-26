using Microsoft.AspNetCore.Mvc.Filters;

namespace Restapi_WorkingWithFiles.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);
    }
}
