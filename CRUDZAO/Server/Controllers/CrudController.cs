using CRUDZAO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDZAO.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudController : ControllerBase
    {
        private readonly Services.IFakeDBService service;

        public CrudController(Services.IFakeDBService _db)
        {
            service = _db;
        }

        [HttpPost] //create
        public bool Post([FromBody] string str) =>
            service.Db.TryAdd(Guid.NewGuid(), str);

        [HttpGet] //read
        public IEnumerable<ModelRequest> Get() =>
            service.Db.AsEnumerable().Select(q => new ModelRequest() { id = q.Key, value = q.Value });

        [HttpGet("{id}")] //read
        public string Get(Guid id) =>
            service.Db[id];

        [HttpPut]
        public bool Put([FromBody] ModelRequest objeto) =>
            service.Db.TryUpdate(objeto.id, objeto.value, service.Db[objeto.id]);

        [HttpDelete("{key}")] //delete
        public bool Delete(string key)
        {
            string result;
            return service.Db.TryRemove(Guid.Parse(key),out result);
        }
    }
}
