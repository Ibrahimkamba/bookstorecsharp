using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp
{
    class SessionManager
    {
        private static SessionManager _instance;
        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionManager();
                }
                return _instance;
            }
        }

        public string CurrentCustomerId { get; set; }
        public string CurrentCustomerName { get; set; }
        public string CurrentCustomerAddress { get; set; }

        private SessionManager() { }
    }
}
