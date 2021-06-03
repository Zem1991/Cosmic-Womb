using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private PlayerCursor playerCursor;
    [SerializeField] private PlayerAim playerAim;

    [Header("Other references")]
    [SerializeField] private MainCharacter mainCharacter;
    [SerializeField] private UIHandler uiHandler;

    [Header("Settings")]
    [SerializeField] private float cameraRange = 12.5F;

    [Header("Variables")]
    [SerializeField] private GameObject interactableObj;

    private void OnDrawGizmos()
    {
        Vector3 myPos = transform.position;
        Vector3 chPos = cameraHolder.transform.position;

        Gizmos.color = GizmoColors.cameraRange;
        Gizmos.DrawWireSphere(myPos, cameraRange);

        Gizmos.color = GizmoColors.cameraPosition;
        Gizmos.DrawWireSphere(chPos, 0.25F);
    }

    private void FixedUpdate()
    {
        if (mainCharacter)
        {
            Movement();
        }
    }
    
    private void Update()
    {
        if (mainCharacter)
        {
            Cursor();
            Rotation();
            Aim();
            SearchInteractable();
            Interaction();
            Combat();
            UI();
        }
    }
    
    private void LateUpdate()
    {
        if (mainCharacter)
        {
            CameraControl();
        }
    }

    private void Movement()
    {
        Vector3 moveDir = inputReader.CharacterMovement();
        mainCharacter.MoveAt(moveDir);
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
        if (inputReader.Interact()) mainCharacter.Interact(interactable);
        else if (inputReader.InteractHold()) mainCharacter.InteractContinuous(interactable);
    }
    
    private void Combat()
    {
        bool previousWeapon = inputReader.PreviousWeapon();
        bool nextWeapon = inputReader.NextWeapon();
        bool useWeaponHold = inputReader.UseWeaponHold();
        bool useGrenadeHold = inputReader.UseGrenadeHold();

        if (previousWeapon && !nextWeapon) mainCharacter.SelectPreviousWeapon();
        if (!previousWeapon && nextWeapon) mainCharacter.SelectNextWeapon();
        if (useWeaponHold) mainCharacter.UseWeapon();
        if (useGrenadeHold) mainCharacter.UseGrenade();
    }

    private void UI()
    {
        if (uiHandler)
        {
            uiHandler.UpdatePlayer(mainCharacter);
        }
    }

    private void CameraControl()
    {
        Vector3 mcPos = mainCharacter.transform.position;
        transform.position = mcPos;

        Vector3 aimPos = playerAim.GetAimPosition();
        Vector3 cameraPos = (aimPos + mcPos) / 2F;

        Vector3 distance = cameraPos - mcPos;
        if (distance.magnitude > cameraRange)
        {
            Vector3 distanceClamp = Vector3.ClampMagnitude(distance, cameraRange);
            cameraPos = transform.position + distanceClamp;
        }
        cameraHolder.transform.position = cameraPos;
    }
}
