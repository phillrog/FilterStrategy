﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterStrategy.Bll.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace FilterStrategy.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IGenereteInvoice _generateInvoice;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IGenereteInvoice generateInvoice)
		{
			_logger = logger;
			_generateInvoice = generateInvoice;
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

			if (filter.BillingType == "3")
				return Ok("Gerado com sucesso a fatura com fretes de perda");
			else
				return Ok("Gerado com sucesso a fatura");
		}
	}
}
