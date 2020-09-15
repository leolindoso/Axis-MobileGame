using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	CircleCollider2D cc;

	public HighScoreController highscore;
	SpriteRenderer sr;
	Rigidbody2D rb;
	public float speedX = 0;
	public float speedY = 1;
	public GameObject UIGameOver;
	public bool morri, inicio = false;
	bool test = false;
	bool transparente;
	public string forma = "blue";
	public int poder;
	public Sprite Circle;
	public Sprite Octo;
	public Sprite Hexa;
	public Sprite Trefoil;
	public Sprite Quatrefoil;
	public Sprite Cross;
	public Sprite Star6;
	public Sprite Star5;
	public Sprite Star4;
	public Sprite Heart;
	int R = 40;
	int G = 171;
	int B = 227;
	Color c;
	private AudioSource audioSource;
	public AudioClip deathSound;
	public bool CanStart = false;
	public GameObject particulaMorte;
	public ParticleSystem particula;
	public int Coins;
	public int Keys;
	public AudioSource CameraSound;
	// Use this for initialization
	void Start ()
	{
		speedY = 0;
		if (PlayerPrefs.GetString ("Player Shape").Equals ("")) {
			PlayerPrefs.SetString ("Player Shape", "circle");
		}
		forma = PlayerPrefs.GetString ("Player Shape");

		poder = PlayerPrefs.GetInt ("Player Power");
		// print ("Poder: " + poder);
		// inicio = true;
		StartGame.PowerCooldown = 7;
		test = false;
		morri = false;
		rb = GetComponent<Rigidbody2D>();
		cc = GetComponent<CircleCollider2D> ();
		sr = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();

		animarInicio ();
		cc.isTrigger = false;
		transparente = false;

		if (forma == "circle") {
			if (transparente == false) {
				sr.sprite = Circle;
				particula.textureSheetAnimation.SetSprite(0,Circle);
				sr.color = (c = new Color (0.15f,0.6f,1f));
				//sr.color = Color.blue;
			}
		} else if (forma == "octo") {
			if (transparente == false) {
				sr.sprite = Octo;
				particula.textureSheetAnimation.SetSprite(0,Octo);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "hexa") {
			if (transparente == false) {
				sr.sprite = Hexa;
				particula.textureSheetAnimation.SetSprite(0,Hexa);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "star6") {
			if (transparente == false) {
				sr.sprite = Star6;
				particula.textureSheetAnimation.SetSprite(0,Star6);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "star5") {
			if (transparente == false) {
				sr.sprite = Star5;
				particula.textureSheetAnimation.SetSprite(0,Star5);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "star4") {
			if (transparente == false) {
				sr.sprite = Star4;
				particula.textureSheetAnimation.SetSprite(0,Star4);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "cross") {
			if (transparente == false) {
				sr.sprite = Cross;
				particula.textureSheetAnimation.SetSprite(0,Cross);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "heart") {
			if (transparente == false) {
				sr.sprite = Heart;
				particula.textureSheetAnimation.SetSprite(0,Heart);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "trefoil") {
			if (transparente == false) {
				sr.sprite = Trefoil;
				particula.textureSheetAnimation.SetSprite(0,Trefoil);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		} else if (forma == "quatrefoil") {
			if (transparente == false) {
				sr.sprite = Quatrefoil;
				particula.textureSheetAnimation.SetSprite(0,Quatrefoil);
				sr.color = (c = new Color (0.15f,0.6f,1f));
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!inicio) {

			if (Input.GetButtonDown ("Fire1") && !morri) {
				speedX = -speedX;
				CameraSound.Play();
				CameraSound.pitch += 0.002f;
			}
		}

	}
	public void FixedUpdate(){
		if(getCanStart()){
			if (inicio) {
				
				speedX = 0;
				
			}
			Vector2 velocity1 = rb.velocity;
			velocity1.y = speedY;
			rb.velocity = velocity1;
			if (speedY > 0f) {
				speedY = speedY - (0.1f);
			} else if (speedY < 0) {
				speedY = 0; 
			} else {
				inicio = false;
				if (test == false){
					speedX = 1.5f;
					test = true;
				}

			}




			if (speedX > -2.0f && speedX < 0) {
				speedX = speedX - (0.0002f);
			} else if (speedX < 2.0f && speedX > 0) {
				speedX = speedX + (0.0002f);
			}
			//print (speedX);
			if (!inicio) {
				
				// print(PlayerPrefs.GetInt("Player Coins"));

				Vector2 velocity = rb.velocity;
				velocity.x = speedX;
				//if (Input.GetButtonDown ("Fire1") & !morri) {
				//	speedX = -speedX;
				//gameObject.SendMessage ("AumentaScore", 1);
				//}
				rb.velocity = velocity;
			}
		}
		
	}

	// public void mudaTransparenciaTrue(){
	// 	if (cor == "blue") {
	// 		transparente = true;
	// 		sr.color = (c = new Color(0,0,1,0.5f));
	// 	}
	// 	if (cor == "green") {
	// 		transparente = true;
	// 		sr.color = (c = new Color(0,1,0,0.5f));
	// 	}
	// 	if (cor == "yellow") {
	// 		transparente = true;
	// 		sr.color = (c = new Color(1,0.92f,0.016f,0.5f));
	// 	}
	// 	if (cor == "orange") {
	// 		transparente = true;
	// 		sr.color = (c = new Color(0.9f, 0.4f, 0.2f,0.5f));
	// 	}
	// 	if (cor == "red") {
	// 		transparente = true;
	// 		sr.color = (c = new Color(1f, 0.3f, 0.3f,0.5f));
	// 	}
	// 	if (cor == "purple") {
	// 		transparente = true;
	// 		sr.color = (c = new Color(0.8f, 0.4f, 0.9f,0.5f));
	// 	}
	// }

	// public void mudaTransparenciaFalse(){
	// 	transparente = false;
	// 	if (cor == "blue") {
	// 		sr.color = (c = new Color(0,0,1,1f));
	// 	}
	// 	if (cor == "green") {
	// 		sr.color = (c = new Color(0,1,0,1f));
	// 	}
	// 	if (cor == "yellow") {
	// 		sr.color = (c = new Color(1,0.92f,0.016f,1f));
	// 	}
	// 	if (cor == "orange") {
	// 		sr.color = (c = new Color(0.9f, 0.4f, 0.2f,1f));
	// 	}
	// 	if (cor == "red") {
	// 		sr.color = (c = new Color(1f, 0.3f, 0.3f,1f));
	// 	}
	// 	if (cor == "purple") {
	// 		sr.color = (c = new Color(0.8f, 0.4f, 0.9f,1f));
	// 	}
	// }


	public void mudaColisaoPraTrue(){
		cc.isTrigger = true;
	}
	public void mudaColisaoPraFalse(){
		cc.isTrigger = false;
	}

	// public string getCor(){
	// 	return cor;
	// }
	public int getPoder(){
		return PlayerPrefs.GetInt("Player Power");
	}
	// public void mudaCor(string c){
	// 	cor = c;
	// }
	public void mudaPoder(int i){
		poder = i;
	}
	public SpriteRenderer getSr(){
		return sr;
	}

	public void Die(){
		
		if(!morri){
			UIGameOver.SetActive (true);
			audioSource.PlayOneShot(deathSound);
		}
	}

	public void SaveCoinsAndKeys(){
		PlayerPrefs.SetInt ("Player Coins", PlayerPrefs.GetInt("Player Coins") + Coins);
		PlayerPrefs.SetInt ("Player Keys", PlayerPrefs.GetInt("Player Keys") + Keys);
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Bloco") {
			if (transparente) {
				Physics2D.IgnoreCollision (c.collider, GetComponent<Collider2D> ());
			
			} else {
				// print ("morri");
				Vector2 velocity = rb.velocity;
				speedX = 0;
				Die ();
				if(!morri){
					Instantiate(particulaMorte,transform.position,Quaternion.identity);
				}
				morri = true;
				GetComponent<SpriteRenderer>().enabled = false;
				particula.gameObject.SetActive(false);
				//highscore.UpdateHighScore ();
				// Invoke ("Restart", 0.8f);
			}

		}
		if (c.gameObject.tag == "SideBlock") {
			// print ("morri");
			Vector2 velocity = rb.velocity;
			speedX = 0;
			Die ();
			morri = true;
			//highscore.UpdateHighScore ();
			// Invoke ("Restart", 0.8f);
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		// print (c.gameObject.tag);
		if(c.tag == "Coin" && !morri){
			// print("COIN");
			audioSource.Play();
			Coins ++;
			Destroy(c.gameObject);
		}
		if(c.tag == "Key" && !morri){
			// print("COIN");
			audioSource.Play();
			Keys ++;
			Destroy(c.gameObject);
		}
		if(c.tag == "SideBlock"){
			// print ("morri");
			Vector2 velocity = rb.velocity;
			speedX = 0;
			Die ();
			morri = true;
			//highscore.UpdateHighScore ();
			// Invoke ("Restart", 0.8f);
		}
	}

	void animarInicio(){
		Vector2 velocity = rb.velocity;
		velocity.y = speedY;
		rb.velocity = velocity;
		if (speedY >= 0f) {
			speedY = speedY - (0.05f);
		} else {
			inicio = false;
		}

	}

	public void Restart() {
		ScoreController.ZerarScore ();
		SceneManager.LoadScene ("Menu");

		morri = false;

	}
	bool taVivo(){
		return morri;
	}
	public bool getCanStart(){
		return CanStart;
	}

	public void mudaDirecao(){
		if (!morri) {
			speedX = -speedX;
			//gameObject.SendMessage ("AumentaScore", 1);
		}
	}

	public Rigidbody2D getRB(){
		return this.rb;
	}

	public void setCanStart(){
		// print("CHAMOU SETCANSTART1: " + CanStart);
		CanStart = true;
		// print("CHAMOU SETCANSTART2: " + CanStart);
		inicio = true;
		// speedY = 1;
		speedX = 1;
	}
}
