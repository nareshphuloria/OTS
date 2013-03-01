#region Using directives

using Microsoft.Practices.Unity;
using OTS.CommonLayer.Unity;
using OTS.CommonLayer.Mapper;

#endregion

namespace OTS.CommonLayer.UnityExtension
{
    public class OTSUnityContainerExtension
    {
        public static void InitializeContainer()
        {
            //Initializes unity container and registers interface with service classes 
            InitializeUnityContainer();
        }

        public static void InitializeUnityContainer()
        {
            OTSUnityContainer.InitializeContainer();

            #region Registration of Classes

            OTSUnityContainer.Container.RegisterType<IObjectMapper, ObjectMapper>();

            #endregion
        }
    }
}