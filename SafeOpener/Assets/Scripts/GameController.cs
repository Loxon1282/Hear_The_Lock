﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	static public List<Level> levels = new List<Level>();
	static public int[] stars;
	static public int[] highScores;

	void Awake() {
		levels.Add(new Level(1, 1, 0.05f, 0.7f,60,1));
		levels.Add(new Level(2, 2, 0.1f, 0.65f,50,2));
		levels.Add(new Level(3, 2, 0.15f, 0.65f,45,2));
		levels.Add(new Level(4, 2, 0.16f, 0.65f,40,3));
		levels.Add(new Level(5, 3, 0.17f, 0.63f,35,3));
		levels.Add(new Level(6, 3, 0.18f, 0.6f,30,4));
		levels.Add(new Level(7, 3, 0.19f, 0.57f,25,4));
		levels.Add(new Level(8, 4, 0.20f, 0.55f,20,4));
		levels.Add(new Level(9, 4, 0.21f, 0.54f,18,5));
		levels.Add(new Level(10, 4, 0.22f, 0.5f,16,5));
		levels.Add(new Level(11, 4, 0.23f, 0.5f,13,5));
		levels.Add(new Level(12, 4, 0.24f, 0.5f,13,5));
		levels.Add(new Level(13, 4, 0.25f, 0.5f,13,5));
		levels.Add(new Level(14, 4, 0.26f, 0.5f,13,5));
		levels.Add(new Level(15, 4, 0.27f, 0.5f,13,5));
		levels.Add(new Level(16, 4, 0.13f, 0.5f,13,5));
		levels.Add(new Level(17, 4, 0.15f, 0.5f,13,5));
		levels.Add(new Level(18, 4, 0.15f, 0.5f,13,5));
		levels.Add(new Level(19, 4, 0.15f, 0.5f,13,5));
		levels.Add(new Level(20, 4, 0.15f, 0.5f,13,5));
		levels.Add(new Level(21, 4, 0.15f, 0.5f,13,5));
		levels.Add(new Level(22, 4, 0.15f, 0.5f,13,5));
		CheckPrefs ();
		if (SceneManager.GetActiveScene ().name == "levelSelection") {
			SetUpStars ();
		}
	}

	public void CheckPrefs() {
		stars = new int[levels.Count];
		highScores = new int[levels.Count];
		for (int i = 0; i < levels.Count; i++) {
			if (!PlayerPrefs.HasKey ("stars" + i)) {
				PlayerPrefs.SetInt ("stars" + i, 0);
				PlayerPrefs.SetInt ("highScore" + i, 0);
			} 
			stars [i] = PlayerPrefs.GetInt ("stars" + i);
			highScores [i] = PlayerPrefs.GetInt ("highScore" + i);
		}

	}

	public void SetUpStars() {
		int childCount = GameObject.Find ("Levels").transform.childCount;
		Transform[] levelButtons = new Transform[childCount];
		Color filledStar = new Color32(145,220,90,255);
		for (int i = 0; i < childCount; i++) {
			levelButtons [i] = GameObject.Find ("Levels").transform.GetChild (i);
			if(PlayerPrefs.HasKey("stars" + i.ToString())) {
				if (PlayerPrefs.GetInt ("stars" + i.ToString ()) != 0) {
					for (int j = 0; j < PlayerPrefs.GetInt ("stars" + i.ToString ()); j++) {
						levelButtons [i].transform.GetChild (1).transform.GetChild (j).GetComponent<Image> ().color = filledStar;
					}
				}
			}
		}
	}

	public class Level {
		public int Name { get; set; }
		public float Difficulty { get; set; }
		public float VolMin { get; set; }
		public float VolMax { get; set; }
		public float MaxTime { get; set; }
		public int CodeCombinationCount {get; set;}
		public Level(int name, float difficulty, float volMin, float volMax, float maxTime, int codeCombinationCount) {
			this.Name = name;
			this.Difficulty = difficulty;
			this.VolMin = volMin;
			this.VolMax = volMax;
			this.MaxTime = maxTime;
			this.CodeCombinationCount = codeCombinationCount;
		}
	}

}
