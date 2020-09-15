using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;

public class StartGame : MonoBehaviour {

	static GameObject x;
	Image img;
	Button button;
	int i = 0;
	Color cor;
	float R,G,B;
	public static float PowerCooldown = 10f;
	public static float IntangTime = 5f;
	bool usouPower;
	public Image LoadingBar;

	public SpawnerController spawncontroller;
	public GameObject player;
	public PlayerController playercontroller;
	private AudioSource audioSource;
	public Animator ImageAnim;

	public void Awake(){
		Application.targetFrameRate = 60;
	}
	public void Start(){
		print("start");
		img = GetComponent<Image> ();
		button = GetComponent<Button> ();
		audioSource = GetComponent<AudioSource>();
		//IntangTime = 10;
	}

	public void Update(){
		//print ("PowerCoolDown: " + PowerCooldown);
		//PowerCooldown -= 0.01f;
		// LoadingBar.fillAmount = PowerCooldown / 10;
		// LoadingBar.color = Color.grey;

		//print ("IntangTime: " + IntangTime);
		// if (PowerCooldown <= 0) {
		// 	R = 255f;
		// 	G = 255f;
		// 	B = 255f;
		// 	PowerCooldown = 0;
		// 	// button.enabled = true;
		// 	//img.color = (cor = new Color (R, G, B));
		// } else {
		// 	R = 0f;
		// 	G = 0f;
		// 	B = 0f;
		// 	// button.enabled = false;
		// 	//img.color = (cor = new Color (0, 0, 0));
		// }
		// if (IntangTime < 5 && playercontroller.getPoder() == 2) {
		// 	IntangTime += 0.01f;
		// 	playercontroller.mudaTransparenciaTrue ();
		// } else if(IntangTime >= 5 || playercontroller.getPoder() != 2){
		// 	playercontroller.mudaColisaoPraFalse();
		// 	playercontroller.mudaTransparenciaFalse ();
		// }

	}

	public void Play() {
		audioSource.Play();
		StartCoroutine(LoadGame());
		
		
	}

	public void Menu(){
		StartCoroutine(LoadMenuCor());
	}
	public void PrivacyPolicy(){
		Application.OpenURL("https://axis.flycricket.io/privacy.html");
	}

	public void voltaMenu(){
		StartCoroutine(LoadMenu());
	}

	// public void mudaVerde(){
	// 	playercontroller.mudaCor ("green");
	// }

	// public void mudaAzul(){
	// 	playercontroller.mudaCor ("blue");
	// }

	// public void mudaLaranja(){
	// 	playercontroller.mudaCor ("orange");
	// }

	public void ApagarInimigos(){
		if (playercontroller.getPoder() == 1) {
			if (PowerCooldown == 0) {
				if (playercontroller.morri == false) {
					foreach (GameObject x in spawncontroller.ObjInstaciados) {
						if (x != null) {
							i++;					
							Destroy (x);
							PowerCooldown = 10;
						}
					}
					ScoreController.score += i;
					i = 0;
				}
			}
		}
		if (playercontroller.getPoder() == 2) {
			if (PowerCooldown == 0) {
				if (playercontroller.morri == false) {
					// print ("Ta Intangivel");
					usouPower = true;
					//playercontroller.mudaColisaoPraTrue ();
					IntangTime = 0;
					PowerCooldown = 10;
				}
			}
		}
	}

	public void mudaDireção(){
		//print ("mudou");
		playercontroller.mudaDirecao ();
	}

	IEnumerator LoadGame(){
		ImageAnim.SetTrigger("End");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene ("cena");

	}
	IEnumerator LoadMenuCor(){
		ImageAnim.SetTrigger("End");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene ("MenuCor2");

	}
	IEnumerator LoadMenu(){
		ImageAnim.SetTrigger("End");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene ("Menu");

	}

	void OnApplicationPause(bool isPaused){

		#if UNITY_ANDROID

		NotificationManager.CancelAll();
		if(isPaused){
			//DateTime timeToNotify = DateTime.Now.AddMinutes(1);
			DateTime timeToNotify2 = DateTime.Now.AddHours(3);
			//TimeSpan time = timeToNotify - DateTime.Now;
			TimeSpan time2 = timeToNotify2 - DateTime.Now;
			//NotificationManager.SendWithAppIcon(time,"Come break your record!","Let's go! How far can you go this time?", Color.cyan, NotificationIcon.Bell);
			NotificationManager.SendWithAppIcon(time2,"Enjoying the break?","Show your skills! How far can you go this time?", Color.cyan, NotificationIcon.Bell);
		}

		#endif
	}


}
