using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter mainCharacter = other.GetComponent<PlayerCharacter>();
        bool wasApplied = ApplyPickup(mainCharacter);
        if (wasApplied) Destroy(gameObject);
    }

    protected abstract bool ApplyPickup(PlayerCharacter mainCharacter);
}
