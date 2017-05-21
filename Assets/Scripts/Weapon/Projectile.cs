using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Agent objectFiredFrom;
    public int Damage { get { return damage; } }
    public float Speed { get { return projectileSpeed; } }

    [SerializeField]
    private float lifeTime = 2;
    private float time;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject destroyEffect;
    [SerializeField]
    public float projectileSpeed = 7000;

    protected virtual void Start()
    {
        time = Time.realtimeSinceStartup;
    }

    protected virtual void Update()
    {
        if (Time.realtimeSinceStartup - time > lifeTime) Destroy(gameObject);
    }

    protected void OnDestroy()
    {
        Instantiate(destroyEffect, gameObject.transform.position, destroyEffect.transform.rotation);
    }
}
