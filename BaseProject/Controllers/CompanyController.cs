using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Manager;

namespace BaseProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{

		private readonly ICompanyService _companyService;

		public CompanyController (ICompanyService companyService)
		{
			_companyService = companyService;
		}


		[Authorize]
		[HttpGet]
		public ActionResult<string> Get ()
		{
			return _companyService.Test();
		}





		//// GET api/values
		//[HttpGet]
		//public ActionResult<IEnumerable<string>> Get ()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/values/5
		//[HttpGet("{id}")]
		//public ActionResult<string> Get (int id)
		//{
		//	return "value";
		//}

		//// POST api/values
		//[HttpPost]
		//public void Post ([FromBody] string value)
		//{
		//}

		//// PUT api/values/5
		//[HttpPut("{id}")]
		//public void Put (int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/values/5
		//[HttpDelete("{id}")]
		//public void Delete (int id)
		//{
		//}




	}
}