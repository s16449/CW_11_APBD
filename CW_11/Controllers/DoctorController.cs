using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW_11.Models;
using CW_11.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_11.Controllers
{  
    
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    { 
        public IDoctorsDbService _service;


    
        public DoctorController(IDoctorsDbService service)
        {
            _service = service;
        }

       [HttpGet]
       
        public IActionResult GetDoctors()
        {
            var result = _service.GetDoctors(); 
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            var result = _service.CreateDoctor(doctor);
            return Ok(result);
        }

        [HttpPost]
        [Route("edit/{id}")]
        
        public IActionResult EditDoctor(Doctor doctor, int idDoctor)
        {
            var result = _service.EditDoctor(doctor, idDoctor);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]

        public IActionResult DeleteDoctor(int id)
        {
            var result = _service.DeleteDoctor(id);

            return Ok(result);
        }
    }
}
