using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    public bool Spawn(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        playerCharacter.transform.position = position;
        playerCharacter.RotateAt(direction, true);
        playerCharacter.gameObject.SetActive(true);
        return true;
    }

    public bool Despawn()
    {
        playerCharacter.gameObject.SetActive(false);
        return true;
    }
}
