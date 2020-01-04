using MyCompany.GameFramework.Physics.Interfaces;
using UnityEngine;

namespace MyCompany.MyGame.Obstacles
{
    public class GenericObstacle : MonoBehaviour, ICollisionEnterHandler
    {
        public void Handle(GameObject instigator, Collision collision)
        {
            //TODO Implement damage code here.
            //TODO Implement knockback code here.
            Debug.Log($"Game object entered: {instigator.name}");
        }
    }
}
