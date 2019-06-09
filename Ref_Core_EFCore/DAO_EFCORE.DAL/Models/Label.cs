using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO_EFCORE.DAL.Models
{
    public class Label
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelId { get; set; }

        public string Content { get; set; }

        public int NoteId { get; set; }


        public virtual Note Note { get; set; }

    }
}
