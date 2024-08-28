﻿using Restapi_PersonController.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restapi_PersonController.Model
{
    [Table("Books")]
    public class Books : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("author")]
        public string Author { get; set; }

        [Column("publisher")]
        public string Publisher { get; set; }

        [Column("genre")]
        public string Genre { get; set; }
    }
}