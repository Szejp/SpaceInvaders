using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : Movement
{
    [SerializeField]
    private float time = 1;
    private float timeElapsed;

    protected override void Start()
    {
        base.Start();
        timeElapsed = time;
    }

    protected void Update()
    {
        RandomizeMovements();
        ExecuteMovements();
    }

    private void RandomizeMovements()
    {
        if (movements == null) return;
        if (timeElapsed > time)
        {
            for (int i = 0; i < movements.Length; i++)
            {
                if (i == 2) continue;
                if (Random.Range(0, 2) == 1)
                {
                    movements[i].toExecute = true;
                }
                else
                {
                    movements[i].toExecute = false;
                }
            }
            timeElapsed = 0;
        }
        else
        {
            timeElapsed += Time.deltaTime;
        }
    }

    private void ExecuteMovements()
    {
        foreach (Command m in movements)
        {
            if (movements != null && movements.Length > 0 && m != null && m.toExecute) m.Execute();
        }
    }
}
