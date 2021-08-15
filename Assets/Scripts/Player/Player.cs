using System.Collections;
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
    
    private void FixedUpdate()
    {
        if (mainCharacter)
        {
            Cursor();
            Aim();

            Movement();
            Rotation();

            CameraControl();
            CameraPositioning();
        }
    }
    
    private void Update()
    {
        if (mainCharacter)
        {
            Cursor();
            Aim();

            Rotation();

            SearchInteractable();
            Interaction();
            Combat();

            CameraPositioning();
        }
    }
    
    private void LateUpdate()
    {
        if (mainCharacter)
        {
            Cursor();
            Aim();

            Rotation();

            CameraPositioning();
            UI();
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

    private void CameraControl()
    {
        float rotation = 0F;
        if (inputReader.CameraRotLeft()) rotation--;
        if (inputReader.CameraRotRight()) rotation++;
        playerCamera.Rotate(rotation);
    }

    private void Cursor()
    {
        playerCursor.UpdateCursor(Camera.main);
    }

    private void Rotation()
    {
        Vector3 aimPos = playerAim.GetAimPosition();
        //mainCharacter.RotateTo(aimPos);
        mainCharacter.SetAimPos(aimPos);
    }

    private void Aim()
    {
        float weaponRange = mainCharacter.GetWeapon().GetEffectiveRange();
        Ray screenRay = playerCursor.GetScreenRay();
        Vector3 aimStart = mainCharacter.GetProjectileSpawnPoint();
        Vector3 aimEnd = aimStart + (mainCharacter.GetForwardDirection() * weaponRange);
        playerAim.UpdateAim(screenRay, aimStart, aimEnd);

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
        bool useGrenadePress = inputReader.UseGrenadePress();
        bool useGrenadeHold = inputReader.UseGrenadeHold();
        bool useGrenadeRelease = inputReader.UseGrenadeRelease();

        if (previousWeapon && !nextWeapon) mainCharacter.SelectPreviousWeapon();
        if (!previousWeapon && nextWeapon) mainCharacter.SelectNextWeapon();

        if (useWeaponHold) mainCharacter.UseWeaponHold();
        //TODO: mash-or-charge weapon, so I can make an UseWeaponRelease() method

        if (useGrenadePress) mainCharacter.UseGrenadePress();
        //if (useGrenadeHold) mainCharacter.UseGrenadeHold();
        if (useGrenadeRelease) mainCharacter.UseGrenadeRelease();
    }

    private void UI()
    {
        if (uiHandler)
        {
            uiHandler.UpdatePlayer(mainCharacter);
        }
    }

    private void CameraPositioning()
    {
        Vector3 mcPos = mainCharacter.transform.position;
        Vector3 aimPos = playerAim.GetAimPosition();
        playerCamera.SetPosition(mcPos, aimPos);
    }
}
