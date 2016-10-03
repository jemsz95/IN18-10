using UnityEngine;
using System.Collections;

public class RadialMenuSpawner : MonoBehaviour {

	public static RadialMenuSpawner Instance = null;
	public RadialMenu MenuPrefab;
	public GridSystem Grid;

	public void SpawnMenu (MenuOpener opener) {
		RadialMenu menu = (RadialMenu) Instantiate (MenuPrefab);
		menu.transform.SetParent (transform);
		menu.transform.position = Input.mousePosition;

		menu.Grid = Grid;

		menu.SpawnButtons (opener);
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
	}
}
