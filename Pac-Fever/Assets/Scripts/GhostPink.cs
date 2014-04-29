using UnityEngine;
using System.Collections;

public class GhostPink : Ghost {
	
	// Use this for initialization
	public override void Start () {
		base.Start();
		
		//base.scatter = top left
		gameObject.tag = "GhostPink";
		base.color = Color.Lerp(Color.magenta, Color.Lerp(Color.red, Color.white, 0.5f), 0.5f);
		renderer.material.color = color;
		
		GameObject mm = GameObject.FindGameObjectWithTag("MapCreate") as GameObject;
		MapManager m = mm.GetComponent(typeof(MapManager)) as MapManager;
		base.scatter = new Vector3(2,0,-2);
	}
	
	public override void updateTarget()
	{
		// Pacman dir + 4
		GameObject pacObj = GameObject.FindGameObjectWithTag("Player") as GameObject;
		MovingObject pac = pacObj.GetComponent("Pacman") as MovingObject;
		
		base.target = pacObj.transform.position + 4 * pac.direction;
		
	}
}

