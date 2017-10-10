using System;
using System.Data;
using System.Linq;
//using DataAccess;
using DomainModel;
using System.Reflection;

namespace WFApp
{
    static class ModuleLoader
    {
        public static IPhoneBookRepository ReturnObject(string path)
        {
            var asm = Assembly.LoadFile(path);
                //Пример поиска типа данных, реализующего интерфейс репозитория:
            var results = from type in asm.GetTypes()
                where typeof (IPhoneBookRepository).IsAssignableFrom(type)
                select type;

                //Пример создания объекта найденного типа данных:
   
            IPhoneBookRepository instance =
                (IPhoneBookRepository) Activator.CreateInstance(results.FirstOrDefault());
            return instance;
        }
    }
}
