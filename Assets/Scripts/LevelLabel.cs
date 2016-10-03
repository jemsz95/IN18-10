using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLabel : MonoBehaviour {

	Text level;

	// Use this for initialization
	void Start () {
		level = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		level.text = "Level " + GameManager.instance.Level;
	}
}
