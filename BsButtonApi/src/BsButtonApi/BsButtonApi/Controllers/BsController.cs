using System;
using System.Collections.Generic;
using System.Linq;
using BsButtonApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BsButtonApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BsController : ControllerBase
    {
        private readonly ILogger<BsController> _logger;

        public BsController(ILogger<BsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Gets the list of Bs Items
        /// </summary>
        /// <returns>A newly created BsModel</returns>
        /// <response code="200">Returns the item list</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<BsVerifyViewModel> Get()
        {
            var returnList = new List<BsVerifyViewModel>();
            var returnItem = new BsVerifyViewModel
            {
                ReportId = 1,
                ReportGuid = Guid.NewGuid(),
                ReporterUserName = "Joe",
                ReportedFrom = "Twitter",
                ReportedDateTime = DateTime.Now,
                ReportReason = "BS",
                ReportText = "BS-BS-BS"
            };
            returnList.Add(returnItem);
            returnItem = new BsVerifyViewModel
            {
                ReportId = 2,
                ReportGuid = Guid.NewGuid(),
                ReporterUserName = "John",
                ReportedFrom = "Facebook",
                ReportedDateTime = DateTime.Now,
                ReportReason = "BS2",
                ReportText = "BS-BS-BS 2"
            };
            returnList.Add(returnItem);
            return returnList.ToArray();
        }

        ///// <summary>
        /////     Gets the Bs Item with id
        ///// </summary>
        ///// <returns>A newly created BsModel</returns>
        ///// <response code="200">Returns the item</response>
        ///// <response code="400">If the item is null</response>
        ///// <param name="id"></param>
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[HttpGet]
        //public BsVerifyViewModel GetById(int id)
        //{
        //    var returnList = new List<BsVerifyViewModel>();
        //    var returnItem = new BsVerifyViewModel
        //    {
        //        ReportId = 1,
        //        ReportGuid = Guid.NewGuid(),
        //        ReporterUserName = "Joe",
        //        ReportedFrom = "Twitter",
        //        ReportedDateTime = DateTime.Now,
        //        ReportReason = "BS",
        //        ReportText = "BS-BS-BS"
        //    };
        //    returnList.Add(returnItem);
        //    returnItem = new BsVerifyViewModel
        //    {
        //        ReportId = 2,
        //        ReportGuid = Guid.NewGuid(),
        //        ReporterUserName = "John",
        //        ReportedFrom = "Facebook",
        //        ReportedDateTime = DateTime.Now,
        //        ReportReason = "BS2",
        //        ReportText = "BS-BS-BS 2"
        //    };
        //    returnList.Add(returnItem);
        //    var item = returnList.FirstOrDefault(bs => bs.ReportId == id) ?? new BsVerifyViewModel();
        //    return item;
        //}


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
        /// <response code="400">If the item is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<BsCreateViewModel> AddBs(BsCreateViewModel item)
        {
            return new ActionResult<BsCreateViewModel>(item);
        }
    }
}