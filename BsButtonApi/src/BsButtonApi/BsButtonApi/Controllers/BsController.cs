using System;
using System.Threading.Tasks;
using BsButtonApi.Service;
using BsButtonApi.Service.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace BsButtonApi.Controllers
{
    [EnableCors]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BsController : ControllerBase
    {
        private readonly BsButtonService _bsButtonService;
        private readonly ILogger<BsController> _logger;

        public BsController(ILogger<BsController> logger, BsButtonService bsButtonService)
        {
            _logger = logger;
            _bsButtonService = bsButtonService;
        }

        /// <summary>
        ///     Gets the list of Unverified Bs Items
        /// </summary>
        /// <returns>A newly created BsModel</returns>
        /// <response code="200">Returns the item list</response>
        /// <response code="204">If nothing found</response>
        /// <response code="400">If error</response>
        [SwaggerOperation(Summary = "Get BS Item List", Description = "Gets the list of Bs Items")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [HttpGet(Name = "GetUnverifiedBsItemList")]
        public async Task<IActionResult> GetUnverifiedBsItemList()
        {
            try
            {
                var bsItemGetResult = await _bsButtonService.GetBsVerifyViewModelList();
                if (!bsItemGetResult.IsSuccess) return StatusCode(StatusCodes.Status400BadRequest);
                if (bsItemGetResult.ReturnValue == null) return StatusCode(StatusCodes.Status204NoContent);
                return Ok(bsItemGetResult.ReturnValue);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }


        /// <summary>
        ///     Gets the Bs Item with id
        /// </summary>
        /// <returns>A newly created BsModel</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="400">If error</response>
        /// <response code="404">If the item is null</response>
        /// <param name="id"></param>
        [SwaggerOperation(Summary = "Get BS Item", Description = "Gets the Bs Item by ID")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetBsItem")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var bsItemGetResult = await _bsButtonService.GetBsItem(id);
                if (!bsItemGetResult.IsSuccess) return StatusCode(StatusCodes.Status400BadRequest);
                if (bsItemGetResult.ReturnValue == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(bsItemGetResult.ReturnValue);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }


        /// <summary>
        ///     Creates a BsItem.
        /// </summary>
        /// <remarks>
        ///     Sample request:
        ///     POST /Bs
        ///     {
        ///     "ReportId": 1,
        ///     "ReporterUserName": "Joe"
        ///     "ReportedName": "Don"
        ///     "ReportedFrom": "Twitter"
        ///     "ReportedDateTime": "11/13/2020"
        ///     "ReportReason": "BS"
        ///     "ReportText": "BS-BS-BS"
        ///     }
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created BsModel</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If there is an error</response>
        /// <response code="404">If the item is not created</response>
        [SwaggerOperation(Summary = "Add BS Item", Description = "Adds the BS Item")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BsCreateViewModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [HttpPost(Name = "Post")]
        public async Task<IActionResult> AddBs([FromBody] [SwaggerParameter(Description = "BS Item", Required = true)]
            BsCreateViewModel item)
        {
            try
            {
                var bsItemAddResult = await _bsButtonService.AddBsItem(item);
                if (!bsItemAddResult.IsSuccess) return StatusCode(StatusCodes.Status400BadRequest);
                if (bsItemAddResult.ReturnValue == null) return StatusCode(StatusCodes.Status404NotFound);
                return Ok(bsItemAddResult.ReturnValue);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}