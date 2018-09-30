using EntityService.IServices;
using EntityService.Services;
using EntityService.ViewModels;
using Project.APi.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.APi.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        // GET: api/Category
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CA1822 // Mark members as static

        public async Task<IHttpActionResult> Get()
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return null;
        }

        // GET: api/Category/5
#pragma warning disable CA1822 // Mark members as static

        public string Get(int id)
#pragma warning restore CA1822 // Mark members as static
        {
            return "value";
        }

        // POST: api/Catagory
        public async Task<IHttpActionResult> Post([FromBody]CategoryViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            try
            {
                model = await _categoryService.AddAsync(model);
                CategoryAddOutput output = new CategoryAddOutput
                {
                    Success = true,
                    Data = model,
                    ErrorMessage = null
                };
                if (model != null)
                {
                    return Json(output);
                }

                output.Success = false;
                output.Data = null;
                output.ErrorMessage = "Add Category Fail!";
                return Json(output);
            }
            catch (Exception ex)
            {
                GC.SuppressFinalize(obj: this);
                CategoryAddOutput output = new CategoryAddOutput
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