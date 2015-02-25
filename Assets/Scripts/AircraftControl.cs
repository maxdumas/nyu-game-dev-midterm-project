using UnityEngine;
using System.Collections;

public class AircraftControl : MonoBehaviour {
	public float YawTorque;
	public float RollTorque;
	public float PitchTorque;
	public float StrafeForce;
	public float LinearForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if(Input.GetKey (KeyCode.D)) {
			rigidbody.AddTorque(transform.up * YawTorque);
		} else if(Input.GetKey (KeyCode.A)) {
			rigidbody.AddTorque(-transform.up * YawTorque);
		}

		if(Input.GetKey (KeyCode.Q)) {
			rigidbody.AddTorque(transform.forward * RollTorque);
		} else if(Input.GetKey (KeyCode.E)) {
			rigidbody.AddTorque(-transform.forward * RollTorque);
		}

		if(Input.GetKey (KeyCode.W)) {
			rigidbody.AddTorque(transform.right * PitchTorque);
		} else if(Input.GetKey (KeyCode.S)) {
			rigidbody.AddTorque(-transform.right * PitchTorque);
		}

		if(Input.GetKey (KeyCode.UpArrow)) {
			rigidbody.AddForce(transform.forward * StrafeForce);
		} else if(Input.GetKey (KeyCode.DownArrow)) {
			rigidbody.AddForce(-transform.forward * StrafeForce);
		}

		if(Input.GetKey (KeyCode.RightArrow)) {
			rigidbody.AddForce(transform.right * LinearForce);
		} else if(Input.GetKey (KeyCode.LeftArrow)) {
			rigidbody.AddForce(-transform.right * LinearForce);
		}
	}
}
