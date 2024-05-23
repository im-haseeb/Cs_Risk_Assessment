using Cs_Risk_Assessment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cs_Risk_Assessment.Controllers
{
	public class AssessmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Step2([FromForm] IFormCollection formData)
		{
			//return Json(formData);
			List<AssetsViewModel> assetsList = new List<AssetsViewModel>();
			if(formData.Any())
			{
				if(formData.Count > 1)
				{
					for(int i=0; i<=formData.First().Value.Count()-1; i++)
					{
						AssetsViewModel assetsViewModel = new AssetsViewModel
						{
							AssetName = formData["AssetName"][i],
							AssetType = formData["AssetType"][i],
							Reference = formData["Reference"][i],
							Location = formData["Location"][i],
							Owner = formData["Owner"][i],
						};
						assetsList.Add(assetsViewModel);
					}
					return View(assetsList);
				}
			}
			return Json("Data not Found");
		}
	}

}
