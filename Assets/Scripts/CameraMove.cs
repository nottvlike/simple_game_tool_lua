using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public GameObject player;
	private float zLimit = 0;
	private Vector3 vec = new Vector3();
	// Use this for initialization
	void Start () {
		zLimit = player.transform.position.z - transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		vec = transform.position;
		vec.z = player.transform.position.z - zLimit;
		transform.position = vec;
//		Vector3 targetPos = player.transform.position;
//		
//		wantedPosition.x =  targetPos.x;
//		
//		wantedPosition.z = targetPos.z - 5f;//Vector3.forward*distance;   
//		
//		wantedPosition.y = targetPos.y -2f;// + heightAbovePlayer;
//		
//		currentX = Mathf.SmoothDamp(currentX, wantedPosition.x, ref xVelocity, distanceSnapTime);
//		
//		currentY = Mathf.SmoothDamp(currentY, wantedPosition.y, ref yVelocity, distanceSnapTime);
//		
//		currentZ = Mathf.SmoothDamp(currentZ, wantedPosition.z, ref zVelocity, 0.5f);
//		
//		transform.position = new Vector3(currentX,currentY,currentZ);
//		transform.LookAt(transform.position + new Vector3(0f,0.95f,1));
	}
}
