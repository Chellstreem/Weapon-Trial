using UnityEngine;

public interface IProjectileProvider
{
    public ProjectileData GetProjectile(ProjectileType type);
}
