using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {

	public GameObject spherePrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject sphere = Instantiate (spherePrefab) as GameObject;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 worldDir = ray.direction;
			sphere.GetComponent<SphereController> ().Shoot (worldDir.normalized * 2000);
		}
	}
}
