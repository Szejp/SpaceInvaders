using UnityEngine;
using System.Collections;

public class Spawner : MonoSingleton<Spawner>
{
    [Header("Enemies")]
    public GameObject enemy;
    public GameObject boss;

    [SerializeField]
    private Transform spawnPlace;

    public void Spawn(GameObject obj)
    {
        if (obj != null)
        {
            Instantiate(obj, new Vector3(Random.Range(GameOvermind.Instance.leftConstraint, GameOvermind.Instance.rightConstraint),
                spawnPlace.position.y, -1), obj.transform.rotation);
        }
    }

    public void Spawn(GameObject obj, Vector3 position)
    {
        if (obj != null)
        {
            Instantiate(obj, new Vector3(Mathf.Clamp(position.x, GameOvermind.Instance.leftConstraint, GameOvermind.Instance.rightConstraint),
                Mathf.Clamp(position.y, GameOvermind.Instance.downConstraint, GameOvermind.Instance.upConstraint), -1), obj.transform.rotation);
        }
    }

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    private IEnumerator GenerateObjects()
    {
        while (true)
        {
            int count = 0;
            while (count < 10)
            {
                Spawn(enemy);
                count++;
                yield return new WaitForSeconds(1);
            }
            Spawn(boss);
        }
    }
}
