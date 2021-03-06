﻿using System;
using System.Collections.Generic;
using System.Linq;
using __DT_PROJECT_NAME.Common;
using Microsoft.AspNetCore.Mvc;

namespace __DT_PROJECT_NAME.WebApi.Controllers {

    [Route("api/v1/[controller]")]
    [ApiController]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class SampleController : ControllerBase {
        readonly IAppSupport _appSupport;

        public SampleController(IAppSupport appSupport) {
            _appSupport = appSupport ?? throw new ArgumentNullException(nameof(appSupport));
        }

        [HttpGet("connection")]

        // uncomment when using Mvc YodaService filter. (useful for swagger)
        // [ProducesResponseType(typeof(YodaServiceResult<IEnumerable<string>>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<string>> GetSampleConnection() {
            return new string[] { _appSupport.SAMPLE_CONNECTION?.Url, _appSupport.SAMPLE_CONNECTION?.User };
        }

        [HttpGet("parameters")]
        public ActionResult<IDictionary<string, string>> GetParameters() => Ok(_appSupport.Params);

        [HttpGet("authorizations")]
        public ActionResult<IDictionary<string, bool>> GetAuthorizations() {
            return Ok(new Dictionary<string, bool> { { "IsCanRead", _appSupport.IsCanRead }, { "IsCanWrite", _appSupport.IsCanWrite } });
        }

        [HttpGet("flat-result")]
        // [YodaServiceResultIgnore] // uncomment when using Mvc YodaService filter and want to bypass it!
        public ActionResult<string> GetFlat() => "Hi! I am a string!";

        [HttpPost]
        public void Post([FromBody] string value) { }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}
