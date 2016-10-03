using UnityEngine;
using System.Collections;
using System;

public class GridSystem : MonoBehaviour {

	public struct Node {
		public bool Buildable;
		public bool Available;
	};

	public Vector2 Dimentions;
	public Vector2 Size;
	public GameObject NodePrefab;
	public Coordinate2[] UnavailableNodes; 

	private Node[,] nodes;

	public void Draw () {
		GameObject tilesParent = transform.FindChild ("Tiles").gameObject;
		if (tilesParent != null) {
			DestroyImmediate (tilesParent);
		}

		tilesParent = new GameObject("Tiles");
		tilesParent.transform.SetParent	(transform);
		tilesParent.transform.localPosition = Vector3.zero;

		for (int i = 0; i < Dimentions.x; i++) {
			for (int j = 0; j < Dimentions.y; j++) {
				Tile node = Instantiate (NodePrefab).GetComponent<Tile> ();

				node.transform.parent = tilesParent.transform;
				node.transform.localPosition = new Vector3 ((Size.x * ((2.0f * i) - Dimentions.x + 1)) / (2.0f * Dimentions.x), 0, (Size.y * ((2.0f * j) - Dimentions.y + 1.0f)) / (2.0f * Dimentions.y));
				node.transform.localScale = new Vector3 (Size.x / Dimentions.x, Size.y / Dimentions.y, 1);

				node.Coordinate = new Coordinate2 (i, j);
			}
		}
	}
		
	public bool PlaceChild (Tower towerPrefab, Coordinate2 coord) {
		if (!nodes [coord.X, coord.Y].Available || !nodes [coord.X, coord.Y].Buildable) {
			Debug.Log ("[" + coord.X + ", " + coord.Y + "]: Available(" + nodes [coord.X, coord.Y].Available + ") - Buildable(" + nodes [coord.X, coord.Y].Buildable + ")");
			return false;
		}

		if (towerPrefab.Price > GameManager.instance.Currency) {
			return false;
		}

		Transform towerParent = transform.FindChild ("Towers");

		if (towerParent == null) {
			towerParent = new GameObject ("Towers").transform;
			towerParent.transform.SetParent	(transform);
			towerParent.transform.localPosition = Vector3.zero;
		}

		Tower obj = Instantiate (towerPrefab).GetComponent<Tower> ();

		obj.transform.SetParent (towerParent);

		Vector3 pos = new Vector3 ((Size.x * ((2.0f * coord.X) - Dimentions.x + 1.0f)) / (2.0f * Dimentions.x), 0, (Size.y * ((2.0f * coord.Y) - Dimentions.y + 1.0f)) / (2.0f * Dimentions.y));
		obj.transform.localPosition = pos;

		GameManager.instance.Currency -= obj.Price;

		nodes [coord.X, coord.Y].Available = false;

		return true;
	}


	void Start () {
		nodes = new Node[(int) Dimentions.x, (int) Dimentions.y];

		Array.Sort (UnavailableNodes);

		for (int i = 0; i < Dimentions.x; i++) {
			for (int j = 0; j < Dimentions.y; j++) {
				//Compare current node to Unavailable nodes array
				nodes [i, j].Buildable = Array.BinarySearch (UnavailableNodes, new Coordinate2 (i, j)) < 0;
				nodes [i, j].Available = true;
			}
		}

		Draw ();
	}
}
