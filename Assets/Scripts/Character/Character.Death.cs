using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] private bool isDead;
    [SerializeField] private bool canRevive;
    [SerializeField] private int deathCount;

    protected virtual void Die()
    {
        LevelController.Instance.ReportDeadEnemy(this);
        deathCount++;

        //TODO: add animations, and then remove the Destroy() call.
        Destroy(gameObject);
    }
}
