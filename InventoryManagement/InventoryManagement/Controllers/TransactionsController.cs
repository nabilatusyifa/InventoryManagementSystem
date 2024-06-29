using InventoryManagement.Contracts;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactions _transactions;
        public TransactionsController(ITransactions transactions)
        {
            _transactions = transactions;
        }

        // GET: TransactionsController
        public ActionResult Index()
        {
            var models = _transactions.GetAll();
            return View(models);
        }

        // GET: TransactionsController/Details/5
        public ActionResult Details(int id)
        {
            var result = _transactions.GetById(id);
            return View(result);
        }

        // GET: TransactionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                var result = _transactions.Add(transaction);
                TempData["Message"] = $"Transaction {transaction.TransactionId} added successfuly";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Transaction not added";
                return View();
            }
        }

        // GET: TransactionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionsController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            return View();
        }

        // GET: TransactionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionsController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeletePost(int TransactionId)
        {
            return View();
        }
    }
}
