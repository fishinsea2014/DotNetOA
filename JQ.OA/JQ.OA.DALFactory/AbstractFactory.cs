﻿using JQ.QA.IDal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.DALFactory
{
    /// <summary>
    /// Utilise reflection to create an object
    /// </summary>
    public class AbstractFactory
    {
        private readonly static string DalAssemblyPath = ConfigurationManager.AppSettings["DalAssemblyPath"];
        private readonly static string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        /// <summary>
        /// Create an Userinfo instance
        /// </summary>
        /// <returns></returns>
        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal"; //Construct a full name of a class, include namespace
            return CreateInstance(fullClassName) as IUserInfoDal;

        }


        /// <summary>
        /// Reflection
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        public static object CreateInstance(string fullClassName)
        {
            var assembly = Assembly.Load(DalAssemblyPath); //Load dll files
            return assembly.CreateInstance(fullClassName); 

        }
    }
}
