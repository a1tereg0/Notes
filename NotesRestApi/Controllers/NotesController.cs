using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesRestApi.Dao;
using NotesRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteDao _noteDao;
        public NotesController(INoteDao noteDao)
        {
            _noteDao = noteDao;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllNotes()
        {
            return Ok(_noteDao.GetAllNotes());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAllNotes(int id)
        {
            var note = _noteDao.GetNote(id);
            if (note != null)
            {
                return Ok(note);
            }
            return NotFound("Note not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddNote(Note note)
        {
            _noteDao.AddNote(note);
            return Ok();
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateNote(Note note, int id)
        {
            if (_noteDao.GetNote(id) != null)
            {
                _noteDao.UpdateNote(note);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteNote(int id)
        {
            _noteDao.DeleteNote(id);
            return Ok();
        }




    }
}
