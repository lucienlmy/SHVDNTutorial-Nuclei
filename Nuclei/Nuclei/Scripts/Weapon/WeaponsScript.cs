﻿using System;
using GTA;
using GTA.Native;
using Nuclei.Scripts.Generics;
using Nuclei.Services.Weapon;

namespace Nuclei.Scripts.Weapon;

public class WeaponsScript : GenericScriptBase<WeaponsService>
{
    protected override void SubscribeToEvents()
    {
        Tick += OnTick;
        Service.AllWeaponsRequested += OnAllWeaponsRequested;
        GameStateTimer.SubscribeToTimerElapsed(UpdateWeapons);
    }

    public override void UnsubscribeOnExit()
    {
        Tick -= OnTick;
        Service.AllWeaponsRequested -= OnAllWeaponsRequested;
        GameStateTimer.UnsubscribeFromTimerElapsed(UpdateWeapons);
    }

    private void OnTick(object sender, EventArgs e)
    {
        if (Character == null) return;

        UpdateFeature(() => Service.FireBullets, ProcessFireBullets);
        UpdateFeature(() => Service.InfiniteAmmo, ProcessInfiniteAmmo);
        UpdateFeature(() => Service.NoReload, ProcessNoReload);
    }

    private void UpdateWeapons(object sender, EventArgs e)
    {
        if (Character == null) return;
    }

    private void ProcessInfiniteAmmo(bool infiniteAmmo)
    {
        if (!infiniteAmmo) return;
        if (!Character.IsReloading &&
            Character.Weapons.Current.Ammo != Character.Weapons.Current.AmmoInClip) return;
        if (Character.Weapons.Current.Ammo == Character.Weapons.Current.AmmoInClip &&
            Character.Weapons.Current.Ammo >= 10)
            return; // For minigun and other weapons with shared clipSize

        Character.Weapons.Current.Ammo = Character.Weapons.Current.MaxAmmo;
        Character.Weapons.Current.AmmoInClip = Character.Weapons.Current.MaxAmmoInClip;
    }

    private void ProcessNoReload(bool noReload)
    {
        if (!Character.IsShooting) return;
        var infiniteAmmoNoReload = noReload && Service.InfiniteAmmo;
        if (infiniteAmmoNoReload)
            Function.Call(Hash.REFILL_AMMO_INSTANTLY, Character);

        Character.Weapons.Current.InfiniteAmmoClip = infiniteAmmoNoReload;
        Character.Weapons.Current.InfiniteAmmo = infiniteAmmoNoReload;
    }

    private void ProcessFireBullets(bool isFireBullets)
    {
        if (!isFireBullets) return;
        if (!Character.IsShooting) return;

        Game.Player.SetFireAmmoThisFrame();
    }

    private void OnAllWeaponsRequested(object sender, EventArgs e)
    {
        GiveAllWeapons();
    }

    private void GiveAllWeapons()
    {
        foreach (WeaponHash weaponHash in Enum.GetValues(typeof(WeaponHash))) GiveWeapon(weaponHash);
    }

    private void GiveWeapon(WeaponHash weaponHash)
    {
        var weapon = Character.Weapons.Give(weaponHash, 0, false, true);
        Character.Weapons[weaponHash].Ammo = weapon.MaxAmmo;
    }
}