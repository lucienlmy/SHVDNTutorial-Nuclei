﻿using System.ComponentModel;

namespace Nuclei.Enums.UI;

public enum WeaponItemTitle
{
    [Description("Give all weapons in game.")]
    GiveAllWeapons,

    [Description("Infinite ammunition.")] InfiniteAmmo,

    [Description(
        "Combine this with infinite ammunition to shoot like a complete maniac.\n\nRequires Infinite Ammo to be checked.")]
    NoReload,

    [Description("Ablaze your enemies with fire!")]
    FireBullets,

    [Description("Who doesn't love explosions?")]
    ExplosiveBullets,

    [Description("Levitate objects, vehicles and people with your gun.")]
    LevitationGun,

    [Description("Aim at an entity and hold down J.")] GravityGun,

    [Description("Teleport to any location by shooting at the location.")]
    TeleportGun,

    [Description(
        "What is even more fun than bullets? Vehicles as bullets.\n\n~b~Note: This version is just for testing purposes only - we'll make it better later.")]
    VehicleGun
}
