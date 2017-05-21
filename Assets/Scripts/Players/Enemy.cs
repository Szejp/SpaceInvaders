using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    public int points = 1;
    public static event Action<Enemy> OnEnemyDestroyed;

    public override void Disable()
    {
        base.Disable();
        if (OnEnemyDestroyed != null) OnEnemyDestroyed(this);
    }
}
