using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Player : Agent
{
    public static event System.Action OnPlayerDestroyed;

    public override void Disable()
    {
        base.Disable();
        if (OnPlayerDestroyed != null) OnPlayerDestroyed();
    }
}
