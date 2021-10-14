using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerCharacter : AbstractCharacter
{
    [Header("Health")]
    [SerializeField] private new ResourceDoubleMax health;

    public int GetHealthTrueMax()
    {
        return health.TrueMaximum;
    }

    public bool CheckFullHealthTrueMax()
    {
        return health.CheckFullTrueMaximum();
    }

    public bool AddHealthTrueMax(int amount)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return health.AddTrueMaximum(amount);
    }
}
