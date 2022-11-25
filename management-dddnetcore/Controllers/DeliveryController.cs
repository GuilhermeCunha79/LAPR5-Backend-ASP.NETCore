using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _service;

        public DeliveryController(IDeliveryService service) {
            _service = service;
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDTO>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDTO>> GetById(Guid id)
        {
            var delivery = await _service.GetByIdAsync(new Identifier(id));

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }
        
        // GET: api/Warehouses/ById/5M4
        [HttpGet("ByIdentifier/{deliveryIdentifier}")]
        public async Task<ActionResult<DeliveryDTO>> GetByDeliveryId(string deliveryIdentifier)
        {
            var delivery = await _service.GetByDeliveryIdAsync(deliveryIdentifier);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        // POST: api/Deliveries
        [HttpPost]
        public async Task<ActionResult<DeliveryDTO>> Create(DeliveryDTO dto)
        {
            var list = await _service.GetAllAsync();
            if (list != null)
            {
                foreach (var deliveryDto in list)
                {
                    if (deliveryDto.DeliveryIdentifier.Equals(dto.DeliveryIdentifier))
                    {
                        return BadRequest(new
                            { Message = "This Delivery identifier already exists try another one." });
                    }
                }
            }
            
            try
            {
                var delivery = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = delivery.Id }, delivery);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


        // PUT: api/Deliveries/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryDTO>> Update(Guid id, DeliveryDTO dto)
        {
            // if (id != dto.Id)
            // {
            //     return BadRequest();
            // }
            
            dto.Id = id;

            try
            {
                //var showDelivery = await GetGetById(id); 

                var delivery = await _service.UpdateAsync(dto);

                if (delivery == null)
                {
                    return NotFound();
                }

                return Ok(delivery);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {  ex.Message });
            }
        }
        
        // PUT: api/Delivery/5
        [HttpPut("ByIdentifier/{deliveryIdentifier}")]
        public async Task<ActionResult<DeliveryDTO>> UpdateByDeliveryIdAsync(string deliveryIdentifier, DeliveryDTO dto)
        {
            dto.DeliveryIdentifier = deliveryIdentifier;

            try
            {

                var delivery = await _service.UpdateByDeliveryIdAsync(dto);

                if (delivery == null)
                {
                    return NotFound();
                }

                return Ok(delivery);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // Inactivate: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryDTO>> SoftDelete(Guid id)
        {
            var delivery = await _service.InactivateAsync(new Identifier(id));

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<DeliveryDTO>> HardDelete(Guid id)
        {
            try
            {
                var delivery = await _service.DeleteAsync(new Identifier(id));

                if (delivery == null)
                {
                    return NotFound();
                }

                return Ok(delivery);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}