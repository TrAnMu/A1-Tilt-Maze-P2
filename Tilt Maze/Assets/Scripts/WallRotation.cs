using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int rando = Random.Range (0, 4);

		if (rando == 1) {
			transform.Rotate (0.0f, 90.0f, 0.0f);
		} else if (rando == 2) {
			transform.Rotate (0.0f, 180.0f, 0.0f);
		} else if (rando == 3) {
			transform.Rotate (0.0f, 270.0f, 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
