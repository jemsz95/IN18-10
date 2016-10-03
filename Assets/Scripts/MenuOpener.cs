using UnityEngine;
using System.Collections;

public class MenuOpener : MonoBehaviour {

	[System.Serializable]
	public class RadialMenuOption {
		public Tower tower;
		public Sprite icon;
		public Color color;
		public string title;
	}

	public RadialMenuOption[] options;

	void OnMouseDown () {
		RadialMenuSpawner.Instance.SpawnMenu (this);
	}
}
