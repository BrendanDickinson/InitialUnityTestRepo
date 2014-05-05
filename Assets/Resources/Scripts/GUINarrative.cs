using UnityEngine;
using System.Collections;

public class GUINarrative : MonoBehaviour {
	private static int windowWidth = 500;
	private static int windowHeight = 500;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	Rect windowRect = new Rect(Screen.width/2 - windowWidth/2, Screen.height/2 - windowHeight/2, windowWidth, windowHeight);
    void OnGUI() {
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "");
    }
    void DoMyWindow(int windowID) {
        if (GUI.Button(new Rect(380, 460, 100, 20), "Play Game"))
            Destroy(this);
		GUILayout.Label("Once upon a time there was a man named Indiana Jones");
        
    }
}

