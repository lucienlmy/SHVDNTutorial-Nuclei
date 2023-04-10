﻿using System;
using GTA;
using Nuclei.Helpers.Utilities;

namespace Nuclei.Services.Vehicle.VehicleSpawner;

public class VehicleSpawnerService : IVehicleSpawnerService
{
    public static VehicleSpawnerService Instance = new();

    /// <summary>
    ///     A property that indicates whether the spawned vehicle should have its engines running.
    /// </summary>
    public BindableProperty<bool> EnginesRunning { get; } = new();

    /// <summary>
    ///     A property that indicates whether the spawned vehicle should be warped into.
    /// </summary>
    public BindableProperty<bool> WarpInSpawned { get; } = new();

    /// <summary>
    ///     A property that indicates which seat the spawned vehicle should be warped into.
    /// </summary>
    public BindableProperty<VehicleSeat> VehicleSeat { get; } = new();


    /// <summary>
    ///     An event that is raised when a vehicle is spawned.
    /// </summary>
    public event EventHandler<VehicleHash> VehicleSpawned;

    /// <summary>
    ///     Spawns a vehicle with the given VehicleHash.
    /// </summary>
    /// <param name="vehicleHash"></param>
    public void SpawnVehicle(VehicleHash vehicleHash)
    {
        VehicleSpawned?.Invoke(this, vehicleHash);
    }
}