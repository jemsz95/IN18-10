using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public GameObject Prefab;

	private GameObject instance;

	public void ShowInstructions () {
		instance = Instantiate (Prefab);

		instance.transform.SetParent (transform);
		instance.transform.localPosition = Vector3.zero;
	}

	public void HideInstructions () {
		Destroy (instance);
	}
}
