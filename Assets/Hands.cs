using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {
	public Transform cam;
	public Transform hands;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	void FixedUpdate() {
		hands.transform.localPosition = new Vector3(0, 0, 1);
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log(other.transform.name);
	}

	private void OnTriggerExit(Collider other) {
		Debug.Log(other.transform.name);
	}
}
