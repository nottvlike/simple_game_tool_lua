using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public GameObject obj;
	private float distanceZ = 0f;
	private Vector3 pos = new Vector3();
	// Use this for initialization
	void Start () {
		distanceZ = transform.position.z - obj.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		pos.x = transform.position.x;
		pos.y = transform.position.y;
		pos.z = distanceZ + obj.transform.position.z;
		transform.position = pos;
	}
}
