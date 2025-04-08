using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Projectiles
{
    public class ProjectilePool : IProjectileProvider
    {
        private readonly ProjectileCollection projectileCollection;
        private readonly DiContainer container;

        private Dictionary<ProjectileType, Queue<ProjectileData>> typeToPoolMap; // Хранит пулы по типу объекта        
        private Transform poolHolderTransform;

        public ProjectilePool(ProjectileCollection projectileCollection, DiContainer container)
        {
            this.projectileCollection = projectileCollection;
            this.container = container;

            InitializePool();
        }

        public void InitializePool()
        {
            typeToPoolMap = new Dictionary<ProjectileType, Queue<ProjectileData>>();            

            poolHolderTransform = new GameObject("Projectile Pool").GetComponent<Transform>();

            foreach (var projectileConfig in projectileCollection.Projectiles)
            {
                ProjectileType type = projectileConfig.ProjectileType;

                if (!typeToPoolMap.ContainsKey(type))
                    typeToPoolMap[type] = new Queue<ProjectileData>();

                for (int i = 0; i < projectileConfig.Amount; i++)
                {
                    GameObject obj = container.InstantiatePrefab(projectileConfig.ProjectilePrefab, poolHolderTransform);
                    obj.SetActive(false);
                    IProjectile projectile = obj.GetComponent<IProjectile>();
                    ProjectileData data = new ProjectileData(obj, projectile, projectileConfig.Speed);
                    obj.GetComponent<Projectile>().ProjectileData = data;

                    typeToPoolMap[type].Enqueue(data);                    
                }
            }
        }

        public ProjectileData GetProjectile(ProjectileType objectType)
        {
            if (!typeToPoolMap.ContainsKey(objectType))
            {
                Debug.Log($"Пул с именем группы {objectType} не найден!");
                return default;
            }

            Queue<ProjectileData> pool = typeToPoolMap[objectType];

            if (pool.Count > 0)
            {
                return pool.Dequeue();
            }
            else
            {
                Debug.LogWarning($"Пул {objectType} пуст!");
                return default;
            }
        }        
    }
}
