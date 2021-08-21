using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GizmoColors
{
    //Camera
    public static readonly Color cameraRange = new Color(0F, 1F, 1F, 0.5F);
    public static readonly Color cameraPosition = new Color(0F, 1F, 1F, 1F);

    //Movement
    public static readonly Color movementDirection = new Color(0.25F, 1F, 0.25F, 1F);
    public static readonly Color movementPath = new Color(0F, 1F, 0F, 1F);

    ////Targeting
    //public static readonly Color targetablePosition = new Color(0F, 1F, 1F, 1F);

    ////Attack
    //public static readonly Color attackInactive = new Color(1F, 1F, 1F, 0.5F);
    //public static readonly Color attackActive = new Color(1F, 0.5F, 0.5F, 1F);
    //public static readonly Color attackHit = new Color(1F, 0F, 0F, 1F);

    ////Projectile
    //public static readonly Color projectileTarget = new Color(1F, 0F, 0F, 1F);
    //public static readonly Color projectileSeekRange = new Color(1F, 0F, 1F, 0.5F);

    //Decision
    public static readonly Color decisionPos = new Color(1F, 0F, 0F, 1F);
    public static readonly Color decisionTarget = new Color(1F, 0F, 0F, 1F);

    //Detection
    public static readonly Color detectionSightRange = new Color(1F, 0F, 1F, 0.5F);
    public static readonly Color detectionSightArc = new Color(1F, 0F, 1F, 1F);
    //public static readonly Color detectionTarget = new Color(1F, 0F, 0F, 1F);
}
