using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories.Interfaces;

namespace ProductManagementApp.Controllers
{
    public class ProductInventories : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepo<ProductInventory> repo;
        public ProductInventories(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            this.unitOfWork = unitOfWork;
            this.repo = this.unitOfWork.GetRepo<ProductInventory>();
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await this.repo.GetByIdAsync(x => x.CompanyId == id);
            ViewBag.Companies = await this.repo.ExecuteSqlCollection<Company>("SELECT * FROM Companies");
            return View(data);
        }
    }
}
