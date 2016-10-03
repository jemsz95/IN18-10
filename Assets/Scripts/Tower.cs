using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public float Range;
	public float AttackSpeed;
	public GameObject ShotPrefab;
	public float TurnSpeed;
	public int Price;

	private Transform target;
	private float distance;
	private float nextShotTime;

	private void findTarget() {
		int enemies = LayerMask.GetMask ("Enemies");
		Collider[] nearbyTargets = Physics.OverlapSphere (transform.position, Range, enemies);

		if (nearbyTargets.Length == 0) {
			target = null;
		} else {
			float nearbyTargetDistance = 0;

			foreach (Collider nearby in nearbyTargets) {
				nearbyTargetDistance = Vector3.Distance (transform.position, nearby.transform.position);

				if (nearbyTargetDistance < distance) {
					target = nearby.transform;
					distance = nearbyTargetDistance;
				}
			}
		}
	}

	void Start () {
		distance = Mathf.Infinity;
	}

	// Update is called once per frame
	void Update () {
		if (target != null) {
			//Always face target
			Quaternion lookRotation = Quaternion.LookRotation (target.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, TurnSpeed * Time.deltaTime);


			//Update distance to tartget
			distance = Vector3.Distance (transform.position, target.position);

			//Fires at target
			if (nextShotTime < Time.time) {
				Shot shot = Instantiate (ShotPrefab).GetComponent<Shot> ();
				shot.transform.position = transform.position + Vector3.up;
				shot.Target = target.transform.position;

				//Time till next attack
				nextShotTime += 1 / AttackSpeed;
			}

			//Find new target if old target loses range
			if (distance > Range) {
				findTarget ();
			}
		} else {
			findTarget ();
			if (nextShotTime < Time.time) {
				nextShotTime = Time.time;
			}
		}
	}
}
