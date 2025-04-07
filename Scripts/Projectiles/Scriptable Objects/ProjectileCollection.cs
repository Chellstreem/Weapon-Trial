using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Collection", menuName = "Scriptable Objects/Projectile Collection")]
public class ProjectileCollection : ScriptableObject
{
    [SerializeField] private ProjectileConfig[] projectiles;
    public ProjectileConfig[] Projectiles => projectiles;
}
