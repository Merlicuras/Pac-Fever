using UnityEngine;
using System.Collections;

public class GhostRed : Ghost {

	public override void Start () {
		base.Start();
		gameObject.tag = "GhostRed";
		renderer.material.color = Color.red;
		
		//Scatter location at top right
		GameObject mm = GameObject.FindGameObjectWithTag("MapCreate") as GameObject;
		MapManager m = mm.GetComponent(typeof(MapManager)) as MapManager;
		base.scatter = new Vector3(m.map.GetLength(0)-1,0,-2);
	}

	public override void updateTarget()
	{
		//Target is le Pacman!
		GameObject pacObj = GameObject.FindGameObjectWithTag("Player") as GameObject;
		base.target = pacObj.transform.position;
	}
	
}

