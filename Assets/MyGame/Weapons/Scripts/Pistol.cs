using MyCompany.GameFramework.Coroutines;
using System.Collections;
using UnityEngine;

namespace MyCompany.MyGame.Weapons
{
    public class Pistol : IWeapon
    {
        private WeaponData weaponData;
        private int currentAmmo;
        private bool isReloading = false;
        private float lastFire = 0;
        private Transform actorLocation;

        public Pistol(WeaponData weaponData, GameObject actor)
        {
            this.weaponData = weaponData;
            currentAmmo = weaponData.MaxAmmo;
            actorLocation = actor.transform;
        }

        public bool Shoot()
        {
            if (lastFire + weaponData.MinFireInterval > Time.time)
            {
                Debug.Log("CLICK");
                return false;
            }

            if (isReloading)
            {
                Debug.LogWarning("RELOADING");
                return false;
            }

            if (currentAmmo > 0)
            {
                currentAmmo--;
                lastFire = Time.time;
                SpawnProjectile();
                Debug.Log(string.Format("PEW {0}/{1}", currentAmmo, weaponData.MaxAmmo));
                return true;
            }

            if (currentAmmo <= 0 && weaponData.DoesAutoReload)
            {
                Debug.LogWarning("RELOADING");
                Reload();
                return false;
            }
            else
            {
                Debug.LogWarning("Out of ammo!");
                return false;
            }
        }

        private void SpawnProjectile()
        {
            GameObject instance = GameObject.Instantiate(weaponData.ProjectilePrefab, actorLocation.position, actorLocation.rotation);
            instance.name = "Projectile";
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            rb.velocity = rb.transform.forward.normalized * weaponData.ProjectileSpeed;
            GameObject.Destroy(instance, 5.0f);
        }

        public void Reload()
        {
            isReloading = true;
            CoroutineHelper.RunCoroutine(ReloadTimer); // Because this class doesn't inherit from monobehaviour, we use a helper
        }

        private IEnumerator ReloadTimer()
        {
            float timer = 0;
            while (timer <= weaponData.ReloadTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            Debug.LogError("RELOAD COMPLETE");
            currentAmmo = weaponData.MaxAmmo;
            isReloading = false;
        }
    }
}
