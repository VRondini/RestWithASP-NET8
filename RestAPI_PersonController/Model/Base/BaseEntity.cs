using System.ComponentModel.DataAnnotations.Schema;

namespace Restapi_PersonController.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
