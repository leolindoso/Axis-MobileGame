using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Transform player;
	public Text Scoretext;
	public static int score = 0;
	private int aux = -1;
	public bool CanEvento = true;

	// Use this for initialization
	void Start () {
		Scoretext = GetComponent<Text> ();
		if(PlayerPrefs.GetInt("AtualScore") > 0){
			score = PlayerPrefs.GetInt("AtualScore");
			PlayerPrefs.SetInt("AtualScore",0);
		}else{
			if(!player.gameObject.GetComponent<PlayerController>().morri){
				score = 0;
			}
			
		}
	}

	// Update is called once per frame
	void Update () {

		Scoretext.text = score.ToString();
		if(score != aux){
			CanEvento = true;
		}
	}
	void FixedUpdate(){
		if(CanEvento){
			if(score == 1){
				Analytics.CustomEvent("CheckaScore", new Dictionary<string,object>{ 
					{"score",score} 
				});
				print("ENVIANDO EVENTO");
				CanEvento = false;
				aux = score;
			}else if(score == 10){
				Analytics.CustomEvent("CheckaScore", new Dictionary<string,object>{ 
					{"score",score} 
				});
				CanEvento = false;
				aux = score;
			}else if(score == 20){
				Analytics.CustomEvent("CheckaScore", new Dictionary<string,object>{ 
					{"score",score} 
				});
				CanEvento = false;
				aux = score;
			}else if(score == 30){
				Analytics.CustomEvent("CheckaScore", new Dictionary<string,object>{ 
					{"score",score} 
				});
				CanEvento = false;
				aux = score;
			}else if(score == 40){
				Analytics.CustomEvent("CheckaScore", new Dictionary<string,object>{ 
					{"score",score} 
				});
				CanEvento = false;
				aux = score;
			}
		}
		
	}
	public static void AumentaScore (int i)
	{
		score = score + i;
	}
	public static void ZerarScore(){
		score = 0;
	}
}
