using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Config", menuName = "Scriptable Objects/Projectile Config")]
public class ProjectileConfig : ScriptableObject
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private ProjectileType projectileType;
    [SerializeField] private float speed = 15;
    [SerializeField] private int amount = 10;    

    public GameObject ProjectilePrefab => projectilePrefab;
    public ProjectileType ProjectileType => projectileType;
    public float Speed => speed;
    public int Amount => amount;    
}
