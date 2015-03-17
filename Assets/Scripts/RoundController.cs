using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundController : MonoBehaviour {
	public int ActiveLasers;
	public float RoundWarmupTime;
	public float SloMoTimeScale;
	public float EjectionSpeed;
    public Text Display;
	public Killable Player;
	public MoveOnAxis LaserPrefab;
	public GameObject LaserContainer;
	public TargetController TargetContainer;
	public Target EscapeObject;
	public GameObject DismantleObject;

	private float _t;
	private MoveOnAxis _currentLaser;
	private bool _roundsComplete;

	// Use this for initialization
	void Start () {
		TargetContainer.OnAllTargetsHit += CompleteLevel;
		EscapeObject.OnTargetHit += Victory;

		StartCoroutine("ManageRounds");
	}
	
	// Update is called once per frame
	void Update () {
		if(_t < RoundWarmupTime) {
			Display.text = string.Format("{0:F2}", RoundWarmupTime - _t + 1f).ToString();
			_t += Time.deltaTime;
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, 1f, 0.125f);

			if(_currentLaser != null) 
				_currentLaser.transform.LookAt(Player.transform);
		} else {
			Display.text = "GO!!!";
			Time.timeScale = Mathf.SmoothStep(Time.timeScale, SloMoTimeScale, 0.125f);
		}

		Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}

	IEnumerator ManageRounds() {
		while(true) {
			_currentLaser = (MoveOnAxis) Instantiate(LaserPrefab, RandomPointOnSurface(), Quaternion.identity);
			_currentLaser.transform.parent = LaserContainer.transform;
			++ActiveLasers;
			_t = 0f;
			yield return new WaitForSeconds(RoundWarmupTime);
			_currentLaser.enabled = true;
			yield return new WaitForSeconds(_currentLaser.Duration);
		}
	}

	Vector3 RandomPointOnSurface() {
		return Random.onUnitSphere * this.collider.bounds.size.x + this.collider.bounds.center;
	}

	void CompleteLevel() {
		StopCoroutine("ManageRounds");
		LaserContainer.SetActive(false);
		DismantleObject.SetActive(true);
		StartCoroutine(DestroyChamber());
		StartCoroutine(CreateEscape());
	}

	IEnumerator DestroyChamber() {
		while(true) {
			foreach(Transform child in transform) {
				child.position += child.position.normalized * Time.deltaTime * EjectionSpeed;
			}
			foreach(Transform child in TargetContainer.transform) {
				child.position += child.position.normalized * Time.deltaTime * EjectionSpeed;
			}
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator CreateEscape() {
		yield return new WaitForSeconds(1f);
		EscapeObject.gameObject.SetActive(true);
	}

	void Victory(Collider other) {
		Application.LoadLevel("Win");
		_roundsComplete = true;
	}
}
