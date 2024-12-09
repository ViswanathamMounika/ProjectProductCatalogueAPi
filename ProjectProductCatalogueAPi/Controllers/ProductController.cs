using BussinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace ProjectProductCatalogueAPi.Controllers
{
    public class ProductController : ControllerBase
    {
        ILogic _logic;
        public ProductController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct( Models.product p)
        {
            try
            {
                if (p != null)
                {
                    p.prod_id = Guid.NewGuid();
                    var add = _logic.AddProduct(p);
                    return Ok(add);
                }
                else
                {
                    return BadRequest(p);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllProducts")]
        public ActionResult Get()
        {
            try
            {

                var cat = _logic.GetAllProducts().ToList();
                return Ok(cat);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      

        [HttpGet("GetByProductname")]
        public ActionResult GetbyName(string name)
        {
            try
            {
                if (name != null)
                {
                    var cat = _logic.GetproByName(name);
                    return Ok(cat);
                }
                return BadRequest("name not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByBrand")]
        public ActionResult GetbyBrand(string name)
        {
            try
            {
                if (name != null)
                {
                    var cat = _logic.GetByBrand(name);
                    return Ok(cat);
                }
                return BadRequest("Brand not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProduct")]
        public ActionResult Update(Guid id, Models.product r)
        {
            try
            {
                if (id != null)
                {
                    var up = _logic.UpdateProduct(id, r);
                    return Ok(up);
                }
                else
                {


                    return BadRequest("Id not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveProduct")]
        public IActionResult DeleteProduct( Guid id)
        {
            try
            {
                if (id != null)
                {
                    var r = _logic.DeletePrductById(id);
                    return Ok(r);
                }
                else
                    return BadRequest("something wrong with  input, please try again!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
