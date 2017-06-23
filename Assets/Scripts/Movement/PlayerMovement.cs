using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {
    protected override void Start() {
        base.Start();
    }

    private void Update() {
        MoveWithKeys();
    }

    private void MoveWithKeys() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            ExecuteCommand(moveLeft);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            ExecuteCommand(moveRight);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            ExecuteCommand(moveUp);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            ExecuteCommand(moveDown);
        }
    }
}
