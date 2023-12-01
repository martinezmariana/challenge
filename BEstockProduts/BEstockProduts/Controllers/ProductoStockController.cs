using BEstockProduts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace BEstockProduts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoStockController : ControllerBase
    {
        private readonly DbProductoStockContext _context;

        public ProductoStockController(DbProductoStockContext context)
        {
            _context = context;
        }
        // GET: api/<ProductoStockController>
        [HttpGet]
        public ActionResult GetProductos()
        {
            try
            {
                return Ok(_context.Productos.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET api/<ProductoStockController>/5
        [HttpGet("{id}", Name = "GetProducto")]
        public ActionResult GetProducto(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id == id);

            return Ok(producto);
        }

        // POST api/<ProductoStockController>
        [HttpPost]
        public ActionResult PostProducto([FromBody] Producto producto)
        {
                try
                {
                       _context.Productos.Add(producto);
                       _context.SaveChanges();
                      return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);

               
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
        }

        // PUT api/<ProductoStockController>/5
        [HttpPut("{id}")]
        public ActionResult PutProducto(int id, [FromBody] Producto producto)


        {
            try
            {
                if (producto.Id == id)
                {
                     _context.Entry(producto).State = EntityState.Modified;
                     _context.SaveChanges();
                    return CreatedAtRoute("GetProducto", new { id = producto.Id }, producto);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            
        }

        // DELETE api/<ProductoStockController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProducto(int id)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.Id == id);

                if (producto !=  null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // GET: api/ProductoStock/Stocks
        [HttpGet("Stocks")]
        public ActionResult GetStocks()
        {
            try
            {
                return Ok(_context.Stocks.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ProductoStock/Stocks
        [HttpPost("Stocks")]
        public ActionResult PostStock([FromBody] Stock stock)
        {
            try
            {
                _context.Stocks.Add(stock);
                _context.SaveChanges();

                return CreatedAtAction("GetStock", new { id = stock.Id }, stock);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ProductoStock/Stocks/5
        [HttpPut("Stocks/{id}")]
        public ActionResult PutStock(int id, [FromBody] Stock stock)
        {
            try
            {
                if (stock.Id == id && stock.Id != 0) // Validar que stock.Id sea distinto de cero
                {
                    _context.Entry(stock).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(stock);
                }
                else
                {
                    return BadRequest("IDs no coinciden o el ID es inválido");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/ProductoStock/Stocks/5
        [HttpDelete("Stocks/{id}")]
        public ActionResult DeleteStock(int id)
        {
            try
            {
                var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);

                if (stock != null)
                {
                    _context.Stocks.Remove(stock);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Stock no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET: api/ProductoStock/TipoProductos
        [HttpGet("TipoProductos")]
        public ActionResult GetTipoProductos()
        {
            try
            {
                return Ok(_context.TipoProductos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/ProductoStock/TipoProductos
        [HttpPost("TipoProductos")]
        public ActionResult PostTipoProducto([FromBody] TipoProducto tipoProducto)
        {
            try
            {
                _context.TipoProductos.Add(tipoProducto);
                _context.SaveChanges();

                return CreatedAtAction("GetTipoProducto", new { id = tipoProducto.Id }, tipoProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/ProductoStock/TipoProductos/5
        [HttpPut("TipoProductos/{id}")]
        public ActionResult PutTipoProducto(int id, [FromBody] TipoProducto tipoProducto)
        {
            try
            {
                if (tipoProducto.Id == id)
                {
                    _context.Entry(tipoProducto).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(tipoProducto);
                }
                else
                {
                    return BadRequest("IDs no coinciden");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/ProductoStock/TipoProductos/5
        [HttpDelete("TipoProductos/{id}")]
        public ActionResult DeleteTipoProducto(int id)
        {
            try
            {
                var tipoProducto = _context.TipoProductos.FirstOrDefault(tp => tp.Id == id);

                if (tipoProducto != null)
                {
                    _context.TipoProductos.Remove(tipoProducto);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Tipo de Producto no encontrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
    

