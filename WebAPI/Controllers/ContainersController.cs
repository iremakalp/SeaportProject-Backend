using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        IContainerService _containerService;

        public ContainersController(IContainerService containerService)
        {
            _containerService = containerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _containerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
           return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _containerService.GetContainerDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Container container)
        {
            var result = _containerService.Add(container);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Container container)
        {
            var result = _containerService.Update(container);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Container container)
        {
            var result = _containerService.Delete(container);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbytypename")]
        public IActionResult GetByTypeName(string typeName)
        {
            var result = _containerService.GetByTypeName(typeName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycapacity")]
        public IActionResult GetByCapacity(float maxCapacity, float minCapacity)
        {
            var result = _containerService.GetByCapacity(maxCapacity,minCapacity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycargoweight")]
        public IActionResult GetByCargoweight(float maxCargoweight, float minCargowweight)
        {
            var result = _containerService.GetByCargoweight(maxCargoweight, minCargowweight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbylength")]
        public IActionResult GetByLength(float maxLength, float minLength)
        {
            var result = _containerService.GetByCapacity(maxLength, minLength);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyheight")]
        public IActionResult GetByHeight(float maxHeight, float minHeight)
        {
            var result = _containerService.GetByCapacity(maxHeight, minHeight);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
