using MyCompany.GameFramework.ResourceSystem.Interfaces;
using MyCompany.MyGame.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace MyCompany.MyGame.HUD
{
    public class BossHud : MonoBehaviour
    {
        private IResource health;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Text nameTag;

        private void Start()
        {
            // This has to be start and can't be awake because it would turn into a race with BigBoss
            GameObject boss = GameObject.FindWithTag("Boss");

            BigBoss bossScript = boss.GetComponent<BigBoss>();

            health = bossScript.Health;
            health.onValueChanged += OnValueChanged;
            healthBar.maxValue = health.CurrentValue;
            healthBar.value = health.CurrentValue;

            nameTag.text = "Big Boss Name Goes Here!";
        }

        private void OnValueChanged(float newValue)
        {
            healthBar.value = newValue;
        }
    }
}
