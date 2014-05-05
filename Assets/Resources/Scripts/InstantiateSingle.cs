using UnityEngine;
using System.Collections;

public class InstantiateSingle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(Resources.Load("Prefabs/SoundSphere"), new Vector3(0,0,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
