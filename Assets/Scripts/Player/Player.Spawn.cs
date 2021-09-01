using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player : MonoBehaviour
{
    public bool Spawn(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        mainCharacter.transform.position = position;
        mainCharacter.RotateAt(direction, true);
        mainCharacter.gameObject.SetActive(true);
        return true;
    }

    public bool Despawn()
    {
        mainCharacter.gameObject.SetActive(false);
        return true;
    }
}
