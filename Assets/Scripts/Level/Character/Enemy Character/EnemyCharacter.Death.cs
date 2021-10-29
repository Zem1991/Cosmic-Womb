using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCharacter : AbstractCharacter
{
    protected override void Die()
    {
        LevelController.Instance.ReportDeadEnemy(this);
        Drop();
        base.Die();
    }

    //TODO: this game's Arch-vile and its resurrection mechanic
}
