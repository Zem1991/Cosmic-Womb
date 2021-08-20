﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAI : MonoBehaviour
{
    private void Execute()
    {
        character.StopMovement();
        
        switch (currentDecision)
        {
            case AIAction.MOVE:
                character.MoveAt(navPathFirstDir);
                break;
            case AIAction.ROTATE:
                character.RotateTo(decisionPos);
                break;
            case AIAction.MOVE_AND_ROTATE:
                character.MoveAt(navPathFirstDir);
                character.RotateTo(navPathFirstPos);
                break;
            case AIAction.ATTACK:
                character.RotateTo(decisionPos);
                character.UseWeaponHold();
                break;
            case AIAction.MOVE_AND_ATTACK:
                character.MoveAt(navPathFirstDir);
                character.RotateTo(decisionPos);
                character.UseWeaponHold();
                break;
        }
    }
}