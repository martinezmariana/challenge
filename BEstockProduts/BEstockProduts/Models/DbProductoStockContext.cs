using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BEstockProduts.Models;

public partial class DbProductoStockContext : DbContext
{
    
    public DbProductoStockContext(DbContextOptions<DbProductoStockContext> options)
        : base(options)
    {
    }

    public  DbSet<Producto> Productos { get; set; }

    public  DbSet<Stock> Stocks { get; set; }

    public  DbSet<TipoProducto> TipoProductos { get; set; }

  


   
    

}

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
// => optionsBuilder.UseSqlServer("Data Source=DESKTOP-O8DPDV9;Initial Catalog=DB_PRODUCTO_STOCK;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

