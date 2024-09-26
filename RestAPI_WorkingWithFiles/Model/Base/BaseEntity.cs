using System.ComponentModel.DataAnnotations.Schema;

namespace Restapi_WorkingWithFiles.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
