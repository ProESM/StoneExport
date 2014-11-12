using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    class BaseDataHelper
    {
        
    }

    public static class SystemObjects
    {
        /// <summary>
        /// Корень (родитель) всех объектов
        /// </summary>
        [Display(Name = "Корень (родитель) всех объектов")]
        public static readonly Guid Root = new Guid("C034E889-3B80-42D3-BDAD-5F4E729A905B");
        /// <summary>
        /// Настройки системы
        /// </summary>
        [Display(Name = "Настройки системы")]
        public static readonly Guid SystemSettings = new Guid("0322648B-488A-40C0-9CEE-B3A4F9B572EF");
        /// <summary>
        /// Служебные состояния дерева объектов
        /// </summary>
        [Display(Name = "Служебные состояния дерева объектов")]
        public static readonly Guid SystemObjectStates = new Guid("FB782982-8E78-4DD0-B678-DDC24AF694FC");
        /// <summary>
        /// Все типы объектов
        /// </summary>
        [Display(Name = "Все типы объектов")]
        public static readonly Guid SystemObjectTypes = new Guid("F8984CD8-3409-4C19-8FCE-85A5BD2E3161");
    }

    /// <summary>
    /// Состояния объектов дерева
    /// </summary>    
    public static class ObjectStates
    {
        /// <summary>
        /// Активен
        /// </summary>
        [Display(Name = "Активен")]
        public static readonly Guid osActive = new Guid("63B43B53-DD11-4283-BE14-099A6C33EF49");

        /// <summary>
        /// В разработке
        /// </summary>
        [Display(Name = "В разработке")]
        public static readonly Guid osInDevelopment = new Guid("F37FF71C-D144-4B67-A411-7216E2FBD328");

        /// <summary>
        /// Заблокирован
        /// </summary>
        [Display(Name = "Заблокирован")]
        public static readonly Guid osBlocked = new Guid("A20417F7-7BC2-4DDD-8F8D-A486FDBFB1CF");

        /// <summary>
        /// Удален
        /// </summary>
        [Display(Name = "Удален")]
        public static readonly Guid osDeleted = new Guid("339A6D38-7A40-4F79-BD03-760D470C9258");

        public static StateNames ToStateNames(this Guid objectState)
        {
            if (objectState == ObjectStates.osActive)
                return StateNames.osActive;
            if (objectState == ObjectStates.osBlocked)
                return StateNames.osBlocked;
            if (objectState == ObjectStates.osDeleted)
                return StateNames.osDeleted;
            if (objectState == ObjectStates.osInDevelopment)
                return StateNames.osInDevelopment;

            throw new System.ArgumentException("Для преобразования нет информации о соответствии для указанного значения", "objectState");            
        }
    }

    /// <summary>
    /// Типы объектов дерева
    /// </summary>
    public static class ObjectTypes
    {
        /// <summary>
        /// Папка
        /// </summary>
        [Display(Name = "Папка")]
        public static readonly Guid otFolder = new Guid("A15D22B8-B18D-48FD-8964-DC91E4F7652B");

        /// <summary>
        /// Класс
        /// </summary>
        [Display(Name = "Класс")]
        public static readonly Guid otClass = new Guid("77FF88F5-B741-459E-BCE6-DACC83EC1FE3");

        /// <summary>
        /// Состояние объекта
        /// </summary>
        [Display(Name = "Состояние объекта")]
        public static readonly Guid otState = new Guid("99F326AC-A722-4C81-9D00-87CFF1EA5F25");

        /// <summary>
        /// Тип объекта
        /// </summary>
        [Display(Name = "Тип объекта")]
        public static readonly Guid otType = new Guid("B840752E-5C79-49FF-B985-ACD3862E4530");

        public static ObjectTypeNames ToObjectTypeNames(this Guid objectType)
        {
            if (objectType == ObjectTypes.otClass)
                return ObjectTypeNames.otClass;
            if (objectType == ObjectTypes.otFolder)
                return ObjectTypeNames.otFolder;
            if (objectType == ObjectTypes.otState)
                return ObjectTypeNames.otState;
            if (objectType == ObjectTypes.otType)
                return ObjectTypeNames.otType;

            throw new System.ArgumentException("Для преобразования нет информации о соответствии для указанного значения", "objectType");
        }
    }    

    public enum StateNames
    {
        [Display(Name = "Активен")]
        osActive = 1,
        [Display(Name = "В разработке")]
        osInDevelopment = 2,
        [Display(Name = "Заблокирован")]
        osBlocked = 3,
        [Display(Name = "Удален")]
        osDeleted = 4
    }

    public enum ObjectTypeNames
    {
        [Display(Name = "Папка")]
        otFolder = 1,
        [Display(Name = "Класс")]
        otClass = 2,
        [Display(Name = "Состояние элемента дерева")]
        otState = 3,
        [Display(Name = "Тип объекта")]
        otType = 4
    }
}
