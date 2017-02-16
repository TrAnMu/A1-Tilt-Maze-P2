using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {

	public Vector3 currentRot;
	public GameObject wall;

	// Use this for initialization
	void Start () {
		// GameObject wall = (GameObject)Instantiate (Resources.Load ("Prefabs/RotWaller"));
		wall.transform.position = new Vector3 (0.3f, 5.5f, 0f);
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
}
