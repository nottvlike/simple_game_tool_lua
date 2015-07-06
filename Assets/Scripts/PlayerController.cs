using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {
	public Animator Anim;
	public bool CanPlay;

	public Character LocalCharacter;
	[HideInInspector]
	public float v;
	[HideInInspector]
	public float h;
	// Use this for initialization

	void Awake()
	{
		v = -0.5f;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (CanPlay) {
//			v = Input.GetAxis ("Vertical");
//			h = Input.GetAxis ("Horizontal");
//			Anim.SetFloat ("Speed", Input.GetAxis ("Horizontal"));
//			Anim.SetBool ("IsRunning", Input.GetKeyDown (KeyCode.LeftShift));
//			Anim.SetFloat ("Direction", Input.GetAxis ("Vertical"));
//		} else {
//			Anim.SetFloat ("Speed", h);
////			Anim.SetBool ("IsRunning", Input.GetKeyDown (KeyCode.LeftShift));
			Anim.SetFloat ("Direction", v);			
//		}
	}

	public void Go()
	{
		Anim.SetFloat ("Speed", 1);
		//			Anim.SetBool ("IsRunning", Input.GetKeyDown (KeyCode.LeftShift));
		Anim.SetFloat ("Direction", v);
	}

	public void Stop()
	{
		Anim.SetFloat ("Speed", 0);
		//			Anim.SetBool ("IsRunning", Input.GetKeyDown (KeyCode.LeftShift));
		Anim.SetFloat ("Direction", 0);
	}
}
