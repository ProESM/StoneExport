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
                new TreeDao() { Id = SystemObjects.Root, ParentId = null, Name = ReflectionExtensions.GetFieldDisplayName(f => SystemObjects.Root), ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.SystemSettings, ParentId = SystemObjects.Root, Name = ReflectionExtensions.GetFieldDisplayName(f => SystemObjects.SystemSettings), ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.SystemObjectStates, ParentId = SystemObjects.SystemSettings, Name = ReflectionExtensions.GetFieldDisplayName(f => SystemObjects.SystemObjectStates), ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = SystemObjects.SystemObjectTypes, ParentId = SystemObjects.SystemSettings, Name = ReflectionExtensions.GetFieldDisplayName(f => SystemObjects.SystemObjectTypes), ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );

            context.TreeDaos.AddOrUpdate(t => t.Id,
                new TreeDao() { Id = ObjectStates.osActive, ParentId = SystemObjects.SystemObjectStates, Name = ReflectionExtensions.GetFieldDisplayName(f => ObjectStates.osActive), ShortName = null, StateId = ObjectStates.osActive, TypeId = ObjectTypes.otFolder, CreateDateTime = DateTime.Now }
            );
                       
            context.SaveChanges();

            base.Seed(context);
        }        
    }
}
