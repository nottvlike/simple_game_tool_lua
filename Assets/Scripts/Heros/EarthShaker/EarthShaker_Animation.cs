﻿using UnityEngine;
using System.Collections;

public class EarthShaker_Animation : MonoBehaviour {
	public GameObject parent;
	private bool isRunning = false;
	private int isHit = 1;
	private int state = 0;
	private float RunningSpead = 2;
	private float AttackSpeed = 0;
	private float BasicBetween = 1.7f;

	// Use this for initialization
	void Start () {
		goIdle ();
		AnimationEvent attackEvent = new AnimationEvent ();
		attackEvent.time = animation ["mdldecompiler.qc_skeleton|attack1"].length * 2 / 3;
		attackEvent.functionName = "onAttackFinished";
		animation ["mdldecompiler.qc_skeleton|attack1"].clip.AddEvent ( attackEvent );
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			Vector3 vec = new Vector3( parent.transform.position.x , parent.transform.position.y , parent.transform.position.z + 2 * isHit * Time.deltaTime );
			parent.transform.position = vec;
		}
	}
	
	public void setHit( bool hit )
	{
		if (hit) {
			//			isHit = 0;
			state = 0;
			isRunning = false;
		} else {
			//			isHit = 1;	
			isRunning = true;
		}
		doByState();
	}
	
	public void onSkillFinished()
	{
		//		anim.SetInteger ("Skill" , 0 );
		doByState ();
	}
	
	void doByState()
	{
		switch (state) {
		case 0:
			goIdle();
			break;
		case 1:
			moveForward();
			break;
		case 2:
			goAttack ();
			break;
		case 3:
			break;
		}
	}

	public void goIdle ()
	{
		animation ["mdldecompiler.qc_skeleton|idle"].wrapMode = WrapMode.Loop;
//		animation ["mdldecompiler.qc_skeleton|idle"].
		animation.Play ("mdldecompiler.qc_skeleton|idle");
	}

	public void goAttack()
	{
		state = 2;
		Debug.Log ("goAttack");
		animation ["mdldecompiler.qc_skeleton|attack1"].speed = animation ["mdldecompiler.qc_skeleton|attack1"].length * (1 + AttackSpeed / 100) / BasicBetween;
		animation.Play ("mdldecompiler.qc_skeleton|attack1");
//		anim.Play ("Attack_Normal");
	}

	public void onAttackFinished()
	{

	}

	public void goDead ()
	{
		animation.Play("mdldecompiler.qc_skeleton|death");
	}
	
	public void doSkill( int skillid)
	{
		if (skillid == 3) {
			animation.Play("mdldecompiler.qc_skeleton|enchant_totem");		
		}
		//		anim.SetInteger ("Skill" , skillid );
	}
	
	public void moveForward()
	{
		state = 1;
		animation ["mdldecompiler.qc_skeleton|run"].wrapMode = WrapMode.Loop;
		animation.Play("mdldecompiler.qc_skeleton|run");	
//		anim.Play ("Run");
		//		anim.SetBool("Run" , true );
		isRunning = true;
		//		RunningSpead = 1;
		//		isHit = 1;
	}
}
