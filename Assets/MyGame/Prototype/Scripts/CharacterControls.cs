﻿using MyCompany.MyGame.Prototype;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    /// <summary>
    /// The actor is the game object in the game world
    /// representing this character/entity
    /// </summary>
    [SerializeField] private GameObject actor; // SerializeField allows for the object to be accessible through the inspector

    /// <summary>
    /// Movement speed is linearly multiplied by this value.
    /// </summary>
    [SerializeField] private float moveSpeedModifier = 3;

    [SerializeField] private WeaponController.WeaponControllerData weaponData;
    private WeaponController weaponController;

    private Vector3 mousePosition;
    private Vector3 lookDirection;

    private void Awake()
    {
        weaponController = new WeaponController(weaponData);
    }
    public void FixedUpdate()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Quaternion lookRotation = GetMouseInput();
        actor.transform.rotation = lookRotation;

        Vector3 moveDirection = GetInput();
        actor.transform.Translate(moveDirection * Time.deltaTime * moveSpeedModifier, Space.World);

        if (Input.GetMouseButton(0))
        {
            weaponController.Use();
        }
    }

    private Vector3 GetInput()
    {
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        return input;
    }

    private Quaternion GetMouseInput()
    {
        /*
         * Get the position of the mouse on screen in pixel coord
         * pixel coord is (0,0) on bottom left corner of screen
         */
        Vector2 mousePos = Input.mousePosition; 

        /*
         * Get relative position with the idea that the character is in the middle of the screen
         */
        Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width / 2, mousePos.y - Screen.height / 2);
        float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        return rot;
    }
}
