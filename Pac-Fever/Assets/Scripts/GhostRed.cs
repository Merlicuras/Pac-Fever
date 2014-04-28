using UnityEngine;
using System.Collections;

public class GhostRed : Ghost {

	void Start () {
		base.Start();
		
		//Scatter location at top right
		MapManager m = GameObject.FindGameObjectWithTag("MapCreate") as MapManager;
		base.scatter = Vector3(m.map.GetLength(0)-1,0,-2);
	}

	void updateTarget()
	{
		//Target is le Pacman!
		pac = GameObject.FindGameObjectWithTag("Player") as Pacman;
		base.target = pac.position;
	}
	
}

