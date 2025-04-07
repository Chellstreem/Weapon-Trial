using System;
using UnityEngine;
using Zenject;

public class ProjectileSwitcher : IInitializable, IProjectileSwitcher
{
    private readonly IWeapon weapon;

    private ProjectileType[] availableProjectiles;
    private int currentIndex;

    public int NextProjectileIndex => (currentIndex + 1) % availableProjectiles.Length;

    public ProjectileSwitcher(IWeapon weapon)
    {
        this.weapon = weapon;

        InitializeProjectileTypes();
        currentIndex = 0;
    }

    public void Initialize()
    {
        weapon.SetProjectile(availableProjectiles[currentIndex]);        
    }

    public void SwitchToNextProjectile()
    {
        currentIndex = NextProjectileIndex;
        weapon.SetProjectile(availableProjectiles[currentIndex]);        
    }

    private void InitializeProjectileTypes()
    {
        availableProjectiles = (ProjectileType[])Enum.GetValues(typeof(ProjectileType));
    }
}
