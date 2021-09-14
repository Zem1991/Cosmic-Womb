using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private InputReader inputReader;
    //[SerializeField] private PlayerCamera playerCamera;
    //[SerializeField] private PlayerCursor playerCursor;
    //[SerializeField] private PlayerAim playerAim;

    [Header("Player Character")]
    [SerializeField] private MainCharacter playerCharacter;
    //[SerializeField] private PlayerUI uiHandler;

    private void Awake()
    {
        //TODO: Does this really work, or not? I want to use the hardware cursor because legends say it's more accurate/faster.
        Vector2 hotSpot = new Vector2(0, 0);
        CursorMode cursorMode = CursorMode.Auto;
        Cursor.SetCursor(null, hotSpot, cursorMode);
    }

    private void Update()
    {
        //TODO: pause button

        if (playerCharacter)
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

        if (playerCharacter)
        {
            SearchInteractable();
            Interaction();
            Combat();
        }
    }
    
    private void LateUpdate()
    {
        if (playerCharacter)
        {
            //DONT CHANGE THIS - UNITY HAS A WEIRD MOUSE POSITON THAT ONLY GIVES YOU THE DELAYED VALUE.
            CameraPlacement();
            CursorPlacement();
            AimPlacement();
            //THIS IS WHY I HAVE THESE FUNCTIONS BEING CALLED TWICE, BECAUSE THIS IS THE CLOSEST TO 'WORKING' THAT I COULD GET.

            CameraControl();
            Rotation();

            transform.position = playerCharacter.transform.position;

            //DONT CHANGE THIS - UNITY HAS A WEIRD MOUSE POSITON THAT ONLY GIVES YOU THE DELAYED VALUE.
            CameraPlacement();
            CursorPlacement();
            AimPlacement();
            //THIS IS WHY I HAVE THESE FUNCTIONS BEING CALLED TWICE, BECAUSE THIS IS THE CLOSEST TO 'WORKING' THAT I COULD GET.

            UIRefresh();
            ShowAim();

            //transform.position = mainCharacter.transform.position;
        }
    }

    private void Movement()
    {
        PlayerCamera playerCamera = PlayerManager.Instance.GetPlayerCamera();

        Vector3 cameraRotationEuler = playerCamera.GetCameraHolderRotation();
        Quaternion cameraRotation = Quaternion.Euler(0, cameraRotationEuler.y, 0);

        Vector3 characterMov = inputReader.CharacterMovement();
        Vector3 moveDirAdjusted = cameraRotation * characterMov;

        playerCharacter.MoveAt(moveDirAdjusted);
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

        if (previousWeapon && !nextWeapon) playerCharacter.SelectPreviousWeapon();
        if (!previousWeapon && nextWeapon) playerCharacter.SelectNextWeapon();

        if (useWeaponHold) playerCharacter.UseWeaponHold();
        //TODO: mash-or-charge weapon, so I can make an UseWeaponRelease() method

        //if (useGrenadePress) mainCharacter.UseGrenadePress();
        ////if (useGrenadeHold) mainCharacter.UseGrenadeHold();
        //if (useGrenadeRelease) mainCharacter.UseGrenadeRelease();
    }

    private void CameraControl()
    {
        PlayerCamera playerCamera = PlayerManager.Instance.GetPlayerCamera();

        float rotation = 0F;
        if (inputReader.CameraRotLeft()) rotation--;
        if (inputReader.CameraRotRight()) rotation++;
        playerCamera.Rotate(rotation);
    }

    private void Rotation()
    {
        PlayerAim playerAim = PlayerManager.Instance.GetPlayerAim();

        Vector3 aimPos = playerAim.GetAimPosition();
        playerCharacter.RotateTo(aimPos, true);
    }

    private void CursorPlacement()
    {
        PlayerCamera playerCamera = PlayerManager.Instance.GetPlayerCamera();
        PlayerCursor playerCursor = PlayerManager.Instance.GetPlayerCursor();
        Camera camera = playerCamera.GetCamera();
        playerCursor.UpdateCursor(camera);
    }
    
    private void AimPlacement()
    {
        PlayerCursor playerCursor = PlayerManager.Instance.GetPlayerCursor();
        PlayerAim playerAim = PlayerManager.Instance.GetPlayerAim();

        Vector3 mcPos = transform.position;
        if (playerCharacter) mcPos = playerCharacter.transform.position;
        Ray screenRay = playerCursor.GetScreenRay();
        playerAim.UpdateAim(screenRay, mcPos.y);

        float weaponRange = playerCharacter.GetWeapon().GetEffectiveRange();
        Vector3 aimStart = playerCharacter.GetProjectileSpawnPoint();
        Vector3 aimEnd = aimStart + (playerCharacter.GetForwardDirection() * weaponRange);
        playerAim.DrawAimLine(aimStart, aimEnd);
    }

    private void CameraPlacement()
    {
        PlayerCamera playerCamera = PlayerManager.Instance.GetPlayerCamera();
        PlayerAim playerAim = PlayerManager.Instance.GetPlayerAim();

        Vector3 mcPos = transform.position;
        if (playerCharacter) mcPos = playerCharacter.transform.position;
        Vector3 aimPos = playerAim.GetAimPosition();
        playerCamera.SetPosition(mcPos, aimPos);
    }

    private void UIRefresh()
    {
        PlayerUI uiHandler = PlayerManager.Instance.GetPlayerUI();

        if (!uiHandler) return;

        uiHandler.UpdatePlayerData(playerCharacter);
        uiHandler.UpdateInteraction(interactionTarget, interactionScreenPos);
    }

    private void ShowAim()
    {
        PlayerUI uiHandler = PlayerManager.Instance.GetPlayerUI();
        PlayerCursor playerCursor = PlayerManager.Instance.GetPlayerCursor();

        if (!uiHandler) return;

        Weapon weapon = playerCharacter.GetWeapon();
        bool hasBoost = weapon.HasChargeBoost() || weapon.HasAimBoost();

        Vector2 screenPosition = playerCursor.GetScreenPosition();
        Sprite crosshair = weapon.GetCrosshairSprite();
        float scale = hasBoost ? playerCharacter.GetWeaponPower() : 0F;

        //TODO: have this method pass mainCharacter and playerCursor as parameters?
        uiHandler.UpdateCrosshair(screenPosition, crosshair, scale);
    }
}
