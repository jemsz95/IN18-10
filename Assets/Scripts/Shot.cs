using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public Vector3 Target;
	public float Damage;
	public float Radius;
	public float Speed;
	public float CheckDistance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Move shot towards target
		transform.position += (Target - transform.position).normalized * (Speed * Time.deltaTime);

		//Damage if shot lands and destroy shot object
		if (Vector3.Distance(transform.position, Target) < CheckDistance) {
			Collider[] victims = Physics.OverlapSphere (transform.position, Radius, LayerMask.GetMask("Enemies"));

			foreach (Collider victim in victims) {
				Killable victimKillable = victim.gameObject.GetComponent<Killable> ();

				victimKillable.Damage (Damage);
			}

			Destroy (gameObject);
		}
	}
}
