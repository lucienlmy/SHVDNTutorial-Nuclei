﻿using System;
using Nuclei.Services.Vehicle.VehicleHandling;
using Nuclei.UI.Menus.Base;

namespace Nuclei.UI.Menus.Vehicle.VehicleHandling;

public class VehicleHandlingMenu : GenericMenuBase<VehicleHandlingService>
{
    public VehicleHandlingMenu(Enum @enum) : base(@enum)
    {
    }
}