using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseHealthLabel : MonoBehaviour {

	Text label;

	// Use this for initialization
	void Start () {
		label = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = PlayerBase.instance.Health.ToString () + "%";
	}
}
