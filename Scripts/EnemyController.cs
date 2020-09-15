using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform spawn;
	public Transform destroy;
	public float MaxY;
	public float MinY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < destroy.position.x) {
	
			Respawn ();
		}
		
	}

	void Respawn() {
		Vector3 newPosition = spawn.position;
		newPosition.y = Random.Range (MinY, MaxY);
		transform.position = newPosition;
	}
}
