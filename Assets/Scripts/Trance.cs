using UnityEngine;
using System.Collections;

public class Trance : MonoBehaviour {
	public Camera Camera;
	public Light Light;
	public Vector4 r; // x = A, y = f, z = theta, w = psi
	public Vector4 g;
	public Vector4 b;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Camera.backgroundColor = new Color(s(r), s(g), s(b));
	}
	
	private float s(Vector4 o) {
		return o.x * Mathf.Sin (Time.time * o.y + o.z) + o.w;
	}
}
