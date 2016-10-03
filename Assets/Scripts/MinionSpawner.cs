using UnityEngine;
using System.Collections;

public class MinionSpawner : MonoBehaviour {

	public GameObject MinionPrefab;
	public int Count;
	public float Timer;
	public Transform[] AIWaypoints;
	public Transform MinionParent;

	private int i;
	private float nextTime;
	private bool spawning = false;

	public void Run () {
		spawning = true;
		i = 0;
		nextTime = Time.time;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (spawning) {
			if (i < Count * GameManager.instance.Level) {
				if(Time.time > nextTime) {
					GameObject minion = GameObject.Instantiate (MinionPrefab);

					minion.transform.SetParent (MinionParent);
					minion.transform.position = transform.position;

					minion.GetComponent<MinionController> ().targets = AIWaypoints;

					if (i % Mathf.RoundToInt(20 / GameManager.instance.Level) == 0) {
						minion.gameObject.GetComponent<Killable> ().Health += (3 * GameManager.instance.Level);
						minion.gameObject.GetComponent<Minion> ().m_MoveSpeedMultiplier = 0.4f;
						minion.transform.localScale *= 2;
					}

					nextTime += Timer;
					i++;
				}
			} else {
				spawning = false;

				GameManager.instance.NextLevel ();
				Run ();
			}
		}
	}
}
