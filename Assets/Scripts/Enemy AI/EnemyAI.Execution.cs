using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    private void Execute()
    {
        character.StopMovement();
        NavigationRefresh();

        switch (decisionAction)
        {
            case AIAction.MOVE:
                character.MoveAt(navigationDir);
                break;
            case AIAction.ROTATE:
                character.RotateTo(decisionPos);
                break;
            case AIAction.MOVE_AND_ROTATE:
                character.MoveAt(navigationDir);
                character.RotateTo(navigationFirstPos);
                break;
            case AIAction.ATTACK:
                character.RotateTo(decisionPos);
                character.UseWeaponHold();
                break;
            case AIAction.MOVE_AND_ATTACK:
                character.MoveAt(navigationDir);
                character.RotateTo(decisionPos);
                character.UseWeaponHold();
                break;
        }
    }
}
