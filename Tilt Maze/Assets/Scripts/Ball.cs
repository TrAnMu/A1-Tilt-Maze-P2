using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Rigidbody rb;
	public float thrust;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.isKinematic == true) {
			transform.Translate (Vector3.up * Time.deltaTime * 8.0f, Space.World);
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}

		if (Input.GetButtonDown ("Jump")) {
			rb.AddForce (new Vector3 (0, thrust, 0));
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Goal") {
			rb.isKinematic = true;
		}
	}
}
