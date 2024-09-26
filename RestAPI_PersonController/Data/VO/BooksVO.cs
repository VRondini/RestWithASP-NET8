using Restapi_PersonController.Hypermedia;
using Restapi_PersonController.Hypermedia.Abstract;
using Restapi_PersonController.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restapi_PersonController.Data.VO
{
    public class BooksVO : ISupportHyperMedia
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Author { get; set; }
       public string Publisher { get; set; }
       public string Genre { get; set; }
       public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
