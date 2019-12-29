using UnityEngine;

namespace MyCompany.MyGame.Prototype
{
    public class WeaponController
    {
        [System.Serializable]
        public struct WeaponControllerData
        {
            public GameObject projectilePrefab;
            public Transform projectileSpawnPoint;
        }

        private GameObject projectilePrefab; // Game object to spawn
        private Transform projectileSpawnPoint; // Position to spawn

        public WeaponController(WeaponControllerData weaponData)
        {
            projectilePrefab = weaponData.projectilePrefab;
            projectileSpawnPoint = weaponData.projectileSpawnPoint;
        }

        public void Use()
        {
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            GameObject spawnedProjectile = GameObject.Instantiate(projectilePrefab, projectileSpawnPoint.transform.position,
                projectileSpawnPoint.transform.rotation);
            Projectile projectile = spawnedProjectile.AddComponent<Projectile>();
            projectile.Init(projectileSpawnPoint.transform.forward);
            projectile.Shoot();
        }
    }
}