using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : Move
{
    public MoveDown(GameObject ob, float speed, Vector2 constraints)
    {
        maxDown = constraints.x;
        maxUp = constraints.y;
        this.speed = speed;
        obj = ob;
    }

    public override void Execute()
    {
        positionToMove = new Vector3(obj.transform.position.x, obj.transform.position.y - Time.deltaTime * speed, obj.transform.position.z);
        base.Execute();
    }
}
