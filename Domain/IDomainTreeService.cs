using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Domain
{
    public interface IDomainTreeService
    {
        IEnumerable<TreeDto> GetTrees();

        void UpdateTree(TreeDto tree);
    }
}
