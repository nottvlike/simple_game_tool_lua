using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	GameObject _followObj;
	private float distanceX = 0f;
	private Vector3 pos = new Vector3();
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (_followObj != null) {
			pos.x = distanceX + _followObj.transform.position.x;
			pos.y = transform.position.y;
			pos.z = transform.position.z;
			transform.position = pos;
		}
	}

	public void SetTarget(GameObject obj)
	{
		_followObj = obj;
		distanceX = transform.position.x - _followObj.transform.position.x;
	}
}
