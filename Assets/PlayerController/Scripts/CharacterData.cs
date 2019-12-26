﻿using System;
using UnityEngine;

namespace MyCompany.MyGame.Player
{
    [Serializable] // Ensures that we can see the serialized fields in the inspector
    public class CharacterData
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        [Header("Health")]
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxLives;

        public float MovementSpeed
        {
            get { return movementSpeed; }
        }

        public int MaxHealth
        {
            get { return maxHealth; }
        }

        public int MaxLives
        {
            get { return maxLives; }
        }
    }
}
