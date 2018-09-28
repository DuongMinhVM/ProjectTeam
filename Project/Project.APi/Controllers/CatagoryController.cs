using EntityService.IServices;
using EntityService.Services;
using EntityService.ViewModels;
using Project.APi.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.APi.Controllers
{
    public class CatagoryController : ApiController
    {
        private readonly ICatagoryService catagoryService;

        public CatagoryController()
        {
            catagoryService = new CatagoryService();
        }

        // GET: api/Catagory
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CA1822 // Mark members as static
        public async Task<IHttpActionResult> Get()
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return null;
        }

        // GET: api/Catagory/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Catagory
        public async Task<IHttpActionResult> Post([FromBody]CatagoryViewModel model)
        {
            try
            {
                model = null;
                model = await catagoryService.AddAsync(model);
                CatagoryAddOutput output = new CatagoryAddOutput
                {
                    Success = true,
                    Data = model,
                    ErrorMessage = null
                };
                if (model != null)
                {
                    return Json(output);
                }
                else
                {
                    output.Success = false;
                    output.Data = null;
                    output.ErrorMessage = "Add Catagory Fail!";
                    return Json(output);
                }
            }
            catch (Exception ex)
            {
                GC.SuppressFinalize(obj: this);
                CatagoryAddOutput output = new CatagoryAddOutput
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
                return Json(output);
            }
        }

        // PUT: api/Catagory/5
#pragma warning disable CA1822 // Mark members as static
        public void Put(int id, [FromBody]string value)
#pragma warning restore CA1822 // Mark members as static
        {
        }

        // DELETE: api/Catagory/5
#pragma warning disable CA1822 // Mark members as static
        public void Delete(int id)
#pragma warning restore CA1822 // Mark members as static
        {
        }
    }
}