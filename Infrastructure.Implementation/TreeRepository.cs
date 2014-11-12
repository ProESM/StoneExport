using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Infrastructure.Implementation
{
    public class TreeRepository : ITreeRepository
    {
        private TreeContext _context = new TreeContext();

        //private readonly IDtoFetcher<TreeDao, TreeDto> _treeDtoFetcher;
        //private IKernel _kernel;

        public TreeRepository()
        {
            //_treeDtoFetcher = new TreeDtoFetcher(this);
        }

        // Вызываем деструктор и вызываем метод Dispose у контекста данных, чтобы быть уверенным, что подключение к базе данных закрыто
        ~TreeRepository()
        {
            _context.Dispose();
        }

        public IQueryable<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TreeDto> GetTrees()
        {
            var treeDaos = _context.TreeDaos;            
            var x = treeDaos.ToList().ToDtos();
            return x;
        }

        public void UpdateTree(TreeDto tree)
        {
            var treeDao = _context.TreeDaos.Find(tree.Id);
            if (treeDao != null)
            {
                treeDao.Name = tree.Name;

                _context.Entry(treeDao).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
