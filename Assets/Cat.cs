using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	GUIText scoreText, objectiveText, caughtText;

	private const int objScore = 900;
	string objectiveTextString = "Objectives\n\nCause $" + objScore.ToString() + " of damage - ";

	public int score;
	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			scoreText.text = "$ " + score.ToString();
			if (score >= objScore) {
				objectiveText.text = objectiveTextString + "Complete";
				caughtText.text = "Good job, Evil Cat!\nYou did it in " + Time.time.ToString("0.00") + " seconds";
				caughtText.enabled = true;
			}
		}
	}

	KeyboardMovement movement;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("ScoreText").GetComponent<GUIText>();
		objectiveText = GameObject.Find ("ObjectivesText").GetComponent<GUIText>();
		caughtText = GameObject.Find ("CaughtText").GetComponent<GUIText>();
		caughtText.enabled = false;

		movement = GetComponent<KeyboardMovement> ();

		objectiveText.text = objectiveTextString + "Pending";
		score = 0;
	}

	private float reload_duration = 3f;

	bool isCaught = false;

	public void Caught ()
	{
		if (isCaught) return;
		isCaught = true;
		movement.isEnabled = false;
		caughtText.enabled = true;
		Invoke("ReloadLevel", reload_duration);
	}

	void ReloadLevel() {
		isCaught = false;
		Application.LoadLevel (Application.loadedLevel);
		movement.isEnabled = true;
	}
}
