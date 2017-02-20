using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {
	private bool turning = false;
	private bool clockwise;
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

					clockwise = true;
				} else {
					target = transform.eulerAngles.y - 90.0f;

					if (target < 0.0f) {
						target += 360.0f;
					}

					clockwise = false;
				}
			}
		} else {
			if (Mathf.Abs(transform.eulerAngles.y - target) > 1.0) {
				float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.y, target, 90.0f * Time.deltaTime);
				transform.eulerAngles = new Vector3(0, angle, 0);
			} else {
				transform.eulerAngles = new Vector3 (0, target, 0);
				turning = false;
			}

		}
	}
}
