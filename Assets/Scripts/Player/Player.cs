﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private PlayerCursor playerCursor;
    [SerializeField] private PlayerAim playerAim;

    [Header("Other references")]
    [SerializeField] private MainCharacter mainCharacter;
    [SerializeField] private UIHandler uiHandler;

    [Header("Variables")]
    [SerializeField] private GameObject interactableObj;

    private void Awake()
    {
        //TODO: Does this really work, or not? I want to use the hardware cursor because legends say it's more accurate/faster.
        Vector2 hotSpot = new Vector2(0, 0);
        CursorMode cursorMode = CursorMode.Auto;
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    //private void FixedUpdate()
    //{
    //    if (mainCharacter)
    //    {
    //        //Movement();     //here?
    //    }
    //}

    private void Update()
    {
        if (mainCharacter)
        {
            //CameraPlacement();
            //CursorPlacement();
            //AimPlacement();

            Movement();     //is better handled inside FixedUpdate()
            //Rotation();

            //CameraPlacement();
            //CursorPlacement();
            //AimPlacement();
        }

        if (mainCharacter)
        {
            SearchInteractable();
            Interaction();
            Combat();
        }
    }
    
    private void LateUpdate()
    {
        if (mainCharacter)
        {
            //DONT CHANGE THIS - UNITY HAS A BUGGED MOUSE POSITON THAT ONLY GIVES YOU THE DELAYED VALUE
            CameraPlacement();
            CursorPlacement();
            AimPlacement();
            //THIS IS WHY I HAVE THESE FUNCTIONS BEING CALLED TWICE, BECAUSE THIS IS THE CLOSEST THING TO 'WORKING'

            CameraControl();
            Rotation();

            //DONT CHANGE THIS - UNITY HAS A BUGGED MOUSE POSITON THAT ONLY GIVES YOU THE DELAYED VALUE
            CameraPlacement();
            CursorPlacement();
            AimPlacement();
            //THIS IS WHY I HAVE THESE FUNCTIONS BEING CALLED TWICE, BECAUSE THIS IS THE CLOSEST THING TO 'WORKING'

            UIRefresh();
            ShowAim();
        }
    }

    private void Movement()
    {
        Vector3 cameraRotationEuler = playerCamera.GetRotation();
        Quaternion cameraRotation = Quaternion.Euler(0, cameraRotationEuler.y, 0);

        Vector3 characterMov = inputReader.CharacterMovement();
        Vector3 moveDirAdjusted = cameraRotation * characterMov;

        mainCharacter.MoveAt(moveDirAdjusted);
    }

    private void SearchInteractable()
    {
        //TODO: write something
        interactableObj = null;
    }

    private void Interaction()
    {
        if (interactableObj == null) return;
        IInteractable interactable = interactableObj.GetComponent<IInteractable>();
        if (inputReader.InteractPress()) mainCharacter.Interact(interactable);
        else if (inputReader.InteractHold()) mainCharacter.InteractContinuous(interactable);
    }

    private void Combat()
    {
        bool previousWeapon = inputReader.PreviousWeapon();
        bool nextWeapon = inputReader.NextWeapon();
        bool useWeaponPress = inputReader.UseWeaponPress();
        bool useWeaponHold = inputReader.UseWeaponHold();
        bool useWeaponRelease = inputReader.UseWeaponRelease();
        //bool useGrenadePress = inputReader.UseGrenadePress();
        //bool useGrenadeHold = inputReader.UseGrenadeHold();
        //bool useGrenadeRelease = inputReader.UseGrenadeRelease();

        if (previousWeapon && !nextWeapon) mainCharacter.SelectPreviousWeapon();
        if (!previousWeapon && nextWeapon) mainCharacter.SelectNextWeapon();

        if (useWeaponHold) mainCharacter.UseWeaponHold();
        //TODO: mash-or-charge weapon, so I can make an UseWeaponRelease() method

        //if (useGrenadePress) mainCharacter.UseGrenadePress();
        ////if (useGrenadeHold) mainCharacter.UseGrenadeHold();
        //if (useGrenadeRelease) mainCharacter.UseGrenadeRelease();
    }

    private void CameraControl()
    {
        float rotation = 0F;
        if (inputReader.CameraRotLeft()) rotation--;
        if (inputReader.CameraRotRight()) rotation++;
        playerCamera.Rotate(rotation);
    }

    private void Rotation()
    {
        Vector3 aimPos = playerAim.GetAimPosition();
        mainCharacter.RotateTo(aimPos, true);
    }

    private void CursorPlacement()
    {
        playerCursor.UpdateCursor(Camera.main);
    }
    
    private void AimPlacement()
    {
        Vector3 mcPos = transform.position;
        if (mainCharacter) mcPos = mainCharacter.transform.position;
        Ray screenRay = playerCursor.GetScreenRay();
        playerAim.UpdateAim(screenRay, mcPos.y);

        float weaponRange = mainCharacter.GetWeapon().GetEffectiveRange();
        Vector3 aimStart = mainCharacter.GetProjectileSpawnPoint();
        Vector3 aimEnd = aimStart + (mainCharacter.GetForwardDirection() * weaponRange);
        playerAim.DrawAimLine(aimStart, aimEnd);
    }

    private void CameraPlacement()
    {
        Vector3 mcPos = transform.position;
        if (mainCharacter) mcPos = mainCharacter.transform.position;
        Vector3 aimPos = playerAim.GetAimPosition();
        playerCamera.SetPosition(mcPos, aimPos);
    }

    private void UIRefresh()
    {
        if (!uiHandler) return;
        uiHandler.UpdatePlayer(mainCharacter);
    }

    private void ShowAim()
    {
        if (uiHandler)
        {
            Weapon weapon = mainCharacter.GetWeapon();
            bool hasBoost = weapon.HasChargeBoost() || weapon.HasAimBoost();

            Vector2 screenPosition = playerCursor.GetScreenPosition();
            Sprite crosshair = weapon.GetCrosshairSprite();
            float scale = hasBoost ? mainCharacter.GetWeaponPower() : 0F;

            uiHandler.UpdateCrosshair(screenPosition, crosshair, scale);
        }
    }
}
