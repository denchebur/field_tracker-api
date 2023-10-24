using field_tracker_api.Models.Pet;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace field_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private IField_Service _field_Service;

        public FieldController(IField_Service pet_Service)
        {
            _field_Service = pet_Service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetFieldsByUserId()
        {
            try
            {
                var result = await _field_Service.GetFieldsByUserId(Convert.ToInt64(User.Claims.ToList().Find(r => r.Type == "UserId").Value));
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetFieldById(long id)
        {
            try
            {
                var result = await _field_Service.GetFieldById(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllFields()
        {
            try
            {
                var result = await _field_Service.GetAllFields();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddField(Field_PassObject field)
        {
            try
            {
                var result = await _field_Service.AddField(field.user_id, field.title, field.vegetation, field.square, field.humidity, field.status, field.date);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateField(FieldUpdate_PassObject field)
        {
            try
            {
                var result = await _field_Service.UpdateField(field.field_id, field.user_id, field.title, field.vegetation, field.square, field.humidity, field.status, field.date);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteFieldById(long id)
        {
            try
            {
                var result = await _field_Service.DeleteFieldById(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
