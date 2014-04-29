using UnityEngine;
using System.Collections;

public class GhostOrange : Ghost {
	
	// Use this for initialization
	public override void Start () {
		base.Start();
		
		//base.scatter = new Vector2(Bottom left, 2 down);
		gameObject.tag = "GhostOrange";
		base.color = Color.Lerp (Color.red, Color.yellow, 0.5f);
		renderer.material.color = color;

		GameObject mm = GameObject.FindGameObjectWithTag("MapCreate") as GameObject;
		MapManager m = mm.GetComponent(typeof(MapManager)) as MapManager;
		base.scatter = new Vector3(0,0,-m.map.GetLength(1)+2);
	}
	
	public override void updateTarget()
	{
		// If more than 8 away, then go for Pacman
		GameObject pacObj = GameObject.FindGameObjectWithTag("Player") as GameObject;
		if(Vector3.Distance(transform.position, pacObj.transform.position) > 8)
		{
			base.target = pacObj.transform.position;
		}
		else
		{
			//Else for scatter location
			base.target = base.scatter;
		}
		
	}
}

