using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        public ViewResult List(int productPage) =>
            View(_repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize));
    }
}