using AuthorizationWithPermission.MVC.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithPermission.MVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    // GET
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Product()
    {
        var products = await _productService.GetAllListAsync();
        return View(products);
    }
}