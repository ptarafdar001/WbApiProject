using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Nagarro.ReimbursementPortal.webAPI.Data.Interfaces;
using Nagarro.ReimbursementPortal.webAPI.DTOs;
using Nagarro.ReimbursementPortal.webAPI.Interfaces.IUow;
using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReimTypeController : ControllerBase
    {
      
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ReimTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET api/reimtype
        [HttpGet]
        public async Task<IActionResult> GetReimTypes()
        {

            //throw new UnauthorizedAccessException();

            var reimTypes = await uow.ReimTypeRepository.GetReimTypesAsync();

            var reimTypesDto = mapper.Map<IEnumerable<ReimTypeDto>>(reimTypes);

            return Ok(reimTypesDto);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddReimTypes(ReimTypeDto reimTypeDto)
        {
            var type = mapper.Map<ReimType>(reimTypeDto);
            type.LastUpdatedBy = 1;
            type.lastUpdatedOn = DateTime.Now;

            uow.ReimTypeRepository.AddReimType(type);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult>UpdateReimType(int id, ReimTypeDto reimTypeDto)
        {
            if (id != reimTypeDto.Id)
                return BadRequest("Update not allowed");

            var reimTypeFromDb = await uow.ReimTypeRepository.FindReimType(id);

            if(reimTypeFromDb == null)
                return BadRequest("Update not allowed");

            reimTypeFromDb.LastUpdatedBy = 1;
            reimTypeFromDb.lastUpdatedOn = DateTime.Now;
            mapper.Map(reimTypeDto, reimTypeFromDb);

            //throw new Exception("Some Unknown Exception Occured");

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReimTypes(int id)
        {
            uow.ReimTypeRepository.DeleteReimType(id);
            await uow.SaveAsync();
            return Ok(id);
        }

    }
}
