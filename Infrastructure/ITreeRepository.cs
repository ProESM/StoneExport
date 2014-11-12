using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Infrastructure
{
    public interface ITreeRepository : IRepository
    {
        IEnumerable<TreeDto> GetTrees();

        void UpdateTree(TreeDto tree);
    }
}
