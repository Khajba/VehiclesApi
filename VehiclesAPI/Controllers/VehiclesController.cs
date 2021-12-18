using Application.Services.VehiclesServices.Queries.GetVehiclebyId;
using Application.Services.VehiclesServices.Queries.GetVehiclesList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehiclesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController :  ControllerBase
    {
        private readonly IMediator _mediator;
        public VehiclesController(IMediator mediator) => _mediator = mediator;


        // GET: VehiclesController
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehiclesModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehiclesList()
        {
            var vehicles = await _mediator.Send(new VehiclesListQuery());
            return Ok(vehicles);
        }



        [HttpGet ("test")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> test()
        {
            var test = await _mediator.Send(new TestQuery());
            return Ok(test);
        }

        // GET: VehiclesController/Details/5
        [HttpGet("VehicleDetails")]
        [ProducesResponseType(typeof(VehiclesModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> VehicleDetails(int id)
        {
            var query = new VehicleByIdQuery
            {
                Id = id
            };
            var vehicle = await _mediator.Send(query);
            return Ok(vehicle);
        }

        //// GET: VehiclesController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: VehiclesController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: VehiclesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: VehiclesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: VehiclesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: VehiclesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
