using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogistikApp.Data;
using LogistikApp.Models;

namespace LogisticsApp.Controllers
{
    // MVC Controller for handling UI actions
    public class ShipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Create Shipment View (GET)
        public IActionResult Create()
        {
            return View();
        }

        // 2. Post to Create Shipment (From Create View)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoResi,Sender,Recipient,Package")] Shipment shipment)
        {
            if (!ModelState.IsValid)
            {
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage); // or use logging
                    }
                }

                return View(shipment);
            }

            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // 3. Index - View All Shipments
        public async Task<IActionResult> Index()
        {
            var shipments = await _context.Shipments
                .Include(s => s.StatusHistory)
                .ToListAsync();
            return View(shipments);
        }

        // 4. View Details of a Shipment
        public async Task<IActionResult> Details(string noResi)
        {
            if (noResi == null)
            {
                return NotFound();
            }

            var shipment = await _context.Shipments
                .Include(s => s.StatusHistory)
                .FirstOrDefaultAsync(s => s.NoResi == noResi);

            if (shipment == null)
            {
                return NotFound();
            }

            return View(shipment);
        }

        // 5. Update Shipment Status (For MVC, User Submitting Status)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(string noResi, string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return BadRequest("Status cannot be empty.");
            }

            // Convert the status string to an enum value
            if (!Enum.TryParse<ShipmentStatus>(status, out ShipmentStatus shipmentStatus))
            {
                return BadRequest("Invalid status.");
            }

            var shipment = await _context.Shipments
                .Include(s => s.StatusHistory)
                .FirstOrDefaultAsync(s => s.NoResi == noResi);

            if (shipment == null)
            {
                return NotFound();
            }

            // Ensure StatusHistory is initialized
            if (shipment.StatusHistory == null)
            {
                shipment.StatusHistory = new List<ShipmentStatusHistory>();
            }

            // Add status to the shipment's history
            shipment.StatusHistory.Add(new ShipmentStatusHistory
            {
                Status = shipmentStatus,  // Using the enum value
                StatusDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { noResi = noResi });
        }
    }

    // API Controller for handling external requests
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShipmentsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. API to Get Shipment by NoResi
        [HttpGet("{noResi}")]
        public async Task<IActionResult> GetShipment(string noResi)
        {
            var shipment = await _context.Shipments
                .Include(s => s.StatusHistory)
                .FirstOrDefaultAsync(s => s.NoResi == noResi);

            if (shipment == null)
            {
                return NotFound();
            }

            return Ok(shipment);
        }

        // 2. API to Create a New Shipment
        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                _context.Shipments.Add(shipment);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetShipment), new { noResi = shipment.NoResi }, shipment);
            }

            return BadRequest(ModelState);
        }

        // 3. API to Update Status
        [HttpPut("{noResi}")]
        public async Task<IActionResult> UpdateStatus(string noResi, [FromBody] string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return BadRequest("Status cannot be empty.");
            }

            // Convert the status string to an enum value
            if (!Enum.TryParse<ShipmentStatus>(status, out ShipmentStatus shipmentStatus))
            {
                return BadRequest("Invalid status.");
            }

            var shipment = await _context.Shipments
                .Include(s => s.StatusHistory)
                .FirstOrDefaultAsync(s => s.NoResi == noResi);

            if (shipment == null)
            {
                return NotFound();
            }

            // Ensure StatusHistory is initialized
            if (shipment.StatusHistory == null)
            {
                shipment.StatusHistory = new List<ShipmentStatusHistory>();
            }

            // Add status to the shipment's history
            shipment.StatusHistory.Add(new ShipmentStatusHistory
            {
                Status = shipmentStatus,  // Using the enum value
                StatusDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return Ok(shipment);
        }
    }
}
