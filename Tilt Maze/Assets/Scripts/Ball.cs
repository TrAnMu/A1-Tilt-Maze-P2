using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	private Rigidbody rb;
	public float thrust;
	public Text countText;
	public Text winText;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 2;
		SetCountText ();
		winText.text = "";
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

		if (transform.position.y < -10.0f) {
			winText.text = "Sorry. You lose!";
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Goal") && count == 0) {
			rb.isKinematic = true;
			winText.text = "Congratulations. You Win!";
		}

		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			if (count > 0) {
				count--;
				SetCountText ();
			}
		}
	}

	void SetCountText() {
		if (count > 0) {
			countText.text = "Pick-ups remaining: " + count.ToString ();
		} else {
			countText.text = "Done! Go to the goal!";
		}
	}
}
