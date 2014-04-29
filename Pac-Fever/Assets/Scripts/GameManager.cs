using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int cheeses;
	int level;
	int levelStage;

	int pinkSecs;
	int orangeSecs;
	float startTime;
	public Ghost.Mode currentMode;
	bool uCheese;

	Pacman pac = null;

	void Start () {
		//Initiate start screen
		level = 1;
		cheeses = 0;
		levelStage = -1;
		pinkSecs = 5;
		orangeSecs = 10;
		currentMode = Ghost.Mode.Chase;
		uCheese = false;

	}
	
	// Update is called once per frame
	void Update () {
		switch (levelStage) {
		case -2:
			//Replay or quit, wait and see
			pacmanKilled();
			levelStage = -2;
			break;

		case -1:
			//Pre-start. Show helper text
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W)
			   || Input.GetKeyDown(KeyCode.D) ||Input.GetKeyDown(KeyCode.S))
			{
				GameObject g = GameObject.FindGameObjectWithTag ("Player");
				pac = g.GetComponent ("Pacman") as Pacman;
				pac.isMoving = true;
				startTime = Time.time;
				levelStage = 0;
			}
			break;
		case 0:
			//Start fase. Release Red!
			GameObject Gro = GameObject.FindGameObjectWithTag("GhostRed");
			Ghost Gr = Gro.GetComponent("GhostRed") as Ghost;
			Gr.changeMode(Ghost.Mode.Chase);
			levelStage = 1;
			break;

		case 1:
			//Pink next after 10 sec
			if(Time.time - startTime < pinkSecs)
				break;
			GameObject Gpo = GameObject.FindGameObjectWithTag("GhostPink");
			Ghost Gp = Gpo.GetComponent("GhostPink") as Ghost;
			Gp.changeMode(Ghost.Mode.Chase);
			levelStage = 2;
			break;

		case 2:
			//Blue after 30 cheese
			if(cheeses < 30)
				break;
			GameObject Gbo = GameObject.FindGameObjectWithTag("GhostBlue");
			Ghost Gb = Gbo.GetComponent("GhostBlue") as Ghost;
			Gb.changeMode(Ghost.Mode.Chase);
			levelStage = 3;
			startTime = Time.time;
			break;

		case 3:
			//Orange (after 1/3 cheeses in lvl1)
			int totalCheeses = GameObject.FindGameObjectsWithTag("Cheese").GetLength(0);
			if(level == 1 && cheeses/totalCheeses < 1/3)
				break;

			if(Time.time - startTime < orangeSecs)
				break;
			
			GameObject Goo = GameObject.FindGameObjectWithTag("GhostOrange");
			Ghost Go = Goo.GetComponent("GhostOrange") as Ghost;
			Go.changeMode(Ghost.Mode.Chase);
			levelStage = 4;
			startTime = Time.time;
			break;
		}

		if (pac == null)
		{
			GameObject g = GameObject.FindGameObjectWithTag ("Player");
			pac = g.GetComponent ("Pacman") as Pacman;
			Debug.Log(pac.tag);
		}

		if (uCheese && !pac.state)
			uberCheese (false);
		else if(!uCheese && pac.state)
			uberCheese(true);
	}

	public void uberCheese(bool enabled)
	{
		//Change mode to frightened on all ghosts (except dead ones)
		GameObject Gr = GameObject.FindGameObjectWithTag("GhostRed");
		GameObject Gb = GameObject.FindGameObjectWithTag ("GhostBlue");
		GameObject Gp = GameObject.FindGameObjectWithTag ("GhostPink");
		GameObject Go = GameObject.FindGameObjectWithTag ("GhostOrange");
			
		GameObject [] gAll = new GameObject[4]{Gr,Gb,Gp,Go};

		for(int i = 0; i < 4; i++)
		{
			Ghost g = gAll[i].GetComponent("Ghost") as Ghost;

			if(enabled)
			{
				Debug.Log("Ubercheese enabled");
				uCheese = true;
				if(g.mode != Ghost.Mode.Dead && g.mode != Ghost.Mode.Standby)
				{
					g.changeMode(Ghost.Mode.Frightened);
					g.renderer.material.color = Color.yellow;
				}

			}
			else
			{
				Debug.Log("Ubercheese disabled");
				uCheese = false;
				if(g.mode != Ghost.Mode.Dead && g.mode != Ghost.Mode.Standby)
				{
					g.changeMode(currentMode);
					g.renderer.material.color = g.color;
				}
			}
		}
	}

	public void pacmanKilled()
	{
		//Reset pacman and ghosts. Wait a bit and start!
		GameObject Gr = GameObject.FindGameObjectWithTag("GhostRed");
		GameObject Gb = GameObject.FindGameObjectWithTag ("GhostBlue");
		GameObject Gp = GameObject.FindGameObjectWithTag ("GhostPink");
		GameObject Go = GameObject.FindGameObjectWithTag ("GhostOrange");
		GameObject P = GameObject.FindGameObjectWithTag ("Player");

		Gr.SendMessage ("Reset");
		Gb.SendMessage ("Reset");
		Gp.SendMessage ("Reset");
		Go.SendMessage ("Reset");
		P.SendMessage ("Reset");

		levelStage = -1;
	}

	public void gameOver()
	{
		//Game over. Allow replay (reload level) or quit
		levelStage = -2;
	}

	public void OnGUI()
	{
		if (levelStage != -2)
						return;

		GUI.Box(new Rect(310,310,100,90), "GAME OVER");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(320,340,80,20), "Replay")) {
			Application.LoadLevel(Application.loadedLevel);
		}

		// Make the second button.
		if(GUI.Button(new Rect(320,370,80,20), "Quit")) {
			Application.Quit ();
		}
	}
}
