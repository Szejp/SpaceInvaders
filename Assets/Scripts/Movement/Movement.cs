using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Command moveLeft;
    public Command moveRight;
    public Command moveUp;
    public Command moveDown;

    public Command[] movements;

    [SerializeField]
    protected float speed = 100;
    [SerializeField]
    protected float leftConstraint;
    [SerializeField]
    protected float rightConstraint;
    [SerializeField]
    protected float upConstraint;
    [SerializeField]
    protected float downConstraint;
    protected Vector3 previousPosition;

    public void SetMovementConstraints(float left, float right, float up, float down)
    {
        if (leftConstraint == 0) leftConstraint = left;
        if (rightConstraint == 0) rightConstraint = right;
        if (upConstraint == 0) upConstraint = up;
        if (downConstraint == 0) downConstraint = down;
    }

    protected virtual void Start()
    {
        SetDefaultMovementConstraints();
        movements = new Command[4];
        if (moveLeft == null)
        {
            moveLeft = new MoveLeft(gameObject, speed, new Vector2(leftConstraint, rightConstraint));
            movements[0] = moveLeft;
        }
        if (moveRight == null)
        {
            moveRight = new MoveRight(gameObject, speed, new Vector2(leftConstraint, rightConstraint));
            movements[1] = moveRight;
        }
        if (moveUp == null)
        {
            moveUp = new MoveUp(gameObject, speed, new Vector2(downConstraint, upConstraint));
            movements[2] = moveUp;
        }
        if (moveDown == null)
        {
            moveDown = new MoveDown(gameObject, speed, new Vector2(downConstraint, upConstraint));
            movements[3] = moveDown;
        }
    }

    protected void SetDefaultMovementConstraints()
    {
        if (GameOvermind.Instance != null)
        {
            SetMovementConstraints(GameOvermind.Instance.leftConstraint, GameOvermind.Instance.rightConstraint,
                GameOvermind.Instance.upConstraint, GameOvermind.Instance.downConstraint);
        }
    }

    protected void LateUpdate()
    {
        previousPosition = gameObject.transform.position;
    }
}
