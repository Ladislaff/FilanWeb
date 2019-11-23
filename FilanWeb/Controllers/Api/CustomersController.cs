using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FilanWeb.Models;
using FilanWeb.Dtos;
using AutoMapper;



namespace FilanWeb.Controllers.Api
{
    public class CustomersController : ApiController
    {	
		public ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		public IEnumerable<CostumerDto> GetCostumers()

		{
			return _context.Costumers.ToList().Select(Mapper.Map<Costumer,CostumerDto>);
		}

		public IHttpActionResult GetCostumer(int id)
		{
			var costumer = _context.Costumers.SingleOrDefault(c => c.Id == id);

			if (costumer == null)
			{
				return NotFound();

			}

			return Ok (Mapper.Map<Costumer,CostumerDto> (costumer));

		}

		[HttpPost]
		public IHttpActionResult CreateCostumer(CostumerDto costumerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var costumer = Mapper.Map<CostumerDto, Costumer>(costumerDto);
				_context.Costumers.Add(costumer);
				_context.SaveChanges();

			costumerDto.Id = costumer.Id;

			return Created(new Uri(Request.RequestUri + "/" + costumer.Id), costumerDto) ;

		}
		[HttpPut]
		public void UpdateCostumer(int id, CostumerDto costumerDto)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var costomerInDb = _context.Costumers.SingleOrDefault(c => c.Id == id);


			if (costumerDto == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(costumerDto, costumerDto);
			
			_context.SaveChanges();
		}	
		[HttpDelete]
		public void DeleteCostumer(int id)
		{
			var costomerInDb = _context.Costumers.SingleOrDefault(c => c.Id == id);

			if (costomerInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Costumers.Remove(costomerInDb);
			_context.SaveChanges();
		}
	}
}
