using MyCompany.GameFramework.Physics.Interfaces;
using UnityEngine;

namespace MyCompany.MyGame.Sandbox
{
    public class ProjectileTest : MonoBehaviour, ICollisionEnterHandler
    {
        public void Handle(GameObject instigator, Collision collision)
        {
            Debug.Log($"OUCH! I was hit by {instigator.name}");
        }
    }
}
