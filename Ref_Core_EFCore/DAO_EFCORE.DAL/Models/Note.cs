using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DAO_EFCORE.DAL.Models
{
    public class Note
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Label> Labels { get; set; }
        public virtual ICollection<Checklist> ListItems { get; set; }

    }
}
