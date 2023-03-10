
namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Pacagroup.Ecommerce.Application.DTO;
    using Pacagroup.Ecommerce.Application.Interface;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICustomersApplication _customersApplication;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customersApplication"></param>
        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region Metodos Sínconos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customersDto"></param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if(customersDto == null)
            {
                return BadRequest();
            }
            var response = _customersApplication.Insert(customersDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customersDto"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = _customersApplication.Update(customersDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = _customersApplication.Delete(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = _customersApplication.Get(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        #endregion

        #region Metodos Asíncronos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customersDto"></param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = await _customersApplication.InsertAsync(customersDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customersDto"></param>
        /// <returns></returns>
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = await _customersApplication.UpdateAsync(customersDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync/{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = await _customersApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("GetAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = await _customersApplication.GetAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        #endregion
    }
}
