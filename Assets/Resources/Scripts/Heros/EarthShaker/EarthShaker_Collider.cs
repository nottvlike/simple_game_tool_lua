using UnityEngine;
using System.Collections;

public class EarthShaker_Collider : MonoBehaviour {
	public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision ll )
	{
		parent.GetComponent<EarthShaker> ().onColliderEnter (ll);
	}
	
	void OnCollisionExit( Collision ll )
	{
		parent.GetComponent<EarthShaker> ().onColliderExit (ll);
	}
}
