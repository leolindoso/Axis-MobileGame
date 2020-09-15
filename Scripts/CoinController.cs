using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D rb;

	public float SpeedY = -1.0f;
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 velocity = rb.velocity;
		velocity.y = SpeedY;
		rb.velocity = velocity;
		if (SpeedY > -3.0f) {
			SpeedY = SpeedY - (0.0005f);

		}
		//print (SpeedY);


	}

	void OnTriggerEnter2D(Collider2D c) {
		// print("COIN BATEU EM TRIGGER: " + c.tag);
		if (c.tag == "ScoreBlock" ) {
            Destroy(gameObject);
		}
		if (c.tag == "Bloco") {
			Destroy(gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D c) {
		// print("COIN BATEU EM COLLISION: " + c.collider.tag);
		if (c.collider.tag == "ScoreBlock" ) {
            Destroy(gameObject);
		}
		if (c.collider.tag == "Bloco") {
			Destroy(gameObject);
		}
	}
}