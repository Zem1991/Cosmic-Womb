using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Character : MonoBehaviour
{
    //[Header("Damage")]

    public virtual bool TakeDamage(int amount)
    {
        //TODO: later the MainCharacter will use Armor as damage reduction, pretty much like in Doom/Quake
        return LoseHealth(amount);
    }
}
