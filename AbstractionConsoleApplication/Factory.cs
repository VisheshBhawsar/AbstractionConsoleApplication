using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace AbstractionConsoleApplication
{
    public class Factory
    {
        #region Container Methods

        private static IUnityContainer _container;
        private static readonly object ContainerAccess = new object();
        private static bool _isConfigured;

        public static IUnityContainer Container
        {
            get
            {
                Init();
                return _container;
            }
            set { _container = value; }
        }

        /// <summary>
        /// Initialized the unity container and reads its configuration
        /// </summary>
        public static void Init()
        {
            if (_container == null || _isConfigured == false)
            {
                lock (ContainerAccess)
                {
                    if (_container == null || _isConfigured == false)
                    {
                        try
                        {
                            _container = new UnityContainer();
                            _container.LoadConfiguration();
                            _isConfigured = true;
                        }
                        catch (Exception ex)
                        {
                            // Debug.WriteLine("Unity Load Error!!! - " + ex.Message);
                            throw new Exception(
                                "Unity Configuration Error - Check the <unity> section of your config file.", ex);
                        }
                    }
                }
            }
        }

        #endregion

        //public static T CreateInstance<T>()
        //{
        //    // this is where Unity takes over and does its magic.
        //    var obj = Container.Resolve<T>();
        //    return obj;
        //}

        public static T CreateInstance<T>()
        {
            var obj = Container.Resolve<T>();
            return obj;
        }
    }
}
