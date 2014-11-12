using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Domain.Implementation;
using Ninject;

namespace StoneExport.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private IKernel _kernel;
        private IDomainTreeService _treeService;

        public ValuesController()
        {
            _kernel = new StandardKernel();
            _kernel.AddBindings();
            _treeService = _kernel.Get<IDomainTreeService>();
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var treeDtos = _treeService.GetTrees();
            return treeDtos.Select(treeDto => treeDto.Name).ToList();            
        }

        // GET api/values/5
        public string Get(int id)
        {
            var treeDtos = _treeService.GetTrees();

            var treeDto = treeDtos.FirstOrDefault();
            treeDto.Name = "Тест №234";

            _treeService.UpdateTree(treeDto);

            return treeDto.Name;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
