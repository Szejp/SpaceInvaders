using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOvermind : MonoSingleton<GameOvermind>, ISpaceInvaders {
    public Text scoreScreen;
    public int score = 0;

    [Header("Movement constraints")]
    public float leftConstraint;
    public float rightConstraint;
    public float upConstraint;
    public float downConstraint;

    private Agent agent1;
    private Agent agent2;
    private Projectile projectile;

    public virtual void HandleHit(GameObject object1, GameObject object2) {
        agent1 = object1.GetComponent<Agent>();
        agent2 = object2.GetComponent<Agent>();
        projectile = object2.GetComponent<Projectile>();

        if (agent1 != null && agent2 != null) {
            agent1.Disable();
            agent2.Disable();
        }

        if (agent1 != null && projectile != null && projectile.objectFiredFrom.GetType() != agent1.GetType()) {
            agent1.SetDamage(projectile.Damage);
            Destroy(projectile.gameObject);
        }
    }

    public void GameOver(int score) {
    }

    protected override void Awake() {
        base.Awake();
        Enemy.OnEnemyDestroyed += (e => {
            score += e.points;
            scoreScreen.text = score.ToString();
            Debug.Log("event");
        });
    }
}
