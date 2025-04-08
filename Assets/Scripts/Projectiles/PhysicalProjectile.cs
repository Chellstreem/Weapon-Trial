using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PhysicalProjectile : Projectile
{
    private Rigidbody2D rb;   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    public override void Launch(Vector2 direction, float speed)
    {
        Vector2 normalizedDirection = direction.normalized;        
        rb.AddForce(normalizedDirection * speed, ForceMode2D.Impulse);        
    }
}
