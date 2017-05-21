using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField]
    private Transform gun;
    private FireWeapon weaponToFire;
    [SerializeField]
    private bool isInputEnabled = false;

    [Header("Weapons")]
    [SerializeField]
    private Projectile projectile;

    public void Shoot() {
        weaponToFire.Execute();
    }

    private void Start() {
        if (projectile != null && gun != null) {
            weaponToFire = new FireProjectile(projectile, gun);
            weaponToFire.timeLimit = 0.3f;
        }
    }

    private void FixedUpdate() {
        if (isInputEnabled && Input.GetKeyDown(KeyCode.Space)) {
            weaponToFire.Execute();
        }
    }
}
