using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Base;

namespace Infrastructure.Implementation
{
    public class StoneExportDbInitializer : DropCreateDatabaseAlways<TreeContext> //CreateDatabaseIfNotExists<TreeContext>
    {
        protected override void Seed(TreeContext context)
        {
            //context.Database.ExecuteSqlCommand("ALTER TABLE dbo.l_tree ADD CONSTRAINT DefaultDate DEFAULT GETDATE() FOR CreateDateTime");

            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.Root, ParentId = null, Name = "Все объекты", ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.SystemSettings, ParentId = SystemObjects.Root, Name = "Настройки системы", ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.SystemObjectStates, ParentId = SystemObjects.SystemSettings, Name = "Системные состояния объектов дерева", ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.SystemObjectTypes, ParentId = SystemObjects.SystemSettings, Name = "Все типы объектов", ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );

            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = ObjectStates.osActive, ParentId = SystemObjects.SystemObjectStates, Name = DisplayNameHelper.GetDisplayName(typeof(ObjectStates), "osActive"), ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            
            //var treeList = new List<TreeDao>()
            //{
            //    new TreeDao() { Id = 0, ParentId = null, Name = "Все объекты", ShortName = null, StateId = 0, TypeId = 0 },
            //    new TreeDao() { Id = 3, ParentId = 1, Name = "Настройки системы", ShortName = null, StateId = 0, TypeId = 0 }
            //};
            //treeList.ForEach(t => context.TreeDaos.Add(t));
                       
            context.SaveChanges();

            base.Seed(context);
        }        
    }
}
