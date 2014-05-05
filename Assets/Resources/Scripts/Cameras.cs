using UnityEngine;
using System.Collections;

public class Cameras : MonoBehaviour {
	public Vector3 thirdPerson;
	public Vector3 firstPerson;
	public Vector3 twoThirdsPerspective;
	public Vector3 thirdPersonRotation;
	public Vector3 firstPersonRotation;
	public Vector3 twoThirdsPerspectiveRotation;
	public float moveSpeed;
	public bool atThird = false;
	public bool atFirst = false;
	public bool atTwoThirds = false;
	
// The target we are following
	public Transform target;
	public Transform target2;
// The distance in the x-z plane to the target
	public float distance = 3.0f;
// the height we want the camera to be above the target
	public float height = 1.0f;
// Damping the movements to make them smoother
	public float heightDamping = 10.0f;
	public float rotationDamping = 5.0f;
	
	
	
	// Use this for initialization
	void Start () {
	twoThirdsPerspective = new Vector3(20f,50f,20f);
	twoThirdsPerspectiveRotation = new Vector3(90f,0,0);
	thirdPerson = target.transform.localPosition;
	thirdPersonRotation = target.transform.localEulerAngles;
	
	firstPerson = new Vector3(0,0.5f,0.5f);
	firstPersonRotation = new Vector3(0,0,0);
	Camera.main.transform.position = twoThirdsPerspective;
	Camera.main.transform.eulerAngles = twoThirdsPerspectiveRotation;
	atFirst = true;
	moveSpeed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("c")){
			//Debug.Log("PRESSING C!!");
			if(atTwoThirds){
				atThird = true;
				atTwoThirds = false;
			}
			else if(atThird){
				atThird = false;
				atFirst = true;
			}
			else if(atFirst){
				atFirst = false;
				atTwoThirds = true;
			}
		}
		if(atFirst){
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, twoThirdsPerspective, Time.deltaTime*moveSpeed);
			Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, twoThirdsPerspectiveRotation, Time.deltaTime*moveSpeed);
		}		
	}
		
	
	void LateUpdate () {
	// Early out if we don't have a target
	if(atTwoThirds){
	if(!target)
		return;
	
	// Calculate the current rotation angles
	float wantedRotationAngle = target.eulerAngles.y;
	float wantedHeight = target.position.y + height;
		
	float currentRotationAngle = transform.eulerAngles.y;
	float currentHeight = transform.position.y;
	
	// Damp the rotation around the y-axis
	currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

	// Damp the height
	currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

	// Convert the angle into a rotation
	Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
	// Set the position of the camera on the x-z plane to:
	// distance meters behind the target
	transform.position = target.position;
	transform.position -= currentRotation * Vector3.forward * distance;

	// Set the height of the camera
	transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);
	
	// Always look at the target
	transform.LookAt(target);
	}
	
	if(atThird){
	if(!target2)
		return;
	rotationDamping = 20f;
	// Calculate the current rotation angles
	float wantedRotationAngle = target2.eulerAngles.y;
	float wantedHeight = target2.position.y + height;
		
	float currentRotationAngle = transform.eulerAngles.y;
	float currentHeight = transform.position.y;
	
	// Damp the rotation around the y-axis
	currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

	// Damp the height
	currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

	// Convert the angle into a rotation
	Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
	// Set the position of the camera on the x-z plane to:
	// distance meters behind the target
	transform.position = target2.position;
	transform.position -= currentRotation * Vector3.forward * distance;

	// Set the height of the camera
	transform.position = new Vector3 (transform.position.x, currentHeight, transform.position.z);
	
	// Always look at the target
	transform.LookAt(target2);
	rotationDamping = 5f;
	}	
}
}
