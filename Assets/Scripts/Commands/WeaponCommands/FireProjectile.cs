using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : FireWeapon
{
    public Projectile Projectile { get; set; }

    private Vector3 direction;

    public FireProjectile(Projectile projectile, Transform gun, Vector3? direction = null)
    {
        this.gun = gun;
        this.Projectile = projectile;
        if (direction != null)
        {
            this.direction = (Vector3)direction;
        }
        else
        {
            this.direction = gun.gameObject.transform.forward;
        }
    }

    public override void Execute()
    {
        Projectile.objectFiredFrom = gun.GetComponentInParent<Agent>();
        if (CheckFireFrequency())
        {
            if (Projectile != null)
            {
                GameObject b = MonoBehaviour.Instantiate(Projectile.gameObject, gun.position, Projectile.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(direction.normalized * Projectile.Speed);
                b.transform.localScale = new Vector3(b.transform.localScale.x, b.transform.localScale.y,
                    (-1) * direction.y * b.transform.localScale.z);
            }
        }
    }
}
