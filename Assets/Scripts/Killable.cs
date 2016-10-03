using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

	public float MaxHealth;
	public float Health;

	//Reduce health and return bool isAlive
	public bool Damage(float amt) {
		Health -= amt;
		return Health < 0;
	}

	//Increase health and return bool isAtMaxHealth
	public bool Heal(float amt) {
		Health += amt;

		if (Health > MaxHealth) {
			Health = MaxHealth;
		}

		return Health == MaxHealth;
	}

	public void Kill () {
		Health = 0;
	}

	public void Restore () {
		Health = MaxHealth;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			GameManager.instance.Currency += 2;
			Destroy (gameObject);
		}
	}
}
