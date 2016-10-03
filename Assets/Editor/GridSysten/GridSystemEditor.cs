using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof(GridSystem))]
public class GridSystemEditor : Editor {
	Vector2 targetDimentions;
	Vector2 targetSize;
	GameObject targetNodePrefab;

	void OnEnable () {
		GridSystem grid = (GridSystem) target;

		targetDimentions = grid.Dimentions;
		targetSize = grid.Size;
		targetNodePrefab = grid.NodePrefab;
	}

	public override void OnInspectorGUI() {
		base.OnInspectorGUI ();

		GridSystem grid = (GridSystem) target;

		if (grid.Dimentions != targetDimentions || grid.Size != targetSize || grid.NodePrefab != targetNodePrefab) {
			grid.Draw ();
		}
	}
}
