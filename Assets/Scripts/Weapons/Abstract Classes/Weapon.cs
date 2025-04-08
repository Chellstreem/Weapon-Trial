using UnityEngine;
using Zenject;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private Transform barrelTransform; // откуда будут вылетать снаряды
        protected IProjectileProvider projectileProvider;
        protected IBarrel barrel;

        private ProjectileType currentProjectile;

        [Inject]
        private void Construct(IProjectileProvider projectileProvider)
        {
            this.projectileProvider = projectileProvider;
        }

        public void SetProjectile(ProjectileType projectileType)
        {
            currentProjectile = projectileType;
            Debug.Log($"Действующий снаряд: {currentProjectile} projectile");
        }

        public virtual void Shoot(Vector2 direction, float speed)
        {
            ProjectileData projectileData = projectileProvider.GetProjectile(currentProjectile);
            projectileData.GameObject.transform.position = barrelTransform.position;
            projectileData.GameObject.SetActive(true);

            projectileData.Projectile.Launch(direction, speed);            
        }

        
    }
}
