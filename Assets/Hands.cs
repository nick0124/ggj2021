using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {
	public Transform cam;
	public Transform hands;
	public FixedJoint handsJoint;
	public Transform hitTransform;
	public Rigidbody hitRb;

	public float grabDistance;

	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("grab");
			if(hitRb != null) {
				handsJoint.connectedBody = hitRb;
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			Debug.Log("drop");
			if (handsJoint.connectedBody != null) {
				handsJoint.connectedBody.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Impulse);
			}
			handsJoint.connectedBody = null;
		}
		if (Input.GetMouseButtonUp(1)) {
			Debug.Log("throw");
			if (handsJoint.connectedBody != null) {
				handsJoint.connectedBody.GetComponent<Rigidbody>().AddForce(cam.forward*10, ForceMode.Impulse);
			}
			handsJoint.connectedBody = null;
		}
	}

	void FixedUpdate() {
		hands.transform.localPosition = new Vector3(0, 0, 1);

		Debug.DrawRay(cam.position, cam.forward, Color.green);

		RaycastHit hit;
		Ray ray = new Ray(cam.position, cam.forward);

		if (Physics.Raycast(ray, out hit)) {
			if (hit.distance < grabDistance) {
				hitTransform = hit.transform;
				if (hitTransform.GetComponent<Rigidbody>() == null) {
					hitTransform = null;
					hitRb = null;
				} else {
					if (hitTransform.GetComponent<Rigidbody>().isKinematic) {
						hitTransform = null;
						hitRb = null;
					} else {
						hitRb = hitTransform.GetComponent<Rigidbody>();
					}
				}
			} else {
				hitTransform = null;
				hitRb = null;
			}

			// Do something with the object that was hit by the raycast.
		} else {
			hitTransform = null;
			hitRb = null;
		}
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log(other.transform.name);
	}

	private void OnTriggerExit(Collider other) {
		Debug.Log(other.transform.name);
	}
}
