using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : Movement {

    [SerializeField]
    private Transform gun;

    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    private void Update() {
        bool onMouseDown = false;
        int touch = 0;
        for (int i = 0; i < Input.touchCount; i++) {
            onMouseDown = (Input.GetMouseButtonDown(i) || Input.touchCount > 0) && IsMouseOnPlayerSide(Input.touches[i].position);
            if (onMouseDown) {
                touch = i;
                break;
            }
        }

        if ((onMouseDown || Input.GetKey(KeyCode.Space)) && IsMouseOnMiddle(Input.touches[touch].position)) {
            weapon.Shoot();
        }
        else if (onMouseDown && Input.mousePosition.x > Screen.width / 2) {
            ExecuteCommand(moveRight);
        }
        else if (onMouseDown) {
            ExecuteCommand(moveLeft);
        }

        Debug.Log(Input.mousePosition.y - Screen.height / 2);
    }

    private bool IsMouseOnMiddle(Vector3 position) {
        float delta = Screen.width * 0.2f;
        return position.x > Screen.width / 2 - delta && position.x < Screen.width / 2 + delta;
    }

    private bool IsMouseOnPlayerSide(Vector3 position) {
        return (position.y - Screen.height / 2) * gameObject.transform.position.y > 0;
    }
}
