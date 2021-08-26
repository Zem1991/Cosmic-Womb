public enum AIAction
{
    NONE,
    MOVE,
    ROTATE,
    MOVE_AND_ROTATE,
    ATTACK,
    MOVE_AND_ATTACK,
    //MOVE_TO,        //Just moves towards position
    //SEARCH_ENEMY,   //Goes to last known position
    //ENGAGE_ENEMY,   //Goes towards enemy
    //ATTACK_ENEMY    //Attacks if enemy is within attack range
    INTERACT
}

public static class AIActionEnum
{
    public static bool IsMove(this AIAction aiAction)
    {
        if (aiAction == AIAction.MOVE) return true;
        if (aiAction == AIAction.MOVE_AND_ROTATE) return true;
        if (aiAction == AIAction.MOVE_AND_ATTACK) return true;
        return false;
    }
}