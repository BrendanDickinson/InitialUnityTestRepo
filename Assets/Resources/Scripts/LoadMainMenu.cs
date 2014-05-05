using UnityEngine;
using System.Collections;

public class LoadMainMenu : MonoBehaviour {
	public float timer = 0f;
	public bool load = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	timer = timer + Time.deltaTime;
		if(timer >= 2.5 && load == false){
		
			Fade.LoadLevel("Wumpus_World_Main_Menu", 2, 1, Color.black);
			load = true;
		}
	}
	
	void OnGUI(){
		if(Event.current.type == EventType.KeyDown && load == false){
			KeyPressedEventHandler();
		}
	}
	
	void KeyPressedEventHandler(){
		Application.LoadLevel(0);
		load = true;
	}
}
