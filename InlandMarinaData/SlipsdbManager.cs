using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InlandMarinaData
{
    public class SlipsdbManager
    {
        // Get all slips that are not leased
        public static List<Slip> GetSlipsNotLeased(InlandMarinaContext db)
        {
            return db.Slips
                     .Where(s => !s.Leases.Any()) // Check slips without leases
                     .Include(s => s.Dock) // Include dock information
                     .ToList();
        }

        // Get slips filtered by dock ID and not leased
        public static List<Slip> GetSlipsByDock(int dockId, InlandMarinaContext db)
        {
            return db.Slips
                     .Where(s => s.DockID == dockId && !s.Leases.Any())
                     .Include(s => s.Dock)
                     .ToList();
        }

        // Get slips leased by a specific customer
        public static List<Lease> GetLeasedSlipsByCustomer(int customerId, InlandMarinaContext db)
        {
            return db.Leases
                     .Where(l => l.CustomerID == customerId) // Filter by customer ID
                     .Include(l => l.Slip) // Include slip information
                     .ThenInclude(s => s.Dock) // Include associated dock
                     .ToList();
        }
    }
}
