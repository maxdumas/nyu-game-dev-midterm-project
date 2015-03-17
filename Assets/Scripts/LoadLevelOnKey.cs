using UnityEngine;
using System.Collections;

public class LoadLevelOnKey : MonoBehaviour {
	public string LevelName;
	public KeyCode Key;
	
	public GameObject EffectsObject;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (Key)) {
			LoadLevel();
		}
	}
	
	public void ClickLoadLevel() {
		StartCoroutine(Intro ());
	}
	
	IEnumerator Intro() {
		EffectsObject.SetActive(true);
		yield return new WaitForSeconds(7.5f);
		LoadLevel();
	}
	
	public void LoadLevel() {
		Application.LoadLevel(LevelName);
	}
}
