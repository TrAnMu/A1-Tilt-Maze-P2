using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {

	public Vector3 currentRot;
	public GameObject rotWaller;
	private GameObject walls;
	public GameObject pickUp;
	private GameObject pickUps;
	private int numPickUps = 6;

	// Use this for initialization
	void Start () {
		wallsUp ();
		spawnPickUps ();
	}
	
	// Update is called once per frame
	void Update () {
		currentRot = GetComponent<Transform> ().eulerAngles;

		if ((Input.GetAxis ("Horizontal") > 0.2) && (currentRot.z >= 349 || currentRot.z <= 11)) {
			transform.Rotate (0, 0, -1);
		}

		if ((Input.GetAxis ("Horizontal") < -0.2) && (currentRot.z <= 10 || currentRot.z >= 348)) {
			transform.Rotate (0, 0, 1);
		}  

		if ((Input.GetAxis ("Vertical") > 0.2) && (currentRot.x <= 10 || currentRot.x >= 348)) {
			transform.Rotate ( 1, 0, 0);
		}

		if ((Input.GetAxis ("Vertical") < -0.2) && (currentRot.x >= 349 || currentRot.x <= 11)) {
			transform.Rotate (-1, 0, 0); 
		}
	}

	private void wallsUp() {
		walls = new GameObject ("Barriers");

		for (int i = 1; i < 10; i++) {
			for (int j = 1; j < 10; j++) {
				if ((i + j) % 2 == 0 && !(i == 5 && j == 5)) {
					GameObject wall = (GameObject)Instantiate (rotWaller);
					wall.transform.position = new Vector3 ((i-5.0f), 0.5f, (j-5.0f));
					wall.transform.SetParent (walls.transform);
				}
			}
		}

		walls.transform.SetParent (this.transform);
	}

	private void spawnPickUps() {
		pickUps = new GameObject ("PickUps");
		ArrayList seen = new ArrayList ();
		int ctr = 0;
		Vector3 coords;


		while (ctr < numPickUps) {
			coords = new Vector3 (Random.Range (-5, 5) + 0.5f, 0.5f, Random.Range (-5, 5) + 0.5f);

			if (!seen.Contains(coords) && !(coords.x == 4.5f && coords.z == 4.5f)) {
				GameObject spawn = (GameObject)Instantiate (pickUp);
				spawn.transform.position = coords;
				spawn.transform.SetParent (pickUps.transform);
				seen.Add (coords);
				ctr++;
			}
		}

		pickUps.transform.SetParent (this.transform);
	}
}
