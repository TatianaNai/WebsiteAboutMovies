﻿using PortalAboutEverything.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace PortalAboutEverything.Models.Movie
{
	public class MovieUpdateViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[MovieDescription]
		public string? Description { get; set; }

		[Display(Name = "Год выхода фильма")]
		public int ReleaseYear { get; set; }

		[Required(ErrorMessage = "Не заполнено имя режиссера")]
		[ForbiddenSymbols("#@%*<>")]
		[Display(Name = "Имя режиссера")]
		public string Director { get; set; }

		public int Budget { get; set; }

		[Required(ErrorMessage = "Не заполнена страна производства")]
		[ForbiddenSymbols("!#@%*?$№<>")]
		[Display(Name = "Страна производства")]
		public string CountryOfOrigin { get; set; }
	}
}
