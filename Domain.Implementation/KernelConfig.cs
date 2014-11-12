using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Implementation;
using Ninject;

namespace Domain.Implementation
{
    public static class KernelConfig
    {
        public static IKernel AddBindings(this IKernel kernel)
        {
            kernel.Bind<IBaseTreeDao>().To<TreeDao>();
            kernel.Bind<ITreeRepository>().To<TreeRepository>();
            kernel.Bind<IDomainTreeService>().To<DomainTreeService>();
            //kernel.Bind<IDtoFetcher<TreeDao, TreeDto>>().To<TreeDtoFetcher>();
            //kernel.Bind<IDaoFetcher<TreeDto, TreeDao>>().To<TreeDaoFetcher>();            
            return kernel;
        }
    }
}
