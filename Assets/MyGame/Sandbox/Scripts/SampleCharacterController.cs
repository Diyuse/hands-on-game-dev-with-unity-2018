using MyCompany.GameFramework.InputManagement;
using MyCompany.MyGame.Player;
using MyCompany.MyGame.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCompany.MyGame.InputManagement
{
    public class SampleCharacterController : MonoBehaviour
    {
        [Header("Data Templates")]
        [SerializeField] private CharacterDataTemplate characterDataTemplate;
        [SerializeField] private WeaponDataTemplate weaponDataTemplate;

        [Header("Other")]
        private InputManager inputManager;
        private IWeapon weapon;
        [SerializeField] private Transform weaponBarrel;

        private void Start()
        {
            inputManager = new InputManager(new SampleBindings(), new RadialMouseInputHandler());
            inputManager.AddActionToBinding("shoot", Shoot);
            weapon = new Pistol(weaponDataTemplate.WeaponData, weaponBarrel.gameObject);
        }

        private void FixedUpdate()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            inputManager.CheckForInput();
            Vector2 mouseInput = inputManager.GetMouseVector();
            Quaternion lookRotation = Quaternion.Euler(mouseInput);
            transform.rotation = lookRotation;

            Vector3 input = Vector3.zero;
            input.x = inputManager.GetAxis("Horizontal");
            input.z = inputManager.GetAxis("Vertical");
            transform.Translate(input * Time.deltaTime * characterDataTemplate.Data.MovementSpeed, Space.World);
        }

        private void Shoot()
        {
            weapon.Shoot();
        }
    }
}
