using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Self references")]
    [SerializeField] private PlayerCursor playerCursor;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform cameraHolder;

    [Header("Other references")]
    [SerializeField] private MainCharacter mainCharacter;
    [SerializeField] private UICrosshair uiCrosshair;
    //[SerializeField] private Weapons weapons;

    [Header("Variables")]
    [SerializeField] private GameObject interactableObj;
    
    private void FixedUpdate()
    {
        if (mainCharacter)
        {
            Movement();
        }
    }
    
    private void Update()
    {
        playerCursor.ReadCursor(Camera.main);

        if (mainCharacter)
        {
            Aim();
            Rotation();

            SearchInteractable();
            Interaction();

            Combat();
        }
    }
    
    private void LateUpdate()
    {
        if (mainCharacter)
        {
            transform.position = mainCharacter.transform.position;
        }
    }

    private void Movement()
    {
        Vector3 moveDir = inputReader.CharacterMovement();
        mainCharacter.MoveAt(moveDir);
    }

    private void Aim()
    {
        if (uiCrosshair)
        {
            Vector2 screenPosition = playerCursor.GetScreenPosition();
            float scale = 1F / mainCharacter.GetAimScale();
            uiCrosshair.UpdateCrosshair(screenPosition, scale);
        }
    }

    private void Rotation()
    {
        Vector3 cursorPos = playerCursor.GetAimPosition();
        mainCharacter.RotateTo(cursorPos);
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
}
