using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FilanWeb.Models;
using FilanWeb.Dtos;

namespace FilanWeb.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Costumer,CostumerDto>();
			Mapper.CreateMap<CostumerDto, Costumer>();

			Mapper.CreateMap<Movie, MoviesDto>();
			Mapper.CreateMap<MoviesDto, Movie>();
		}
	}
	
}