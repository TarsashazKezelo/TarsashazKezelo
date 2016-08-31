using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace tarsashazkezelo_admin_frontend.Model
{
    class User:ObservableObject
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
