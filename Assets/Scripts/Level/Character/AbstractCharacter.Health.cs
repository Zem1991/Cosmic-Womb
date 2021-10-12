using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AbstractCharacter : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Resource health;

    public int GetHealthCurrent()
    {
        return health.Value;
    }

    public int GetHealthMax()
    {
        return health.Maximum;
    }

    public bool CheckNoHealth()
    {
        return health.CheckEmpty();
    }
    
    public bool CheckFullHealth()
    {
        return health.CheckFull();
    }

    public bool AddHealth(int amount)
    {
        //TODO: if already dead, can only come back from specific Revival mechanics
        if (isDead) return false;
        return health.Add(amount);
    }

    private bool SubtractHealth(int amount)
    {
        if (amount <= 0) return false;
        return health.Subtract(amount);
    }
}
