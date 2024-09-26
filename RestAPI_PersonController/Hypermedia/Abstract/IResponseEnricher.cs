using Microsoft.AspNetCore.Mvc.Filters;

namespace Restapi_PersonController.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);
    }
}
