using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEstockProduts.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int? IdTipoProductos { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

   
   
}
