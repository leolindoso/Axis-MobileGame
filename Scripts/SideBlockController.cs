using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideBlockController : MonoBehaviour {

	public PlayerController player;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter2D(Collider2D c){
		// print (c.gameObject.tag);
		if(c.gameObject.tag == "Player"){
			// print ("morri");
			Vector2 velocity = player.getRB().velocity;
			player.speedX = 0;
			player.morri = true;
			player.Die ();
			//highscore.UpdateHighScore ();
			//Invoke ("Restart", 0.8f);
		}
	}
	void Restart() {
		ScoreController.ZerarScore ();
		SceneManager.LoadScene ("Menu");

		player.morri = false;

	}
}
