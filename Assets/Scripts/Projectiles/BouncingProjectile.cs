using UnityEngine;
using System.Collections;
using Zenject;

public class BouncingProjectile : Projectile
{
    private Camera mainCamera;   
    
    private bool isMoving = false;

    [Inject]
    public void Construct(Camera mainCamera)
    {
        this.mainCamera = mainCamera;
    }    

    public override void Launch(Vector2 direction, float speed)
    {              
        if (!isMoving)
        {
            StartCoroutine(MoveCoroutine(direction.normalized, ProjectileData.CommonSpeed));            
        }
    }

    private IEnumerator MoveCoroutine(Vector2 direction, float speed)
    {        
        isMoving = true;

        while (true)
        {
            Vector3 position = transform.position;
            Vector3 velocity = direction * (speed * Time.deltaTime);

            position += (Vector3)velocity;

            // Получаем границы экрана в мировых координатах
            Vector2 screenMin = mainCamera.ViewportToWorldPoint(Vector2.zero);
            Vector2 screenMax = mainCamera.ViewportToWorldPoint(Vector2.one);
            
            if (position.x <= screenMin.x || position.x >= screenMax.x)
            {
                direction.x *= -1f; // Отражаем по горизонтали
                position.x = Mathf.Clamp(position.x, screenMin.x, screenMax.x);
            }
            
            if (position.y <= screenMin.y || position.y >= screenMax.y)
            {
                direction.y *= -1f; // Отражаем по вертикали
                position.y = Mathf.Clamp(position.y, screenMin.y, screenMax.y);
            }

            transform.position = position;

            yield return null;
        }
    }    
}
