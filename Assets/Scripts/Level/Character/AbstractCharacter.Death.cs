using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] protected bool isDead;
    [SerializeField] private bool canRevive;
    [SerializeField] private int deathCount;

    protected virtual void Die()
    {
        LevelController.Instance.ReportDeadEnemy(this);
        deathCount++;

        //TODO: add animations, and then remove the Destroy() call.
        Destroy(gameObject);
    }

    //TODO: this game's Arch-vile and its resurrection mechanic
}
