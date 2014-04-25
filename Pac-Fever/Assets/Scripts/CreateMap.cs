﻿using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[,] map = {
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,4,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,4,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1},
			{1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,1,1,1,1,1,1},
			{0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0},
			{1,1,1,1,1,1,0,1,1,0,0,1,1,1,1,1,1,0,0,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1},
			{1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,0,1,1,1,1,0,1,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,1,1,1,0,1},
			{1,4,0,0,1,1,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,1,1,0,0,4,1},
			{1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1},
			{1,1,1,0,1,1,0,1,1,0,1,1,1,1,1,1,1,1,0,1,1,0,1,1,0,1,1,1},
			{1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,1},
			{1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
			{1,0,1,1,1,1,1,1,1,1,1,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,0,1},
			{1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
		};

		for (int y = 0; y < 29; y++){
			for (int x = 0; x < 32; x++){
				if (map[x,y] == 0){
					//road
					GameObject road = (GameObject)Instantiate(GameObject.Find("Road"), new Vector3(x, y, 0.0f),Quaternion.identity);
					GameObject cheese = (GameObject)Instantiate(GameObject.Find("Cheese"), new Vector3(x, y, 0.5f),Quaternion.identity);

				}
				else if (map[x,y] == 1){
					//wall
					GameObject wall = (GameObject)Instantiate(GameObject.Find("Wall"), new Vector3(x, y, 0.0f),Quaternion.identity);
				}
				else if (map[x,y] == 2)	{
					//road with ghost spawn
					GameObject road = (GameObject)Instantiate(GameObject.Find("Road"), new Vector3(x, y, 0.0f),Quaternion.identity);
					//ghost
					GameObject ghost = (GameObject)Instantiate(GameObject.Find("Ghost"), new Vector3(x, y, 0.5f),Quaternion.identity);
				}
				else if (map[x,y] == 3){
					//road with pacman spawn
					GameObject road = (GameObject)Instantiate(GameObject.Find("Road"), new Vector3(x, y, 0.0f),Quaternion.identity);
					GameObject pacman = (GameObject)Instantiate(GameObject.Find("Pacman"), new Vector3(x, y, 0.0f),Quaternion.identity);

				}
				else if (map[x,y] == 4)	{
					//road with UberCheese
					GameObject road = (GameObject)Instantiate(GameObject.Find("Road"), new Vector3(x, y, 0.0f),Quaternion.identity);
					GameObject uberCheese = (GameObject)Instantiate(GameObject.Find("UberCheese"), new Vector3(x, y, 0.5f),Quaternion.identity);
															
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {	}

}
