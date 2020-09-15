using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {


	// Use this for initialization
	public GameObject PontoEsquerdo;
	public GameObject PontoMeio;
	public GameObject PontoDireito;
	public float Frequencia = 0.1f;
	GameObject instance;
	static GameObject x;
	static int i = 0;
	public PlayerController Player;

	public List<GameObject> spawnPoints;
	public List<GameObject> spawnPointsCoin;
	public List<GameObject> spawnObjects;
	public GameObject Coin;
	public GameObject Key;
	public List<GameObject> ObjInstaciados;
	void Start () {
		//SpawnObject ();
		InvokeRepeating ("SpawnObject", 1f, Frequencia);
		InvokeRepeating ("SpawnCoin", 2f, Random.Range(3,6));
	}

	// Update is called once per frame
	void Update () {

		/*if(Input.GetButtonDown("Fire2")){
			foreach(GameObject x in ObjInstaciados){
				if (x != null) {
					i++;
					Destroy (x);
				}
			}
			ScoreController.score += i;
		}
		i = 0;*/
	}

	void SpawnObject(){
		if(Player.getCanStart()){
			int selecObj = Random.Range (0, 2);
			// print("selecObj: " + selecObj);
			int selecPoint = Random.Range (0, spawnPoints.Count);
			if (spawnPoints [selecPoint] == PontoMeio) {
				// print("Escolheu o do meio");
				if (ScoreController.score > 10) {
					
					instance = Instantiate (spawnObjects [1], spawnPoints [selecPoint].transform.position, spawnPoints [selecPoint].transform.rotation);
					ObjInstaciados.Add (instance);
				}else {

					selecObj = Random.Range (0, 2);
					
					selecPoint = Random.Range (0, 1);
					instance = Instantiate (spawnObjects [selecObj], spawnPoints [selecPoint].transform.position, spawnPoints [selecPoint].transform.rotation);
					ObjInstaciados.Add (instance);
				}
			} else {
				// print("Escolheu um dos lados");
				
				if(ScoreController.score > 20){
					// print("SCORE MAIOR QUE 20");
					int rand = Random.Range(0,2);
					if(rand == 1){
						// print(">20");
						instance = Instantiate (spawnObjects [Random.Range(2,4)], spawnPoints [selecPoint].transform.position, spawnPoints [selecPoint].transform.rotation);
						ObjInstaciados.Add (instance);
					}else{
						// print("Ta criando bloco nos lados");
						instance = Instantiate (spawnObjects [selecObj], spawnPoints [selecPoint].transform.position, spawnPoints [selecPoint].transform.rotation);
						ObjInstaciados.Add (instance);
					} 
				}else{
					// print("Ta criando bloco nos lados");
					instance = Instantiate (spawnObjects [selecObj], spawnPoints [selecPoint].transform.position, spawnPoints [selecPoint].transform.rotation);
					ObjInstaciados.Add (instance);
				}
			}
		}
	}
	void SpawnCoin(){
		if(Player.getCanStart()){
			if(Random.Range(0,9) != 4){
				int selecPoint = Random.Range (0, spawnPoints.Count);
				Instantiate(Coin,spawnPointsCoin[selecPoint].transform.position,spawnPointsCoin[selecPoint].transform.rotation);
			}else{
				int selecPoint = Random.Range (0, spawnPoints.Count);
				Instantiate(Key,spawnPointsCoin[selecPoint].transform.position,spawnPointsCoin[selecPoint].transform.rotation);
			}
			
		}
	}

	/*public static void PowerApagarInimigos(){
		if (Input.GetButtonDown ("Fire2")) {
			foreach (GameObject x in ObjInstaciados) {
				if (x != null) {
					i++;
					Destroy (x);
				}
			}
			ScoreController.score += i;
		}
		i = 0;
	}*/
}