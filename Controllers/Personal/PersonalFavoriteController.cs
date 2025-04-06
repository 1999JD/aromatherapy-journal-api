using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/personal/favorite")]
    [ApiController]
    public class PersonalFavoriteController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("Not implemented yet.");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById()
        {
            throw new Exception("Not implemented yet.");

        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            throw new Exception("Not implemented yet.");

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update()
        {
            throw new Exception("Not implemented yet.");

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete()
        {
            throw new Exception("Not implemented yet.");

        }

    }
}