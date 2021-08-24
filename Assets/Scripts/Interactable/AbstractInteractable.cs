using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour
{
    public abstract bool CanInteract();
    public abstract bool Interact();
}
