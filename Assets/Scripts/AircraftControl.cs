using UnityEngine;
using System.Collections;

public class AircraftControl : MonoBehaviour {
	public float YawSpeed;
	public float PitchSpeed;
//	public float RollTorque;
	public float AscensionForce;
	public float StrafeForce;
	public float LinearForce;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if(Input.GetKey (KeyCode.Q)) {
//			rigidbody.AddTorque(transform.forward * RollTorque);
			rigidbody.AddForce (-transform.up * AscensionForce);
		} else if(Input.GetKey (KeyCode.E)) {
//			rigidbody.AddTorque(-transform.forward * RollTorque);
			rigidbody.AddForce(transform.up * AscensionForce);
		}

//		rigidbody.AddTorque(transform.right * PitchTorque * Input.GetAxis("Mouse Y"));
		transform.Rotate(Vector3.right, -Input.GetAxis ("Mouse Y") * PitchSpeed, Space.Self);

//		rigidbody.AddTorque(-transform.up * YawTorque * Input.GetAxis("Mouse X"));
		transform.Rotate(Vector3.up, Input.GetAxis ("Mouse X") * YawSpeed, Space.Self);

		if(Input.GetKey (KeyCode.W)) {
			rigidbody.AddForce(transform.forward * StrafeForce);
		} else if(Input.GetKey (KeyCode.S)) {
			rigidbody.AddForce(-transform.forward * StrafeForce);
		}

		if(Input.GetKey (KeyCode.D)) {
			rigidbody.AddForce(transform.right * LinearForce);
		} else if(Input.GetKey (KeyCode.A)) {
			rigidbody.AddForce(-transform.right * LinearForce);
		}
	}
}
