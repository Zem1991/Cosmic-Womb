using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyEffect : AbstractEffect
{
    [Header("Property")]
    [SerializeField] private PropertyType propertyType;
    [SerializeField] private float amount;

    public override bool Apply(AbstractCharacter target)
    {
        throw new System.NotImplementedException();
    }
}
