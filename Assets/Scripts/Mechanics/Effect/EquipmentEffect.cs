using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentEffect : AbstractEffect
{
    [Header("Equipment")]
    [SerializeField] private AbstractEquipment equipment;

    public override bool Apply(AbstractCharacter target)
    {
        throw new System.NotImplementedException();
    }
}
