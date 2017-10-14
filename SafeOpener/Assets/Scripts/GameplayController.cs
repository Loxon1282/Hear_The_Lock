using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameplayController : MonoBehaviour {
	public Font[] fonts;
	public GameObject safe;
	public Text pointsText;

	// Time management
	public float timer = 0;
	public float timerRounded;
	public Text timerText;

	//ADS
	int ads ;
//	string gameID;

	#if UNITY_ANDROID
	private string gameID = "1573893";
	#endif
	// Buttons
	public bool rightButtonDown, leftButtonDown;

	// Rotation speeds
	public float speed = 0.35f;
	public float currentSpeed = 0.35f;
	public float speedStep = 0.25f;

	// Code volumes
	public float[] soundVals = new float[180];

	// Code management
	public int currentSafeState, lastSafeState;
	public int generatedCode;
	public int[] codeCombination;
	public int[] userCombination;
	public int currentCodePosition;
	public Text urCode;
	public Text buttonText;

	// hehexd
	public float points;
	public float startingTimer;
	public float maxScore;

	// Ending variables
	public GameObject endingScreen,restoreScreen;
	public bool gameEnded;
	public Text endingText;
	public Text endingHighScore;
	public Text starsText;

	// Level variables
	public int levelName;
	public float difficulty;
	public float lowestVol, highestVol;
	public int codeCombinationCount;
	public float maxTime;


	void Awake() {
		Destroy(GameObject.Find ("Audio Source"));
		endingScreen = GameObject.Find ("EndingInfo");
		endingScreen.SetActive (false);
		restoreScreen.SetActive (false);
		gameEnded = false;
		startingTimer = 4f;
		levelName = int.Parse(SceneManager.GetActiveScene ().name);
		difficulty = GameController.levels [levelName].Difficulty;
		lowestVol = GameController.levels [levelName].VolMin;
		highestVol = GameController.levels [levelName].VolMax;
		codeCombinationCount = GameController.levels [levelName].CodeCombinationCount;
		maxTime = GameController.levels [levelName].MaxTime;
		maxScore = (difficulty/10f) * 10000f * codeCombinationCount;

		points = 0;
		timerRounded = maxTime;
		currentCodePosition = 0;
		codeCombination = new int[codeCombinationCount];
		userCombination = new int[codeCombinationCount];
		for (int i = 0; i < codeCombinationCount; i++) {
			codeCombination [i] = Random.Range (1, 180);
			userCombination [i] = 0;
		}
		rightButtonDown = false;
		leftButtonDown = false;

		//urCode.text = "[" + codeCombinationCount +"]";
		urCode.text = "";
	}
	void Start () {
		gameID="1573893";
		Advertisement.Initialize(gameID);
		GenerateSafe ();
		ads = PlayerPrefs.GetInt ("Ads", 0) + 1;


	}
	void Update () {
		if (startingTimer > 0) {
			startingTimer = startingTimer - Time.fixedDeltaTime;
			timerText.text = Mathf.Round (startingTimer).ToString ();
		} else if(gameEnded == false){
			if(timer>0)
				timer = timer - Time.fixedDeltaTime;
			timerRounded = Mathf.Round (timer * 10f) / 10f;


			if (timerRounded <= 0) {								//PRZEGRANA
				timer = 0;
				if (ads % 3 == 0 && ads > 0) {
					timerText.text = "0";

					restoreScreen.SetActive (true);
				} else {
					EndingScreen ("lose");
				}
			}


			if (timerRounded - Mathf.RoundToInt (timerRounded) != 0) {
				timerText.text = timerRounded.ToString ();
			} else {
				timerText.text = timerRounded.ToString () + ".0";
			}
			if (leftButtonDown == true) {
				safe.transform.Rotate (new Vector3 (0, 0, currentSpeed));
			}
			if (rightButtonDown == true) {
				safe.transform.Rotate (new Vector3 (0, 0, -currentSpeed));
			}
			if (rightButtonDown || leftButtonDown && currentSpeed < 1) {
				currentSpeed += speedStep * Time.fixedDeltaTime;
			}
			if (!rightButtonDown && !leftButtonDown) {
				currentSpeed = speed;
			}
			if (Input.GetKeyDown (KeyCode.F1)) {
				SceneManager.LoadScene ("testingLvl");
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				GenerateSafe ();
			}
			if (Input.GetKeyDown (KeyCode.Return)) {
				CheckCode ();
			}
			currentSafeState = Mathf.RoundToInt ((safe.transform.localEulerAngles.z) / 2);
			if (currentSafeState == 180) {
				currentSafeState = 179;
			}
			if (lastSafeState != currentSafeState && currentSafeState != 180) {
				this.GetComponent<AudioSource> ().volume = soundVals [currentSafeState] * 0.7f;
				this.GetComponent<AudioSource> ().Play ();
				//Debug.Log (currentSafeState + " was played." + " with " + soundVals [currentSafeState] + "volume");
				lastSafeState = currentSafeState;
				if (buttonText.font != fonts [1]) {
					buttonText.font = fonts [1];
				}
				buttonText.text = (currentSafeState + 1).ToString ();
			}
		}
	}
	public void EndingScreen(string str) {
		PlayerPrefs.SetInt ("Ads", ads);
		if (ads % 7 == 0 && ads > 0) {
			if (Advertisement.IsReady ()) {
				Advertisement.Show ();

			}
		}
		Debug.Log ("ADS: " + PlayerPrefs.GetInt ("Ads"));
		gameEnded = true;
		points = Mathf.RoundToInt (points);
		endingScreen.SetActive (true);

		if (str == "win") {
			
			if(GameController.highScores[levelName] < points) {
				PlayerPrefs.SetInt ("highScore" + levelName.ToString(), (int)points);
			}

			float percents = (points * 100f) / maxScore;
			Debug.Log (percents);
			int stars = 0;
			if (percents > 0 && percents < 40) {
				stars = 1;
			} else if (percents >= 40 && percents < 80) {
				stars = 2;
			} else if (percents >= 80) {
				stars = 3;
			}
			if(PlayerPrefs.GetInt("stars" + levelName.ToString()) < stars) {
				PlayerPrefs.SetInt ("stars" + levelName.ToString (), stars);
			}
			Debug.Log (stars);

			endingText.text = "POINTS: " + points.ToString ();
			endingHighScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("highScore" + levelName);
		} else {
			restoreScreen.SetActive (false);
			endingText.text = "YOU ARE OUT OF TIME!";
		
		}
	}
	void GenerateSoundVals(int code) {
		float step = (highestVol - lowestVol) / 90;
		for (int i = 0; i < soundVals.Length; i++) {
			float dist = Mathf.Abs(code - i - 1);
			if (dist == 0) {
				soundVals [i] = 0;
			} else if (dist <= 90) {
				soundVals [i] = lowestVol + (dist * step);
			} else {
				soundVals [i] = highestVol - ((dist - 90) * step);
			}

			//Debug.Log (i+1 + " == " + soundVals[i] + " " + dist);
		}
	}
	void GenerateSafe() {
		timer = maxTime;
		buttonText.text = "OK";
		GenerateSoundVals (codeCombination[currentCodePosition]);
		lastSafeState = Mathf.RoundToInt ((safe.transform.localEulerAngles.z) / 2);
	}
	public void CheckCode() {
		if (currentCodePosition < codeCombinationCount) {
			if (buttonText.font != fonts [0]) {
				buttonText.font = fonts [0];
			}
			if (currentSafeState + 1 == codeCombination [currentCodePosition]) {
				userCombination [currentCodePosition++] = currentSafeState + 1;
				urCode.text += (currentSafeState + 1).ToString () + " ";
				points += (difficulty/10f) * ((100f * timerRounded / maxTime) * 100f);
				pointsText.text = "POINTS: " + Mathf.RoundToInt(points).ToString ();
				if (currentCodePosition == codeCombinationCount) {
					EndingScreen ("win");
				} else {
					buttonText.text = "GOOD!";
					Debug.Log ("GOOD!!");
					Invoke ("GenerateSafe", 0.5f);
				}
			} else {
				buttonText.text = "WRONG!";
				Debug.Log ("WRONG!!");
				timer -= difficulty;
			}
		}
	}
	public void SeButtonState(string str) {
		if (str == "reset") {
			leftButtonDown = false;
			rightButtonDown = false;
		}
		if (str == "left") {
			leftButtonDown = true;
		} 
		if (str == "right") {
			rightButtonDown = true;
		}
	}
	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			timer += 20.0f;
			restoreScreen.SetActive (false);
			PlayerPrefs.SetInt ("Ads", PlayerPrefs.GetInt ("Ads", 0) + 1);
			ads++;

		}else if(result == ShowResult.Skipped) {
			EndingScreen ("lose");

		}else if(result == ShowResult.Failed) {
			EndingScreen ("lose");
		}
	}
	public void AdRestore(){
		Advertisement.Show ("", new ShowOptions (){ resultCallback = HandleShowResult });
	}
}
