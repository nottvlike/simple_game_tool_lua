using UnityEngine;
using System.Collections;

public class Doom_Collider : MonoBehaviour {
	public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision ll )
	{
		parent.GetComponent<Doom> ().onColliderEnter (ll);
	}
	
	void OnCollisionExit( Collision ll )
	{
		parent.GetComponent<Doom> ().onColliderExit (ll);
	}
}
