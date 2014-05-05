using UnityEngine;
using System.Collections;

public class MenuBarMovement : MonoBehaviour {
	public GameObject bar = null;
	public GameObject title;
	public GameObject playGame;
	public GameObject highScores;
	public GameObject instructions;
	public GameObject options;
	public GameObject quitGame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName == "Wumpus_World_Main_Menu"){
		if(Input.GetKeyDown("w") || Input.GetKeyDown ("up")){
				Debug.Log("w is pressed");
			if(bar.transform.position.y == 12)
				bar.transform.Translate(Vector3.down*32);
			else if(bar.transform.position.y == -20)
				bar.transform.Translate(Vector3.up*17);
			else
				bar.transform.Translate(Vector3.up*5);
		}
		else if(Input.GetKeyDown("s") || Input.GetKeyDown ("down")){
			if(bar.transform.position.y == -3)
				bar.transform.Translate(Vector3.down*17);
			else if(bar.transform.position.y == -20)
				bar.transform.Translate(Vector3.up*32);
			else
				bar.transform.Translate(Vector3.down*5);
		}
		else if(Input.GetKeyDown("return") || Input.GetKeyDown("space")){
			if(CheckOption() == "Play Game")
				Fade.LoadLevel("Wumpus_World_1.3", 3, 1, Color.black);
			else if(CheckOption() == "High Scores")
				Debug.Log ("High Scores List is Coming Soon");
			else if(CheckOption() == "Instructions")
				Debug.Log ("Instructionst are Coming Soon");
			else if(CheckOption() == "Options")
				Debug.Log ("Options are Coming Soon");
			else if(CheckOption() == "Quit Game"){
				Debug.Log("Quitting Game");
				Application.Quit();
			}
		}
		}
		else if(Application.loadedLevelName == "Wumpus_World_Game_Over"){
			if(Input.GetKeyDown("w") || Input.GetKeyDown ("up") || Input.GetKeyDown("s") || Input.GetKeyDown ("down")){
				if(bar.transform.position.y == -6.5)
					bar.transform.Translate(Vector3.down*6);
				else if(bar.transform.position.y == -12.5)
					bar.transform.Translate(Vector3.up*6);
			}
			else if(Input.GetKeyDown("return") || Input.GetKeyDown("space")){
				if(CheckOption2() == "Play Game")
					Fade.LoadLevel("Wumpus_World_1.3", 3, 1, Color.black);
				else if(CheckOption2() == "Exit to Menu")
					Fade.LoadLevel ("Wumpus_World_Main_Menu", 3, 1, Color.black);
			}
		}
				
	}
	
	string CheckOption(){
		if(bar.transform.position.y == 12)
			return "Play Game";
		else if(bar.transform.position.y == 7)
			return "High Scores";
		else if(bar.transform.position.y == 2)
			return "Instructions";
		else if(bar.transform.position.y == -3)
			return "Options";
		else if(bar.transform.position.y == -20)
			return "Quit Game";
		else
			return null;
	}
	
	string CheckOption2(){
		if(bar.transform.position.y == -6.5)
			return "Play Game";
		else if(bar.transform.position.y == -12.5)
			return "Exit to Menu";
		else
			return null;
		
	}
}
