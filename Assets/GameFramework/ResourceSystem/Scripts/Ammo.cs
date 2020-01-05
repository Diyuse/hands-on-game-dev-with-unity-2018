using System;
using MyCompany.GameFramework.ResourceSystem.Interfaces;

namespace MyCompany.GameFramework.ResourceSystem
{
    public class Ammo : IResource
    {
        private float currentAmmo;

        public event Action<float> onValueChanged;

        public float CurrentValue
        {
            get { return currentAmmo; }
        }

        public Ammo(float initialValue)
        {
            currentAmmo = initialValue;
        }

        public float Add(float amount)
        {
            currentAmmo += amount;
            if (onValueChanged != null)
            {
                onValueChanged.Invoke(currentAmmo);
            }

            return currentAmmo;
        }

        public float Remove(float amount)
        {
            currentAmmo -= amount;
            if (onValueChanged != null)
            {
                onValueChanged.Invoke(currentAmmo);
            }

            return currentAmmo;
        }
    }
}
