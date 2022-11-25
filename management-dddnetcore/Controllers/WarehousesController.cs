using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;


namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehousesController(IWarehouseService service)
        {
            _service = service;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDTO>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDTO>> GetById(Guid id)
        {
            var warehouse = await _service.GetByIdAsync(new Identifier(id));

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // GET: api/Warehouses/ById/5M4
        [HttpGet("ByIdentifier/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDTO>> GetByWarehouseId(string warehouseIdentifier)
        {
            var warehouse = await _service.GetByWarehouseIdAsync(warehouseIdentifier);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // GET: api/Warehouses/ById/5M4
        [HttpGet("ByDesignation/{designation}")]
        public async Task<ActionResult<WarehouseDTO>> GetByDesignation(string designation)
        {
            var warehouse = await _service.GetByDesignationAsync(designation);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // POST: api/Warehouses
        [HttpPost("/api/Warehouses")]
        public async Task<ActionResult<WarehouseDTO>> Create(CreatingWarehouseDTO dto)
        {
            var list = await _service.GetAllAsync();
            if (list != null)
            {
                foreach (var warehouseDto in list)
                {
                    if (warehouseDto.WarehouseIdentifier.Equals(dto.WarehouseIdentifier))
                    {
                        return BadRequest(new
                            { Message = "This warehouse identifier already exists try another one." });
                    }
                }
            }

            try
            {
                var warehouse = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = warehouse.Id }, warehouse);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        // PUT: api/Warehouses/5
        [HttpPut("{id}")]
        public async Task<ActionResult<WarehouseDTO>> Update(Guid id, WarehouseDTO dto)
        {
            // if (id != dto.Id)
            // {
            //     return BadRequest();
            // }

            dto.Id = id;

            try
            {
                var showWarehouse = await GetById(id);

                var warehouse = await _service.UpdateAsync(dto);

                if (warehouse == null)
                {
                    return NotFound();
                }

                return Ok(warehouse);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT: api/Warehouses/5
        [HttpPut("ByIdentifier/{warehouseIdentifier}")]
        public async Task<ActionResult<WarehouseDTO>> UpdateWarehouseAsync(string warehouseIdentifier, WarehouseDTO dto)
        {
            dto.WarehouseIdentifier = warehouseIdentifier;

            try
            {
                var showWarehouse = await GetById(dto.Id);

                var warehouse = await _service.UpdateByWarehouseIdAsync(dto);

                if (warehouse == null)
                {
                    return NotFound();
                }

                return Ok(warehouse);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Inactivate: api/Warehouses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WarehouseDTO>> SoftDelete(Guid id)
        {
            var warehouse = await _service.InactivateAsync(new Identifier(id));

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        // DELETE: api/Warehouses/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<WarehouseDTO>> HardDelete(Guid id)
        {
            try
            {
                var warehouse = await _service.DeleteAsync(new Identifier(id));

                if (warehouse == null)
                {
                    return NotFound();
                }

                return Ok(warehouse);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}