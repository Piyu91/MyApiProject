using System;
using System.Net;
using DAO_EFCORE.Business;
using DAO_EFCORE.Business.Exceptions;
using DAO_EFCORE.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAO_EFCORE.API.Controllers
{
    [Route("api")]
    public class NotesController : Controller
    {
        private readonly INoteService noteservice;

        public NotesController(INoteService service)
        {
            noteservice = service;
        }

        [Route("notes")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res = noteservice.GetAllNotes();
                return Ok(res);
            }
            catch(NoteNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = noteservice.GetNote(id);
                return Ok(customer);
            }
            catch (NoteNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes")]
        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            try
            {
                noteservice.AddNote(note);
                return Created("Added new note", note);
            }
            catch (DuplicatesFoundException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = noteservice.RemoveNote(id);
                return Ok(res);
            }
            catch (NoteNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes/{id}/labels")]
        [HttpPost]
        public IActionResult AddLabel(int id,[FromBody] Label label)
        {
            try
            {
                noteservice.AddLabel(id, label);
                return Created("Added new label", label);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes/{id}/labels/{labelid}")]
        [HttpDelete]
        public IActionResult RemoveLabel(int id,int labelid)
        {
            try
            {
                var res = noteservice.RemoveLabel(id, labelid);
                return Ok(res);
            }
            catch (LabelNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes/{id}/labels/{labelid}")]
        [HttpPut]
        public IActionResult UpdateLabel(int id, int labelid,[FromBody] Label label)
        {
            try
            {
                label.LabelId = labelid;
                var res = noteservice.UpdateLabel(id, label);
                return Ok(res);
            }
            catch (LabelNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("notes/{id}/checklist")]
        [HttpPost]
        public IActionResult AddChecklist(int id,[FromBody] Checklist checklist)
        {
            try
            {
                noteservice.AddChecklist(id, checklist);
                return Created("Added new Checklist", checklist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }

        [Route("notes/{id}/checklist/{itemId}")]
        [HttpDelete]
        public IActionResult RemoveChecklist(int id, int itemId)
        {
            try
            {
                var res = noteservice.RemoveChecklist(id, itemId);
                return Ok(res);
            }
            catch (ChecklistNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

        [Route("notes/{id}/checklist/{itemId}")]
        [HttpPut]
        public IActionResult UpdateChecklist(int id,int itemid, [FromBody] Checklist checklist)
        {
            try
            {
                checklist.ChecklistId = itemid;
                var res = noteservice.UpdateChecklist(id, checklist);
                return Ok(res);
            }
            catch (ChecklistNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

        [Route("notes/byLabel/{lblText}")]
        [HttpGet]
        public IActionResult GetNotesByLabel(string lblText)
        {
            try
            {
                var customer = noteservice.GetNotesByLabel(lblText);
                return StatusCode((int)HttpStatusCode.OK, customer);
            }
            catch (NoteNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
           
        }

        [Route("notes/byTitle/{title}")]
        [HttpGet]
        public IActionResult GetNotesByTitle(string title)
        {
            try
            {
                var customer = noteservice.GetNotesByTitle(title);
                return StatusCode((int)HttpStatusCode.OK, customer);
            }
            catch (NoteNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
            
        }
    }
}
