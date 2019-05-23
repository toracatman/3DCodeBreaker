using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	GameObject director;

	public void Shoot(Vector3 dir) {
		GetComponent<Rigidbody> ().AddForce (dir);
		director = GameObject.Find ("GameDirector");
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "1"
			|| other.gameObject.tag == "2"
			|| other.gameObject.tag == "3"
			|| other.gameObject.tag == "4"
			|| other.gameObject.tag == "5"
			|| other.gameObject.tag == "6"
			|| other.gameObject.tag == "7"
			|| other.gameObject.tag == "8"
			|| other.gameObject.tag == "9"
			|| other.gameObject.tag == "0") {
			if(other.gameObject.tag == "1") director.GetComponent<GameDirector> ().NumberInput (1);
			if(other.gameObject.tag == "2") director.GetComponent<GameDirector> ().NumberInput (2);
			if(other.gameObject.tag == "3") director.GetComponent<GameDirector> ().NumberInput (3);
			if(other.gameObject.tag == "4") director.GetComponent<GameDirector> ().NumberInput (4);
			if(other.gameObject.tag == "5") director.GetComponent<GameDirector> ().NumberInput (5);
			if(other.gameObject.tag == "6") director.GetComponent<GameDirector> ().NumberInput (6);
			if(other.gameObject.tag == "7") director.GetComponent<GameDirector> ().NumberInput (7);
			if(other.gameObject.tag == "8") director.GetComponent<GameDirector> ().NumberInput (8);
			if(other.gameObject.tag == "9") director.GetComponent<GameDirector> ().NumberInput (9);
			if(other.gameObject.tag == "0") director.GetComponent<GameDirector> ().NumberInput (0);
			GetComponent<ParticleSystem> ().Play ();
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
