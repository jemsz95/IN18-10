using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Image Circle;
	public Image Icon;
	public string Title;
	public Tower Tower;
	public RadialMenu Menu;
	public Text priceText;


	private Color defaultColor;

	public void OnPointerEnter (PointerEventData eventData) {
		defaultColor = Circle.color;

		Circle.color = Color.white;

		Menu.Selected = this;
	}

	public void OnPointerExit (PointerEventData eventData) {
		Circle.color = defaultColor;

		Menu.Selected = null;
	}

	void Start () {
		priceText.text = Tower.Price.ToString ();
	}
}
