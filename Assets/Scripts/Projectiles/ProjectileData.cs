using UnityEngine;

public struct ProjectileData
{
    public GameObject GameObject { get; private set; }
    public IProjectile Projectile {  get; private set; }
    public float CommonSpeed { get; private set; }

    public ProjectileData(GameObject gameObject, IProjectile projectile, float speed)
    {
        GameObject = gameObject;
        Projectile = projectile;
        CommonSpeed = speed;
    }
}
