using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) 
	{
		if (GameOvermind.Instance != null) 
		{
			GameOvermind.Instance.HandleHit(this.gameObject , other.gameObject );
		}
	}
}
