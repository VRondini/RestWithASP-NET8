using Restapi_PersonController.Hypermedia;
using Restapi_PersonController.Hypermedia.Abstract;
using Restapi_PersonController.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restapi_PersonController.Data.VO
{
    public class PersonVO : ISupportHyperMedia
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
