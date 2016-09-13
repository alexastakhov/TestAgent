using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaBank.AlfaRobot.ControlCenter.Agent
{
    [Serializable]
    class AppConfiguration
    {
        /// <summary>
        /// URI локальной службы WCF.
        /// </summary>
        public string wcfServiceUri;

        /// <summary>
        /// URI службы WCF управляющего сервера.
        /// </summary>
        public string wcfControlServiceUri;

        /// <summary>
        /// Адрес управляющего сервера.
        /// </summary>
        public string ControlServerAddress;

        /// <summary>
        /// Строка доступа на управляющий сервер.
        /// </summary>
        public string ControlServerAccessString;

        /// <summary>
        /// Список конфигураций сайтов.
        /// </summary>
        public List<SiteConfiguration> Sites;
    }
}
