using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDNetCore.Domain.Warehouses;
using DDDSample1.Domain.Delivery;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Warehouses;
using DDDSample1.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;

namespace DDDSample1.Infrastructure.Delivery
{
    public class DeliveryRepository : BaseRepository<Domain.Delivery.Delivery, Identifier>, IDeliveryRepository
    {

        private readonly DDDSample1DbContext _context;

        public DeliveryRepository(DDDSample1DbContext context) : base(context.Deliveries)
        {
            _context = context;
        }

        public async Task<Domain.Delivery.Delivery> GetByDeliveryIdAsync(string deliveryIdentifier)
        {
            return await _context.Deliveries
                .Where(x => deliveryIdentifier.Equals(x.DeliveryId.DeliveryIdentifier) && x.Active)
                .FirstOrDefaultAsync();

        }

    }
}