﻿using BirlesikOdeme.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Services.Interfaces
{
    public interface IMernisService
    {
        string CheckTCNumber(Vatandas input);
    }
}