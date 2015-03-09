using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundController : MonoBehaviour {
	public int ActiveLasers;
	public float RoundWarmupTime;
	public Text display;
	public float SloMoTimeScale;
	public Killable Player;
	public MoveOnAxis LaserPrefab;

	private float _t;
	private MoveOnAxis _currentLaser;
	private bool _roundsComplete;

	// Use this for initialization
	void Start () {
		StartCoroutine(ManageRounds());
	}
	
	// Update is called once per frame
	void Update () {
		if(!Player.Alive) {
			display.text = "YOU ARE DEAD.\n[SPACE] TO RESTART.";
			StopCoroutine("ManageRounds");
			if(Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel(0);
			}
		} else if(_roundsComplete) {
			display.text = "YOU HAVE DEFEATED THE CAPTOR.\n[SPACE] TO RESTART.";
			if(Input.GetKeyDown(KeyCode.Space)) {
				Application.LoadLevel(0);
			}
		} else if(_t < RoundWarmupTime) {
			display.text = string.Format("{0:F2}", RoundWarmupTime - _t + 1f).ToString();
			_t += Time.deltaTime;
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, 1f, 0.125f);

			if(_currentLaser != null) 
				_currentLaser.transform.LookAt(Player.transform);
		} else {
			display.text = "GO!!!";
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, SloMoTimeScale, 0.125f);
		}

		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	IEnumerator ManageRounds() {
		while(true) {
			_currentLaser = (MoveOnAxis) Instantiate(LaserPrefab, RandomPointOnSurface(), Quaternion.identity);
			++ActiveLasers;
			_t = 0f;
			yield return new WaitForSeconds(RoundWarmupTime);
			_currentLaser.enabled = true;
			yield return new WaitForSeconds(_currentLaser.Duration);
		}
		_roundsComplete = true;
	}

	Vector3 RandomPointOnSurface() {
		return Random.onUnitSphere * this.collider.bounds.size.x + this.collider.bounds.center;
	}
}
