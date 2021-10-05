﻿using System;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
