using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Unity
{
    public class UnityConfig
    {

        public static UnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            #region IProxy
            //container.RegisterType<IContractRepository, ContractRepository>();

            #endregion

            return container;
        }
    }
}
