
using Microsoft.AspNetCore.Mvc;

using Pokemon.Interfaces.Services;
using Pokemon.Models.Masters;

using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pokemon.WebApi.Api
{
    [RoutePrefix("api/Master")]
    public class MasterController : ApiController
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpPost]
        [Route("new-master")]
        public async Task<IHttpActionResult> NewMaster(MasterModel model)
        {
            try
            {
                var response = await _masterService.AddMaster(model);

                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}