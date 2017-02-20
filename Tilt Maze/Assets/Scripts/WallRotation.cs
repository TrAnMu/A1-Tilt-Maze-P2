using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRotation : MonoBehaviour {
	private bool turning = false;
	private bool clockwise;
	private float startAngle;
	private float endAngle;

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
				startAngle = transform.localRotation.eulerAngles.y;

				if (Random.Range (0, 2) == 0) {
					clockwise = true;
					endAngle = startAngle + 90.0f;

					if (endAngle >= 360.0) {
						endAngle = 0.0f;
					}
				} else {
					clockwise = false;
					endAngle = startAngle - 90.0f;

					if (endAngle < 0.0) {
						endAngle = 270.0f;	
					}
				}
			}
		} else {
			Turn (clockwise);
		}
	}

	void Turn (bool clockwise) {
		if (clockwise) {
			transform.Rotate (Vector3.up, 90 * Time.deltaTime);

			if (endAngle < startAngle && transform.rotation.eulerAngles.y < startAngle) {
				transform.rotation.eulerAngles.Set (0.0f, 0.0f, 0.0f);
				turning = false;
			} else if (endAngle > startAngle && transform.rotation.eulerAngles.y > endAngle) {
				transform.rotation.eulerAngles.Set (0.0f, endAngle, 0.0f);
				turning = false;
			}
				
		} else {
			transform.Rotate (Vector3.up, -90 * Time.deltaTime);

			if (endAngle > startAngle && transform.rotation.eulerAngles.y > startAngle) {
				transform.rotation.eulerAngles.Set (0.0f, 0.0f, 0.0f);
				turning = false;
			} else if (endAngle < startAngle && transform.rotation.eulerAngles.y < endAngle) {
				transform.rotation.eulerAngles.Set (0.0f, endAngle, 0.0f);
				turning = false;
			}
		}
	}
}
