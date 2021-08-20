public enum AIState
{
    NORMAL,     //Nothing is wrong, everything is fine. No changes.
    ALERT,      //Heard a noise or saw something. Response is heightened.
    SEARCH,     //Enemy is missing. Keeps looking for it.
    ENGAGE      //Enemy is located. Approaches and attacks it.
}