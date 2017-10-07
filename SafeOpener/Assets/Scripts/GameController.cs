using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	static public List<Level> levels = new List<Level>();

	void Awake() {
		levels.Add(new Level(1, 1, 0.1f, 0.4f,60,1));
		levels.Add(new Level(2, 2, 0.1f, 0.4f,50,2));
		levels.Add(new Level(3, 3, 0.1f, 0.4f,30,3));
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
