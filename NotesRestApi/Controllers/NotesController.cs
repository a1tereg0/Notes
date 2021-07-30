using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesRestApi.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteDao _noteDao;
        public NotesController(INoteDao noteDao)
        {
            _noteDao = noteDao;
        }
    }
}
