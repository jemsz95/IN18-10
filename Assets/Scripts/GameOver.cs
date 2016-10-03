using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public void NewGame () {
		GameManager.instance.NewGame ();
	}

	public void Quit () {
		GameManager.instance.Quit ();
	}
}
