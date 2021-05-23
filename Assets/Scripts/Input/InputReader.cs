﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private string characterAxisX = "Horizontal";
    [SerializeField] private string characterAxisY = "Vertical";
    //[SerializeField] private string cursorAxisX = "Mouse X";
    //[SerializeField] private string cursorAxisY = "Mouse Y";

    [SerializeField] private KeyCode previousWeapon = KeyCode.Q;
    [SerializeField] private KeyCode nextWeapon = KeyCode.E;
    [SerializeField] private KeyCode useWeapon = KeyCode.Mouse0;
    [SerializeField] private KeyCode useGrenade = KeyCode.Mouse1;

    [SerializeField] private KeyCode interact = KeyCode.R;

    public Vector3 CharacterMovement()
    {
        Vector3 result = new Vector3();
        result.x = Input.GetAxis(characterAxisX);
        result.z = Input.GetAxis(characterAxisY);
        return result;
    }

    //public Vector3 CursorMovement()
    //{
    //    Vector3 result = new Vector3();
    //    result.x = Input.GetAxis(cursorAxisX);
    //    result.y = Input.GetAxis(cursorAxisY);
    //    return result;
    //}

    public bool PreviousWeapon()
    {
        return Input.GetKeyDown(previousWeapon);
    }

    public bool NextWeapon()
    {
        return Input.GetKeyDown(nextWeapon);
    }

    public bool UseWeaponHold()
    {
        return Input.GetKey(useWeapon);
    }

    public bool UseGrenadeHold()
    {
        return Input.GetKey(useGrenade);
    }

    public bool Interact()
    {
        return Input.GetKeyDown(interact);
    }

    public bool InteractHold()
    {
        return Input.GetKey(interact);
    }
}
