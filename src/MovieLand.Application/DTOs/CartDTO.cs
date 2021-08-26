﻿using MovieLand.Application.DTOs.Base;
using System.Collections.Generic;


namespace MovieLand.Application.DTOs
{
    public class CartDTO : BaseDTO
    {
        public string Username { get; set; }
        public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
    }
}
