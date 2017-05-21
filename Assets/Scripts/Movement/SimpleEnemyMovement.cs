using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : Movement
{
    public int goLeft = 1;

    protected override void Start()
    {
        SetDefaultMovementConstraints();
        downConstraint = -Mathf.Infinity;
        base.Start();
    }

    private void Update()
    {
        moveDown.Execute();
        if (goLeft == 1)
        {
            moveLeft.Execute();
        }
        else
        {
            moveRight.Execute();
        }
    }
}
