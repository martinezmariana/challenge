using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEstockProduts.Models;

public partial class Stock
{
    public int Id { get; set; }

    public int? IdProductos { get; set; }
    public int? Cantidad { get; set; }

    

   
}
