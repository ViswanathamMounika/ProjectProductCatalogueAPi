using Microsoft.AspNetCore.Mvc;
using BussinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Reflection;

namespace ProjectProductCatalogueAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller

    {
        ILogic _logic;
        public CategoryController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpPost("AddCatagory")]
        public IActionResult AddCatagory(Models.category c)
        {
            try
            {
                if (c != null)
                {
                    var add = _logic.AddCategory(c);
                    return Ok(add);
                }
                else
                {
                    return BadRequest(c);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAllCatagories")]
        public ActionResult Get()
        {
            try
            {

                var cat = _logic.GetAllCatagories().ToList();
                return Ok(cat);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateCatagory")]
        public ActionResult Updatecat(int id ,Models.category c)
        {
            try
            {
                if (id != null)
                {
                    var r = _logic.UpdateCategory(id, c);
                    return Ok(r);
                }
                else
                {
                    return BadRequest("id not found ! please enter correct id");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetByCatagoryName")]
        public ActionResult GetcatByName(string name)
        {
            try
            {
                if (name != null)
                {
                    var cat = _logic.GetByCategoryName(name);
                    return Ok(cat);
                }
                else
                {
                    return BadRequest("name not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Deletecategory")]
        public IActionResult delCategory(string name)
        {
            try
            {
                if (name != null)
                {
                    var r = _logic.DeleteCategory(name);
                    return Ok(r);
                }
                else
                {
                    return BadRequest("please with your entered data");

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
    }
}
