using Microsoft.AspNetCore.Mvc;
using Wissen.Istka.BlogProject.App.Entity.Services;

namespace Wissen.Istka.BlogProject.App.WebMvcUI.ViewComponents
{
	public class CategoryViewComponent : ViewComponent
	{
		//Partial view için aslında viewcomponent yazıyoruz. Partial viewdan avantajlı tarafı , içinde verileri de birlikte çekebiliyoruz.

		private readonly ICategoryService _categoryService;

		public CategoryViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var list = await _categoryService.GetAll();
			return View(list);
		}
	}
}
