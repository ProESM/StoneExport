using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Implementation;
using Ninject;

namespace ConsoleApplication1
{
    class Program
    {
        private static IKernel _kernel;
        private static IDomainTreeService _treeService;

        static void Main(string[] args)
        {   
            _kernel = new StandardKernel();
            _kernel.AddBindings();
            _treeService = _kernel.Get<IDomainTreeService>();

            _treeService.GetTrees();

        }
    }
}
