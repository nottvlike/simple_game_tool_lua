using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public Transform Target;
	public float Distance = 10.0f;
	// the height we want the camera to be above the target
	public float Height = 5.0f;
	// How much we 
	public float HeightDamping = 2.0f;
	public float RotationDamping = 3.0f;

	Vector3 _pos = Vector3.zero;
	// Update is called once per frame
	void Update () {
		if (!Target)
			return;
		
		// Calculate the current rotation angles
		var wantedRotationAngle = Target.eulerAngles.y;
		var wantedHeight = Target.position.y + Height;
		
		var currentRotationAngle = transform.eulerAngles.y;
		var currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, RotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, HeightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = Target.position;
		transform.position -= currentRotation * Vector3.forward * Distance;

		_pos = transform.position;
		_pos.y = currentHeight;
		// Set the height of the camera
		transform.position = _pos;
		
		// Always look at the target
		transform.LookAt (Target);
	}
}
