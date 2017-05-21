using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : Move
{
    public MoveUp(GameObject ob, float speed, Vector2 constraints)
    {
        maxUp = constraints.y;
        maxDown = constraints.x;
        this.speed = speed;
        obj = ob;
    }

    public MoveUp(GameObject ob, float speed)
    {
        this.speed = speed;
        obj = ob;
    }

    public override void Execute()
    {
        positionToMove = new Vector3(obj.transform.position.x, obj.transform.position.y + Time.deltaTime * speed, obj.transform.position.z);
        base.Execute();
    }
}
