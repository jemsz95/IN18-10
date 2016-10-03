using UnityEngine;
using System.Collections;

public class MinionController : MonoBehaviour {
	public Minion character { get; private set; }
	public Transform[] targets;
	public float stoppingDistance;

	private int currentTarget;

	private void Start () {
		character = GetComponent<Minion>();

		currentTarget = 0;
	}



	private void Update () {
		if (currentTarget < targets.Length && targets [currentTarget] != null) {
			Vector3 distance = targets [currentTarget].position - transform.position;

			if (distance.magnitude > stoppingDistance) {
				character.Move (distance.normalized, false, false);
			} else {
				currentTarget++;
			}
		} else {
			character.Move (Vector3.zero, false, false);
		}
	}


	public void SetTargets (Transform[] targets) {
		this.targets = targets;
	}
}
