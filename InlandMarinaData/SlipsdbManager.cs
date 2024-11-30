using System.Collections.Generic;
using System.Linq;

namespace InlandMarinaData
{
    public class SlipsdbManager
    {
        // Get all slips that are not leased
        public static List<Slip> GetSlipsNotLeased(InlandMarinaContext db)
        {
            return db.Slips.Where(s => !s.Leases.Any()).ToList();
        }

        // Get slips filtered by dock ID and not leased
        public static List<Slip> GetSlipsByDock(int dockId, InlandMarinaContext db)
        {
            return db.Slips.Where(s => s.DockID == dockId && !s.Leases.Any()).ToList();
        }

        // Get all slips (optional for CRUD operations)
        public static List<Slip> GetAllSlips(InlandMarinaContext db)
        {
            return db.Slips.ToList();
        }

        // Other CRUD operations can be added here if needed (e.g., adding or deleting slips)
    }
}
