using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Move
{
    public MoveLeft(GameObject ob, float speed, Vector2 constraints)
    {
        maxLeft = constraints.x;
        maxRight = constraints.y;
        this.speed = speed;
        obj = ob;
    }

    public override void Execute()
    {
        positionToMove = new Vector3(obj.transform.position.x - Time.deltaTime * speed, obj.transform.position.y, obj.transform.position.z);
        base.Execute();
    }
}
