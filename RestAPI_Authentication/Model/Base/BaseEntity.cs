using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
