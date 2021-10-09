using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GizmosColors
{
    //Spawn Position - Magenta
    public static readonly Color spawnPosition = new Color(1F, 0F, 1F, 1F);

    //Camera - Black
    public static readonly Color cameraRange = new Color(0F, 0F, 0F, 1F);
    public static readonly Color cameraPosition = new Color(0F, 0F, 0F, 1F);

    //Interaction - Orange
    public static readonly Color interactionRange = new Color(1F, 0.5F, 0F, 1F);
    public static readonly Color interactionTarget = new Color(1F, 0.5F, 0F, 1F);

    ////Targeting
    //public static readonly Color targetablePosition = new Color(0F, 1F, 1F, 1F);

    ////Attack
    //public static readonly Color attackInactive = new Color(1F, 1F, 1F, 0.5F);
    //public static readonly Color attackActive = new Color(1F, 0.5F, 0.5F, 1F);
    //public static readonly Color attackHit = new Color(1F, 0F, 0F, 1F);

    ////Projectile
    //public static readonly Color projectileTarget = new Color(1F, 0F, 0F, 1F);
    //public static readonly Color projectileSeekRange = new Color(1F, 0F, 1F, 0.5F);

    //Decision - Depends on AIState: White, Yellow, Red
    public static readonly Color decisionStateNormal = new Color(1F, 1F, 1F, 1F);
    public static readonly Color decisionStateSearch = new Color(1F, 1F, 0F, 1F);
    public static readonly Color decisionStateEngage = new Color(1F, 0F, 0F, 1F);

    //Detection - Cyan/Blue
    public static readonly Color sightRange = new Color(0F, 0F, 1F, 1F);
    public static readonly Color sightRadius = new Color(0F, 1F, 1F, 1F);
    public static readonly Color detectedCharacter = new Color(0F, 1F, 1F, 1F);

    //Navigation - Green
    public static readonly Color navigationPath = new Color(0F, 1F, 0F, 1F);
    public static readonly Color navigationFirstPos = new Color(0.5F, 1F, 0.5F, 1F);
    public static readonly Color navigationLastPos = new Color(0.5F, 1F, 0.5F, 1F);
    public static readonly Color navigationDir = new Color(0.5F, 1F, 0.5F, 1F);
}
