using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}

	public void AddPoints(int score)
	{
		this.score += score;
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 100), ""+score);
	}
}
