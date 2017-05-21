using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{

    [SerializeField]
    private Weapon[] weapons;
    private float changeTimeLimit = 2;
    private float lastCheck;
    private SimpleEnemyMovement enemyMovement;

    private void Start()
    {
        enemyMovement = GetComponent<SimpleEnemyMovement>();
    }

    private void Update()
    {
        if (Time.realtimeSinceStartup - lastCheck > changeTimeLimit)
        {
            if (enemyMovement != null)
            {
                enemyMovement.goLeft = Random.Range(0, 2);
                lastCheck = Time.realtimeSinceStartup;
            }

            if (weapons != null && weapons.Length > 0)
            {
                for (int i = 0; i < weapons.Length; i++) weapons[i].Shoot();
            }
        }
    }
}
