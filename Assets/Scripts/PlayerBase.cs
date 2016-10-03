using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour {
	public static PlayerBase instance = null;
	public float Health = 100;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Minion") {
			Killable minion = other.GetComponent<Killable> ();

			Health -= 1;

			minion.Kill ();
		}
	}

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}
}
