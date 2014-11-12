using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Base;
using DTO;

namespace Infrastructure.Implementation
{
    /// <summary>
    /// DAO модель к таблице L_TREE
    /// </summary>
    [Table("l_tree")]
    public class TreeDao : IBaseTreeDao
    {
        [Key]        
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }        
        [Required(ErrorMessage = "Наименование обязательно должно быть заполнено.")]
        [Display(Name = "Наименование")]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string ShortName { get; set; }
        [Required(ErrorMessage = "Состояние обязательно должно быть заполнено.")]
        public Guid StateId { get; set; }
        [Required(ErrorMessage = "Тип объекта обязательно должен быть заполнен.")]
        public Guid TypeId { get; set; }
        [Required(ErrorMessage = "Дата и время создания обязательно должны быть заполнены.")]
        [Column(TypeName = "datetime2")]
        public DateTime CreateDateTime { get; set; }
    }

    public static class TreeDaoExtentions
    {
        public static TreeDto ToDto(this TreeDao treeDao)
        {
            var treeDto = new TreeDto
            {
                Id = treeDao.Id,
                ParentId = treeDao.ParentId,
                Name = treeDao.Name,
                ShortName = treeDao.ShortName,
                StateId = treeDao.StateId.ToStateNames(),
                TypeId = treeDao.TypeId.ToObjectTypeNames(),
                CreateDateTime = treeDao.CreateDateTime
            };            

            return treeDto;
        }

        public static IEnumerable<TreeDto> ToDtos(this IEnumerable<TreeDao> treeDaos)
        {
            return treeDaos.Select(ToDto).ToList();
        }
    }
}
