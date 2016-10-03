using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Currency : MonoBehaviour {

	private Text amount;

	void Start () {
		amount = GetComponent <Text>();
	}

	// Update is called once per frame
	void Update () {
		amount.text = GameManager.instance.Currency.ToString ();
	}
}
