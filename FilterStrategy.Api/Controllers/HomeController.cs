using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterStrategy.Bll.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FilterStrategy.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IGenereteInvoice _generateInvoice;

		public HomeController(IGenereteInvoice GenerateInvoice)
		{
			_generateInvoice = GenerateInvoice;
		}

		[HttpGet]
		public IActionResult Get()
		{
				return Ok("Funcionando");		
		}

		[HttpPost]
		public async Task<IActionResult> GerarFatura([FromBody] AutomaticBillingCustomerEvent filter)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _generateInvoice.GenerateAsync(filter);

			if (filter.BillingType == "2")
				return Ok("Gerado com sucesso a fatura com fretes de perda");
			else
				return Ok("Gerado com sucesso a fatura");
		}
	}
}