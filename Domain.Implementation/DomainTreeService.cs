using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Infrastructure;
using Ninject;

namespace Domain.Implementation
{
    public class DomainTreeService : IDomainTreeService
    {
        private IKernel _kernel;
        private ITreeRepository _treeRepository;

        public DomainTreeService()
        {
            _kernel = new StandardKernel();
            _kernel.AddBindings();

            _treeRepository = _kernel.Get<ITreeRepository>();
        }

        public IEnumerable<TreeDto> GetTrees()
        {
            return _treeRepository.GetTrees();
        }

        public void UpdateTree(TreeDto tree)
        {
            _treeRepository.UpdateTree(tree);
        }
    }
}
