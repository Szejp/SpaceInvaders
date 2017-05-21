using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile {

    [HideInInspector]
    public bool drawLaser = true;

    private LineRenderer laser;
    private Vector3 initPosition;

    protected void Awake() {
        laser = GetComponent<LineRenderer>();
    }

    protected override void Start() {
        base.Start();
        StartCoroutine(DrawLaserLine());
    }

    private IEnumerator DrawLaserLine() {
        initPosition = transform.position;
        laser.SetPosition(0, initPosition);
        while (drawLaser) {
            laser.SetPosition(1, transform.position);
            Debug.Log(transform.position);
            yield return new WaitForEndOfFrame();
        }
    }
}
