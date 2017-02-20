using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {
	private bool turning = false;
	private bool clockwise;
	private float speed = 90.0f;
	private float target;

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
		if (!turning) {
			if (Random.Range (0.0f, 1.0f) < Time.deltaTime / 10.0f) {
				turning = true;

				if (Random.Range (0, 2) == 0) {
					target = (transform.eulerAngles.y + 90.0f) % 360.0f;
					print (transform.eulerAngles.y.ToString() + " to " + target.ToString ());

					clockwise = true;
				} else {
					target = transform.eulerAngles.y - 90.0f;

					clockwise = false;
				}
			}
		} else {
			// TODO move toward the target angle.

//			StartCoroutine(Turn (clockwise));
		}
	}

//	private IEnumerator Turn (bool clockwise) {
//		float newAngle = currEuler.y + 90.0f;
//
//		print (currEuler.y.ToString() + " to " + newAngle.ToString());
//
//		while (currEuler.y != newAngle) {
//			currEuler.y = Mathf.MoveTowardsAngle (currEuler.y, newAngle, speed * Time.deltaTime);
//			transform.eulerAngles = currEuler;
//			yield return null;
//		}
//
//		turning = false;
//	}
}
