using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAO_EFCORE.DAL.Models
{
    public interface IKeepNoteContext
    {
        DbSet<Note> Notes { get; set; }
        DbSet<Label> Labels { get; set; }
        DbSet<Checklist> Checklists { get; set; }
        int SaveChanges();
    }
}
