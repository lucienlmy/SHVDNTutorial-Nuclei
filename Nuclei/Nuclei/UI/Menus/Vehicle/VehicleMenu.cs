﻿using System;
using System.ComponentModel;
using LemonUI.Menus;
using Nuclei.Enums.UI;
using Nuclei.Services.Vehicle;
using Nuclei.UI.Menus.Base;
using Nuclei.UI.Menus.Vehicle.VehicleMods;
using Nuclei.UI.Menus.Vehicle.VehicleSpawner;
using Nuclei.UI.Menus.Vehicle.VehicleWeapons;

namespace Nuclei.UI.Menus.Vehicle;

public class VehicleMenu : GenericMenuBase<VehicleService>
{
    public VehicleMenu(Enum @enum) : base(@enum)
    {
        AddVehicleSpawnerMenu();
        AddVehicleWeaponsMenu();
        AddVehicleModsMenu();

        AddHeader("Basics");
        RepairVehicle();
        Indestructible();
        SpeedBoost();

        AddHeader("Utilities");
        FlipVehicle();
        LockDoors();
        SeatBelt();
        NeverFallOffBike();
        DriveUnderWater();
        Service.PropertyChanged += OnPropertyChanged;
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Service.CurrentVehicle))
        {
            var item = GetItem<NativeSubmenuItem>(MenuTitles.VehicleMods);
            if (item == null) return;
            item.Enabled = Service.CurrentVehicle != null;
            UpdateAltTitleOnDisable(item, Service.CurrentVehicle != null,
                Service.CurrentVehicle?.LocalizedName + " MENU", "No Vehicle");
        }
    }

    private void AddVehicleModsMenu()
    {
        var vehicleModsMenu = new VehicleModsMenu(MenuTitles.VehicleMods);
        var vehicleModItem = AddMenu(vehicleModsMenu);
        Shown += (sender, args) =>
        {
            UpdateAltTitleOnDisable(vehicleModItem, Service.CurrentVehicle != null,
                Service.CurrentVehicle?.LocalizedName + " MENU",
                "No Vehicle");
        };
    }

    private void AddVehicleWeaponsMenu()
    {
        var vehicleWeaponsMenu = new VehicleWeaponsMenu(MenuTitles.VehicleWeapons);
        AddMenu(vehicleWeaponsMenu);
    }

    private void LockDoors()
    {
        var checkBoxLockDoors = AddCheckbox(VehicleItemTitles.LockDoors, () => Service.DoorsAlwaysLocked,
            @checked => { Service.DoorsAlwaysLocked = @checked; }, Service);
    }

    private void NeverFallOffBike()
    {
        var checkBoxNeverFallOffBike = AddCheckbox(VehicleItemTitles.NeverFallOffBike, () => Service.NeverFallOffBike,
            @checked => { Service.NeverFallOffBike = @checked; }, Service);
    }

    private void DriveUnderWater()
    {
        var checkBoxDriveUnderWater = AddCheckbox(VehicleItemTitles.DriveUnderWater, () => Service.CanDriveUnderWater,
            @checked => { Service.CanDriveUnderWater = @checked; }, Service);
    }

    private void AddVehicleSpawnerMenu()
    {
        var vehicleSpawnerMenu = new VehicleSpawnerMainMenu(MenuTitles.SpawnVehicle);
        AddMenu(vehicleSpawnerMenu);
    }

    private void FlipVehicle()
    {
        var itemFlipVehicle = AddItem(VehicleItemTitles.FlipVehicle, () => { Service.RequestVehicleFlip(); });
    }

    private void SpeedBoost()
    {
        var sliderItemSpeedBoost = AddSliderItem(VehicleItemTitles.SpeedBoost, () => Service.SpeedBoost,
            speedBoostValue => { Service.SpeedBoost = speedBoostValue; }, 0, 5, Service);
    }

    private void SeatBelt()
    {
        var checkBoxSeatBelt = AddCheckbox(VehicleItemTitles.SeatBelt, () => Service.HasSeatBelt,
            @checked => { Service.HasSeatBelt = @checked; }, Service);
    }

    private void RepairVehicle()
    {
        var itemRepairVehicle = AddItem(VehicleItemTitles.RepairVehicle, () => { Service.RequestRepair(); });
    }

    private void Indestructible()
    {
        var checkBoxIndestructible = AddCheckbox(VehicleItemTitles.Indestructible, () => Service.IsIndestructible,
            @checked => { Service.IsIndestructible = @checked; }, Service);
    }
}