using UnityEngine;
using System.Collections;

public class Axe_Collider : MonoBehaviour {
	public GameObject parent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter( Collision ll )
	{
		parent.GetComponent<Axe> ().onColliderEnter (ll);
	}
	
	void OnCollisionExit( Collision ll )
	{
		parent.GetComponent<Axe> ().onColliderExit (ll);
	}

}
