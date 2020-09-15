using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CorController : MonoBehaviour {
	Color cor;
	float R,G,B;
	public GameObject CheckCircle;
	public GameObject CheckOcto;
	public GameObject CheckHexa;
	public GameObject CheckCross;
	public GameObject CheckHeart;
	public GameObject CheckStar4;
	public GameObject CheckStar5;
	public GameObject CheckStar6;
	public GameObject CheckTrefoil;
	public GameObject CheckQuaterfoil;

	public SpawnerController spawncontroller;
	public PlayerController playercontroller;

	public Animator ImageAnim;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Menu(){
		StartCoroutine(LoadMenuCor());
		GameObject SpawnControllerObject = GameObject.FindGameObjectWithTag ("Spawnercontroller");
		spawncontroller = SpawnControllerObject.GetComponent<SpawnerController> ();
		GameObject PlayerControllerObject = GameObject.FindGameObjectWithTag ("Player");
		playercontroller = PlayerControllerObject.GetComponent<PlayerController> ();
	}

	public void voltaMenu(){
		StartCoroutine(LoadMenu());
	}
	public void voltaMenu2(){
		playercontroller.Restart();
		
	}

	public void mudaCircle(){
		
		PlayerPrefs.SetString ("Player Shape", "circle");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(true);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}

	public void mudaOcto(){

		PlayerPrefs.SetString ("Player Shape", "octo");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (true);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}

	public void mudaHexa(){
		
		PlayerPrefs.SetString ("Player Shape", "hexa");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (true);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}
	public void mudaStar6(){
		
		PlayerPrefs.SetString ("Player Shape", "star6");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (true);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}
	public void mudaStar5(){
		
		PlayerPrefs.SetString ("Player Shape", "star5");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (true);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}
	public void mudaStar4(){
		
		PlayerPrefs.SetString ("Player Shape", "star4");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (true);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}
	public void mudaQuaterfoil(){
		
		PlayerPrefs.SetString ("Player Shape", "quatrefoil");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (true);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}
	public void mudaTrefoil(){
		
		PlayerPrefs.SetString ("Player Shape", "trefoil");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (true);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (false);
	}
	public void mudaHeart(){
		
		PlayerPrefs.SetString ("Player Shape", "heart");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (true);
		CheckCross.SetActive (false);
	}
	public void mudaCross(){
		
		PlayerPrefs.SetString ("Player Shape", "cross");
		// print (playercontroller.getCor());
		CheckCircle.SetActive(false);
		CheckOcto.SetActive (false);
		CheckHexa.SetActive (false);
		CheckTrefoil.SetActive (false);
		CheckStar6.SetActive (false);
		CheckStar5.SetActive (false);
		CheckStar4.SetActive (false);
		CheckQuaterfoil.SetActive (false);
		CheckHeart.SetActive (false);
		CheckCross.SetActive (true);
	}


	public void mudaDireção(){
		//print ("mudou");
		playercontroller.mudaDirecao ();
	}
	IEnumerator LoadMenu(){
		if(ImageAnim != null){
			ImageAnim.SetTrigger("End");
		}
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene ("Menu");

	}
	IEnumerator LoadMenuCor(){
		if(ImageAnim != null){
			ImageAnim.SetTrigger("End");
		}
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene ("MenuCor");

	}

}
