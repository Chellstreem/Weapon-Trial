using UnityEngine;


public abstract class Projectile : MonoBehaviour, IProjectile
{
    public ProjectileData ProjectileData {  get; set; }

    public abstract void Launch(Vector2 direction, float speed);
}
