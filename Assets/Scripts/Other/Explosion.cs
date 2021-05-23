﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Character shooter;
    [SerializeField] private Weapon weapon;
    [SerializeField] private float radius;
    [SerializeField] private float growth;
    [SerializeField] private float damage;

    [Header("Runtime")]
    [SerializeField] private float radiusCurrent;
    [SerializeField] private List<Character> characterHitList = new List<Character>();

    public void Initialize(Character shooter, Weapon weapon, float explosionRadius, float explosionGrowth, float explosionDamage)
    {
        this.shooter = shooter;
        this.weapon = weapon;
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
        Character character = other.GetComponent<Character>();
        if (!character) return;

        if (characterHitList.Contains(character)) return;
        characterHitList.Add(character);

        Vector3 characterHitPos = character.GetTargetablePosition();
        float distance = Vector3.Distance(characterHitPos, transform.position);
        float ratio = Mathf.InverseLerp(radius, 0, distance);

        int impactDamage = Mathf.RoundToInt(damage * ratio);
        character.LoseHealth(impactDamage);
    }
}
