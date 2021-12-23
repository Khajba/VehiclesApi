using Application.Services.VehiclesServices.Commands.AddVehicle;
using Application.Services.VehiclesServices.Commands.ReformVehicle;
using Application.Services.VehiclesServices.Queries.GetVehiclebyId;
using Application.Services.VehiclesServices.Queries.GetVehicleOwnersListbyVinCode;
using Application.Services.VehiclesServices.Queries.GetVehiclesList;
using Infrastructure.Entities;
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
    public class VehiclesController : ControllerBase
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


        // GET: VehiclesController/Details/5
        [HttpGet("VehicleByVinCode")]
        [ProducesResponseType(typeof(Vehicles), StatusCodes.Status200OK)]
        public async Task<IActionResult> VehicleByVinCode(string vinCode)
        {
            var query = new VehiclebyVinCodeQuery
            {
                VinCode = vinCode
            };
            var vehicle = await _mediator.Send(query);
            return Ok(vehicle);
        }

        // POST: VehiclesController/AddVehicle
        [HttpPost("AddVehicle")]
        public async Task<IActionResult> AddVehicle(AddVehicleModel request)
        {
            var command = new AddVehicleCommand
            {
                MarkEng = request.MarkEng,
                MarkGeo = request.MarkGeo,
                ModelEng = request.ModelEng,
                ModelGeo = request.ModelGeo,
                VinCode = request.VinCode,
                VehicleNumber = request.VehicleNumber,
                Color = request.Color
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // POST: VehiclesController/SellVehicle
        [HttpPost("SellVehicle")]
        public async Task<IActionResult> SellVehicle(SellVehicleParameters request)
        {
            var command = new SellVehicleCommand
            {
               BuyersPersonalNumbers = request.BuyersPersonalNumbers, 
               VinCode = request.VinCode,
               SellersPersonalNumbers = request.SellersPersonalNumbers,
               UserPersonalNumer =  request.UserPersonalNumer
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // GET: VehiclesController/GetVehiclesOwnerList
        [HttpGet("GetVehiclesOwnerList")]
        [ProducesResponseType(typeof(IEnumerable<VehicleOwnersListModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehiclesOwnerList([FromQuery] VehicleOwnersListParameters request)
        {
            var query = new VehicleOwnersListQuery
            {
                
                VinCode = request.VinCode,
                OrderString = request.OrderString
               
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
