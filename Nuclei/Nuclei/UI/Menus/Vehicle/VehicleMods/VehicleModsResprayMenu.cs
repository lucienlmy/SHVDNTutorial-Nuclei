﻿using System;
using System.Collections.Generic;
using System.Linq;
using GTA;
using Nuclei.Enums.Vehicle;
using Nuclei.Helpers.ExtensionMethods;
using Nuclei.UI.Menus.Base.ItemFactory;

namespace Nuclei.UI.Menus.Vehicle.VehicleMods;

public class VehicleModsResprayMenu : VehicleModsMenuBase
{
    public VehicleModsResprayMenu(Enum @enum) : base(@enum)
    {
    }

    protected override IEnumerable<VehicleMod> GetValidMods()
    {
        return new List<VehicleMod>();
    }

    protected override void PreModTypeMods()
    {
        PrimaryColor();
        SecondaryColor();
        PearlscentColor();
    }

    private void PearlscentColor()
    {
        var listItemSecondaryColor = AddListItem(VehicleModsItemTitles.PearlscentColor,
            () => (int)Service.PearlscentColor, Service,
            (value, index) => { Service.PearlscentColor = (VehicleColor)index; },
            Enumerable.Range(0, Enum.GetValues(typeof(VehicleColor)).Length).Select(index =>
            {
                var count = Enum.GetValues(typeof(VehicleColor)).Length;
                if (index == -1) return $"None {0} / {count - 1}";
                var localizedName = ((VehicleColor)index).GetLocalizedDisplayNameFromHash();
                if (index == count)
                    localizedName += $" {0} / {count - 1}";
                else
                    localizedName += $" {index} / {count - 1}";
                return localizedName;
            }).ToArray());
        listItemSecondaryColor.SetSelectedIndexSafe((int)Service.PearlscentColor);
    }

    private void SecondaryColor()
    {
        var listItemSecondaryColor = AddListItem(VehicleModsItemTitles.SecondaryColor,
            () => (int)Service.SecondaryColor, Service,
            (value, index) => { Service.SecondaryColor = (VehicleColor)index; },
            Enumerable.Range(0, Enum.GetValues(typeof(VehicleColor)).Length).Select(index =>
            {
                var count = Enum.GetValues(typeof(VehicleColor)).Length;
                if (index == -1) return $"None {0} / {count - 1}";
                var localizedName = ((VehicleColor)index).GetLocalizedDisplayNameFromHash();
                if (index == count)
                    localizedName += $" {0} / {count - 1}";
                else
                    localizedName += $" {index} / {count - 1}";
                return localizedName;
            }).ToArray());
        listItemSecondaryColor.SetSelectedIndexSafe((int)Service.SecondaryColor);
    }

    private void PrimaryColor()
    {
        var listItemPrimaryColor = AddListItem(VehicleModsItemTitles.PrimaryColor, () => (int)Service.PrimaryColor,
            Service,
            (value, index) => { Service.PrimaryColor = (VehicleColor)index; },
            Enumerable.Range(0, Enum.GetValues(typeof(VehicleColor)).Length).Select(index =>
            {
                var count = Enum.GetValues(typeof(VehicleColor)).Length;
                if (index == -1) return $"None {0} / {count - 1}";
                var localizedName = ((VehicleColor)index).GetLocalizedDisplayNameFromHash();
                if (index == count)
                    localizedName += $" {0} / {count - 1}";
                else
                    localizedName += $" {index} / {count - 1}";
                return localizedName;
            }).ToArray());
        listItemPrimaryColor.SetSelectedIndexSafe((int)Service.PrimaryColor);
    }
}