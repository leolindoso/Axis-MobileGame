using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {


	public Transform camera;
	public float MaxDiff;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		float diferenca = transform.position.x - camera.position.x;
		if(diferenca <= -MaxDiff) {
			Vector3 position = transform.position;
			position.x = camera.position.x + MaxDiff;
			transform.position = position;
		
		}
	}
}
