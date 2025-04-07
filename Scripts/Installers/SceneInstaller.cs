using Projectiles;
using UnityEngine;
using Zenject;
using Weapons;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CoroutineRunner coroutineRunner;
    [SerializeField] private ProjectileCollection projectileCollection;    

    public override void InstallBindings()
    {
        Container.Bind<Transform>()
            .FromInstance(weapon.transform)
            .AsSingle();

        Container.Bind<IWeapon>()
            .FromInstance(weapon.GetComponent<Weapon>())
            .AsSingle();

        Container.Bind<Camera>()
            .FromInstance(mainCamera)
            .AsSingle();

        Container.Bind<ICoroutineRunner>()
            .FromInstance(coroutineRunner)
            .AsSingle();

        Container.Bind<ProjectileCollection>()
            .FromInstance(projectileCollection)
            .AsSingle();        

        Container.Bind<IInput>().To<TouchInput>().AsSingle().NonLazy();
        Container.Bind<IRotator>().To<Rotator>().AsSingle();
        Container.BindInterfacesTo<ProjectilePool>().AsSingle().NonLazy();
        Container.BindInterfacesTo<ProjectileSwitcher>().AsSingle().NonLazy();
    }
}
