using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private AbstractCharacter shooter;
    [SerializeField] private Attack attack;
    [SerializeField] private float radius;
    [SerializeField] private float growth;
    [SerializeField] private float damage;

    [Header("Runtime")]
    [SerializeField] private float radiusCurrent;
    [SerializeField] private List<AbstractCharacter> characterHitList = new List<AbstractCharacter>();

    public void Initialize(AbstractCharacter shooter, Attack attack, float explosionRadius, float explosionGrowth, float explosionDamage)
    {
        this.shooter = shooter;
        this.attack = attack;
        radius = explosionRadius;
        growth = explosionGrowth;
        damage = explosionDamage;
    }

    private void Awake()
    {
        radiusCurrent = 0;
    }
    
    private void FixedUpdate()
    {
        if (radiusCurrent >= radius) Destroy(gameObject);

        float growthPerFrame = growth * Time.fixedDeltaTime;
        radiusCurrent += growthPerFrame;
        transform.localScale = Vector3.one * radiusCurrent;
    }

    private void OnTriggerEnter(Collider other)
    {
        AbstractCharacter character = other.GetComponent<AbstractCharacter>();
        if (!character) return;

        if (characterHitList.Contains(character)) return;
        characterHitList.Add(character);

        Vector3 characterHitPos = character.GetTargetablePosition();
        float distance = Vector3.Distance(characterHitPos, transform.position);
        float ratio = Mathf.InverseLerp(radius, 0, distance);

        int impactDamage = Mathf.RoundToInt(damage * ratio);
        character.TakeDamage(impactDamage);
    }
}
