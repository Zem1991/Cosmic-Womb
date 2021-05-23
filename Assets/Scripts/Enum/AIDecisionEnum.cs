public enum AIDecision
{
    NONE,
    MOVE_TO,        //Just moves towards position
    SEARCH_ENEMY,   //Goes to last known position
    ENGAGE_ENEMY,   //Goes towards enemy
    ATTACK_ENEMY    //Attacks if enemy is within attack range
}