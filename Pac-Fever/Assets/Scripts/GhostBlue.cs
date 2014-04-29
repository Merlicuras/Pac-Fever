using UnityEngine;
using System.Collections;

public class GhostBlue : Ghost {
	
		public override void Start()
		{
			base.Start();
			//base.scatter = new Vector2(Bottom right, 2 down);
			gameObject.tag = "GhostBlue";
			renderer.material.color = Color.blue;
			GameObject mm = GameObject.FindGameObjectWithTag("MapCreate") as GameObject;
			MapManager m = mm.GetComponent(typeof(MapManager)) as MapManager;
			base.scatter = new Vector3(m.map.GetLength(0)-1,0,m.map.GetLength(1)+2);
		}
		
		public override void updateTarget()
		{
			//We need location of Red and Pacman
			GameObject redObj = GameObject.FindGameObjectWithTag("GhostRed") as GameObject;
			GameObject pacObj = GameObject.FindGameObjectWithTag("Player") as GameObject;
			Pacman pac = pacObj.GetComponent ("Pacman") as Pacman;
			
			//Pacman + 2 in direction
			Vector3 pacPlus2 = pacObj.transform.position + pac.direction *  2;
			
			//Vector to there, times two
			Vector3 vecRedtoPP2 = pacPlus2 - redObj.transform.position;
			base.target = vecRedtoPP2 * 2;
			
			
		}
}

