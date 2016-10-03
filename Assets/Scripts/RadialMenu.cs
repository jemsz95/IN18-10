using UnityEngine;
using System.Collections;

public class RadialMenu : MonoBehaviour {

	public RadialButton ButtonPrefab;
	public RadialButton Selected;
	public GridSystem Grid;

	private Tile tile;

	// Use this for initialization
	public void SpawnButtons (MenuOpener opener) {
		tile = opener.gameObject.GetComponent<Tile> ();

		for (int i = 0; i < opener.options.Length; i++) {
			RadialButton button = (RadialButton) Instantiate (ButtonPrefab);
			button.transform.SetParent (transform);

			float theta = (2 * Mathf.PI / opener.options.Length) * i;
			float x = Mathf.Sin (theta);
			float y = Mathf.Cos (theta);

			Vector3 position = new Vector3 (x, y, 0f) * 100;
			button.transform.localPosition = position;

			button.Icon.sprite = opener.options [i].icon;
			button.Title = opener.options [i].title;
			button.Tower = opener.options [i].tower;
			button.Circle.color = opener.options [i].color;
			button.Menu = this;
		}
	}

	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			if (Selected != null) {
				//Debug.Log (Selected.Tower);
				//Debug.Log (tile.Coordinate);
				if (!Grid.PlaceChild (Selected.Tower, tile.Coordinate)) {
					Debug.Log ("Unable to insert " + Selected.Title);
				}
			}

			Destroy (gameObject);
		}
	}
}
