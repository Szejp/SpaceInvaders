using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public float Life {
        get {
            return life;
        }
        set {
            life = value;
            if (life <= 0) Disable();
        }
    }

    public float Shield {
        get {
            return shield;
        }
        set {
            shield = value;
        }
    }

    [SerializeField]
    private GameObject OnDisableEffect;
    [SerializeField]
    private float life;
    [SerializeField]
    private float shield;
    [SerializeField]
    private GameObject shieldObject;

    public virtual void SetDamage(int points) {
        for (int i = 0; i < points; i++) {
            if (Shield > 0) { SetShieldDamage(1); }
            else {
                Life--;
            }
        }
    }

    public virtual void SetShieldDamage(int damage) {
        Shield -= damage;
        StartCoroutine(ShieldEffect());
    }

    public virtual void Disable() {
        if (OnDisableEffect != null) Instantiate(OnDisableEffect, gameObject.transform.position, OnDisableEffect.transform.rotation);
        gameObject.SetActive(false);
    }

    private IEnumerator ShieldEffect() {
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        shieldObject.SetActive(false);
    }
}
