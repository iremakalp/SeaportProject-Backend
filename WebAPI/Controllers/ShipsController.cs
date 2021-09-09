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
    public class ShipsController : ControllerBase
    {
        IShipService _shipService;
        public ShipsController(IShipService shipService)
        {
            _shipService = shipService;
        }
        [HttpGet("gett")]
        public IActionResult Get()
        {
            var result = _shipService.Get();
            return Ok(result);
            
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _shipService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetails")]
        public IActionResult GetDetail()
        {
            var result = _shipService.GetDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyname")]
        public IActionResult GetByName(string shipName)
        {
            var result = _shipService.GetByName(shipName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbytype")]
        public IActionResult GetByType(int typeId)
        {
            var result = _shipService.GetByTypeId(typeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyflag")]
        public IActionResult GetByFalg(string flag)
        {
            var result = _shipService.GetByFalg(flag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyport")]
        public IActionResult GetByPort(int portId)
        {
            var result = _shipService.GetByPort(portId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbydock")]
        public IActionResult GetByDock(int dockNumaber)
        {
            var result = _shipService.GetByDock(dockNumaber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyimo")]
        public IActionResult GetByImoNo(int imoNo)
        {
            var result = _shipService.GetByImoNo(imoNo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbystatus")]
        public IActionResult GetByStatus(bool status)
        {
            var result = _shipService.GetByStatus(status);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbytonnage")]
        public IActionResult GetByTonnage(float maxTonnage, float minTonnage)
        {
            var result = _shipService.GetByTonnage(maxTonnage,minTonnage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyleavingdate")]
        public IActionResult GetByLeavingDate(DateTime leavingDate)
        {
            var result = _shipService.GetByLeavingDate(leavingDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbydockingdate")]
        public IActionResult GetByDockingDate(DateTime dockingDate)
        {
            var result = _shipService.GetByDockingDate(dockingDate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybreadth")]
        public IActionResult GetByBreadth(float maxBreadth, float minBreadth)
        {
            var result = _shipService.GetByBreadth(maxBreadth,minBreadth);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbylength")]
        public IActionResult GetByLength(float maxLength, float minLength)
        {
            var result = _shipService.GetByLength(maxLength,minLength);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyshipowner")]
        public IActionResult GetByShipowner(int shipownerId)
        {
            var result = _shipService.GetByShipowner(shipownerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Ship ship)
        {
            var result = _shipService.Add(ship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Ship ship)
        {
            var result = _shipService.Update(ship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Ship ship)
        {
            var result = _shipService.Delete(ship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
