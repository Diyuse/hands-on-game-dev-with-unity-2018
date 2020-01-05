using MyCompany.GameFramework.Coroutines;
using System.Collections;
using MyCompany.GameFramework.ResourceSystem;
using MyCompany.GameFramework.ResourceSystem.Interfaces;
using UnityEngine;

namespace MyCompany.MyGame.Weapons
{
    public class Pistol : IWeapon
    {
        private WeaponData weaponData;
        // private int currentAmmo; //Replacing this to allow for ammo to be display on the HUD
        private IResource ammo;
        private bool isReloading = false;
        private float lastFire = 0;
        private Transform actorLocation;

        public IResource Ammo
        {
            get { return ammo; }
        }

        public Pistol(WeaponData weaponData, GameObject actor)
        {
            this.weaponData = weaponData;
            ammo = new Ammo(weaponData.MaxAmmo);
            actorLocation = actor.transform;
        }

        public bool Shoot()
        {
            if (lastFire + weaponData.MinFireInterval > Time.time)
            {
                // Debug.LogWarning("CLICK");
                return false;
            }

            if (isReloading)
            {
                // Debug.LogWarning("RELOADING");
                return false;
            }

            if (ammo.CurrentValue > 0)
            {
                ammo.Remove(1.0f);
                lastFire = Time.time;
                SpawnProjectile();
                // Debug.Log(string.Format("PEW {0}/{1}", currentAmmo, weaponData.MaxAmmo));
                return true;
            }

            if (ammo.CurrentValue <= 0 && weaponData.DoesAutoReload)
            {
                // Debug.LogWarning("RELOADING");
                Reload();
                return false;
            }
            else
            {
                // Debug.LogWarning("Out of ammo!");
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
            // Debug.LogError("RELOAD COMPLETE");
            ammo.Add(weaponData.MaxAmmo);
            isReloading = false;
        }
    }
}
