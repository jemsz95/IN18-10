using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
	
public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;

	public int Level { get; private set; }
	public int Currency { get; set; }

	bool inGame = false;

	public void NewGame () {
		SceneManager.LoadScene ("Game");
	}

	public void Quit () {
		Application.Quit ();
	}

	public void NextLevel () {
		Level++;
	}

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}
			
		DontDestroyOnLoad(gameObject);

		SceneManager.sceneLoaded += delegate {
			if(SceneManager.GetActiveScene().name == "Game") {
				this.inGame = true;
				this.Level = 1;
				this.Currency = 50;

				GameObject[] spawners = GameObject.FindGameObjectsWithTag ("MinionSpawner");

				if (spawners.Length == 0) {
					Debug.LogWarning ("No MinionSpawner(s) found");
				}

				foreach (GameObject spawner in spawners) {
					spawner.GetComponent<MinionSpawner> ().Run ();
				}
			}
		};
	}

	//Update is called every frame.
	void Update() {
		if (inGame) {
			if (PlayerBase.instance.Health <= 0) {
				//Game over
				inGame = false;

				SceneManager.LoadScene ("End");
			}
		}
	}
}