using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	private int score;
	private int lives;

	// Use this for initialization
	void Start () {
		score = 0;
		lives = 3;
	}

	public void AddPoints(int score)
	{
		this.score += score;
	}

	public void setLives(int lives)
	{
		this.lives = lives;
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 100), "Score: "+score);
		GUI.Label(new Rect(110, 10, 100, 100), "Lives: "+lives);
		GUI.Label (new Rect (300, 280, 400, 380), "Move with W A S D");
	}
}
