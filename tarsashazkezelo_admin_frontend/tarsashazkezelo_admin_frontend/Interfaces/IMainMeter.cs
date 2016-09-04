﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarsashazkezelo_admin_frontend.Model;

namespace tarsashazkezelo_admin_frontend.Interfaces
{
    interface IMainMeter
    {
        void AddMainMeter(MainMeter mm);

        ObservableCollection<MainMeter> GetMainMeters();
    }
}
