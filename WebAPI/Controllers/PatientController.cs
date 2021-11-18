using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.Patient.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> GetById(int patientId)
        {
            var data = await unitOfWork.Patient.GetByIdAsync(patientId);
            if (data == null) return NotFound();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            var data = await unitOfWork.Patient.AddAsync(patient);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.Patient.DeleteAsync(id);
            return Ok(data);
        }


        [HttpPut("{patientId:int}")]
        public async Task<IActionResult> Update(int patientId, Patient patient)
        {

            try
            {
                if (patientId != patient.PatientId)
                    return BadRequest("Patient ID mismatch");

                var patientUpdate = await unitOfWork.Patient.GetByIdAsync(patientId);

                if (patientUpdate == null)
                    return NotFound($"Patient not found");

                var data = await unitOfWork.Patient.UpdateAsync(patient);
                return Ok(data);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpGet("search/")]
        public async Task<IActionResult> Search(string province, String medication)
        {
            try
            {
                //TODO: Check the Province
                //TODO: Check the medication

                var result = await unitOfWork.Patient.Search(province, medication);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}