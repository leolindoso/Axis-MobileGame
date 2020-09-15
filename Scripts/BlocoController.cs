using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoController : MonoBehaviour {

	// Use this for initialization
	public ScoreController scorecontroller;

	public PlayerController playercontroller;
	public SpawnerController spawnercontroller;
	public GameObject bloco;
	Rigidbody2D rb;

	public bool isBloco = true;

	public float SpeedY = -1.0f;
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 velocity = rb.velocity;
		velocity.y = SpeedY;
		rb.velocity = velocity;
		//print("SpeedY: " + SpeedY);
		if (SpeedY > -9.0f && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().CanStart) {
			SpeedY = SpeedY - (0.0005f);

		}
		//print (SpeedY);


	}

	void OnTriggerEnter2D(Collider2D c) {
		
		if (c.tag == "ScoreBlock") {
			for(int i =0; i<spawnercontroller.ObjInstaciados.Count;i++){
				if(gameObject == spawnercontroller.ObjInstaciados[i]){
					Destroy(spawnercontroller.ObjInstaciados[i]);
					//print ("bateu");
					//ScoreController.AumentaScore(1);
				}
			}
		}
		if (c.tag == "ScoreBlockUp" && !playercontroller.morri && isBloco) {
			ScoreController.AumentaScore(1);
			isBloco = false;
		}
	}
}
