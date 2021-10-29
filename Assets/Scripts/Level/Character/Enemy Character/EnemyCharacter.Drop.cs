using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCharacter : AbstractCharacter
{
    [Header("Drop")]
    [SerializeField] private AbstractPickup droppedItem;

    private void Drop()
    {
        if (!droppedItem) return;
        Instantiate(droppedItem, null);
    }
}
