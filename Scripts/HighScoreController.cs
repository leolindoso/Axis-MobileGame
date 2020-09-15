using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {


	public Transform player;
	Text HighScoreText;
	public int HighScore;
	// Use this for initialization
	void Start () {
		HighScore = PlayerPrefs.GetInt ("Player HighScore");
		GameObject ScoreControllerObject = GameObject.FindWithTag ("Scorecontroller");
		HighScoreText = GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {

		if (ScoreController.score > this.HighScore) {
			HighScore = ScoreController.score;
			PlayerPrefs.SetInt ("Player HighScore", ScoreController.score);
			HighScoreText.text = PlayerPrefs.GetInt ("Player HighScore").ToString ();
		}
		//print ("HighScore: " + PlayerPrefs.GetInt ("Player HighScore"));
		HighScoreText.text = HighScore.ToString ();
	} 

	public void UpdateHighScore(){
		if (ScoreController.score > this.HighScore) {
			HighScore = ScoreController.score;
			PlayerPrefs.SetInt ("Player HighScore", ScoreController.score);
			HighScoreText.text = PlayerPrefs.GetInt("Player HighScore").ToString ();
		} else {
			//HighScore = HighScore;
		}
	}
}
