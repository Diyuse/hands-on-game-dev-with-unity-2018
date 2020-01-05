using MyCompany.GameFramework.ResourceSystem.Interfaces;
using MyCompany.MyGame.InputManagement;
using UnityEngine;
using UnityEngine.UI;

namespace MyCompany.MyGame.HUD
{
    public class AmmoHud : MonoBehaviour
    {
        [SerializeField] private Text hudText;
        private float maxAmmo;
        private IResource ammo;

        private void Start()
        {
            GameObject player = GameObject.FindWithTag("Player");
            SampleCharacterController scc = player.GetComponent<SampleCharacterController>();
            ammo = scc.Weapon.Ammo;
            maxAmmo = ammo.CurrentValue;
            ammo.onValueChanged += OnValueChanged;
            OnValueChanged(ammo.CurrentValue);
        }

        private void OnValueChanged(float amount)
        {
            hudText.text = string.Format("{0} / {1}", amount, maxAmmo);
        }
    }
}
