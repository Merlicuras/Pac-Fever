using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int cheeses;
	int level;
	int levelStage;

	int pinkSecs;
	int orangeSecs;
	float startTime;

	void Start () {
		//Initiate start screen
		level = 1;
		cheeses = 0;
		levelStage = 0;
		pinkSecs = 10;
		orangeSecs = 15;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		switch (levelStage) {
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
	}
}
