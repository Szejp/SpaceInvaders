using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command
{
    public float speed = 10;

    protected Vector3 previousPosition;
    protected Vector3 positionToMove;
    protected float maxLeft = -Mathf.Infinity;
    protected float maxRight = Mathf.Infinity;
    protected float maxUp = Mathf.Infinity;
    protected float maxDown = -Mathf.Infinity;

    public override void Execute()
    {
        previousPosition = obj.transform.position;
        obj.transform.position = new Vector3(Mathf.Clamp(positionToMove.x, maxLeft, maxRight), Mathf.Clamp(positionToMove.y, maxDown, maxUp), obj.transform.position.z);
    }
}
