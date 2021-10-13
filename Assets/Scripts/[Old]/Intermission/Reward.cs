using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [Header("Identification")]
    [SerializeField] private string title;
    [SerializeField] [TextArea] private string description;
    [SerializeField] private Sprite sprite;

    //[Header("Effects")]
    //[SerializeField] private List<AbstractEffect> effectList = new List<AbstractEffect>();

    #region Identification
    public string GetTitle()
    {
        return title;
    }
    public string GetDescription()
    {
        return description;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    #endregion

    #region Effects
    public List<AbstractEffect> GetEffectList()
    {
        AbstractEffect[] abstractEffects = GetComponents<AbstractEffect>();
        return new List<AbstractEffect>(abstractEffects);
    }
    public bool ApplyAll(AbstractCharacter target)
    {
        List<AbstractEffect> effectList = GetEffectList();
        foreach (AbstractEffect forEffect in effectList)
        {
            forEffect.Apply(target);
        }
        return true;
    }
    #endregion
}
