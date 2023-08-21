using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using UPCFleet.Models;

namespace UPCFleet.Controllers
{
    public class BargeController : Controller
    {
        public readonly UpfleetContext _context;
        public BargeController(UpfleetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBarge()
        {
            var Barge = _context.Barges.ToList();
            return View(Barge);
        }
        public IActionResult GetAllTransaction()
        {
            var trans = _context.Transactions.ToList();
            return View(trans);
        }
        public IActionResult GetBargeOwner()
        {
            var ownerrs = _context.Owners.Where(m=> _context.Barges.Any(b=>b.Owner==m.Owner1)).ToList();
           // var owners = from b in _context.Barges.ToList() join o in _context.Owners.ToList() on b.Owner equals o.Owner1 select b;
                

            ViewBag.bargeList = _context.Barges.ToList();
            

            return View(ownerrs);

        }

        public IActionResult GetTransactionwithTransfer()
        {
            //var Transactions=_context.Transactions.Where(m=>_context.Transfers.Any(t=>t.Transaction==m.Transaction1)).ToList();
            //ViewBag.transfer=_context.Transfers.ToList();
            //var Transactions = (
            //    from m in _context.Transactions
            //   join t in _context.Transfers on m.Transaction1 equals t.Transaction 
            //    select m
            //).ToList();
            
            var list = _context.Transactions.ToList();
            var trans = from m in list
                join b in _context.Barges on m.Barge equals b.Barge1 
                join k in _context.Transfers on m.Transaction1 equals k.Transaction into table1
                select new TransactionViewModel()
                {
                    Barges = b,
                    Transactions = m,
                    //transfers = table1.ToList()
                    transfers = _context.Transfers.Where(t=>t.Transaction==m.Transaction1).ToList()
                };
            return View(trans);
        }
    }
}
