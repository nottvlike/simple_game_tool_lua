using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Axe_Animation : MonoBehaviour {
	public GameObject parent;
//	public Animator anim;
	private bool isRunning = false;
	private int isHit = 1;
	private int state = 0;
	private float RunningSpead = 2;
//	[HideInInspector]
	public float AttackSpeed = 0;
	private float BasicBetween = 1.7f;
	//int isHit = 1;
	// Use this for initialization
	void Start () {
		goIdle ();
		AnimationEvent attackEvent = new AnimationEvent ();
		attackEvent.time = animation ["mdldecompiler.qc_skeleton|attack_main"].length * 2 / 3;
		attackEvent.functionName = "onAttackFinished";
		animation ["mdldecompiler.qc_skeleton|attack_main"].clip.AddEvent ( attackEvent );
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			Vector3 vec = new Vector3( parent.transform.position.x , parent.transform.position.y , parent.transform.position.z + -2 * isHit * Time.deltaTime );
			parent.transform.position = vec;
		}
	}

	public void setHit( bool hit )
	{
		if (hit) {
//			isHit = 0;
			isRunning = false;
			state = 0;
		} else {
//			isHit = 1;	
			isRunning = true;
		}
		doByState ();
	}

	public void onSkillFinished()
	{
//		anim.SetInteger ("Skill" , 0 );
		doByState ();
	}

	void playAnim( string name )
	{
		animation.Play (name);	
	}

	void doByState()
	{
		switch (state) {
		case 0:
//			anim.Play ("Idle");
//			playAnim("mdldecompiler.qc_skeleton|idle");
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

	public void goIdle()
	{
		state = 0;
//		anim.Play ("Idle");
		animation ["mdldecompiler.qc_skeleton|idle"].wrapMode = WrapMode.Loop;
		playAnim("mdldecompiler.qc_skeleton|idle");
//		anim.animation["Idle"];
//		transform.animation["Idle"];
	}

	public void goAttack()
	{
//		transform.animation ["Axe_Attack_Normal"].speed = 0.2f;
//		AnimationClip mm = getMotionByName ("Axe_Attack_Normal") as AnimationClip;
//		mm.frameRate = 3;
//		Animation anim = new Animation ();
//		anim.clip
		state = 2;
		Debug.Log ("goAttack");
//		anim.Play ("attack_normal");
		animation ["mdldecompiler.qc_skeleton|attack_main"].speed = animation ["mdldecompiler.qc_skeleton|attack_main"].length * (1 + AttackSpeed / 100) / BasicBetween;
//		animation ["mdldecompiler.qc_skeleton|attack_main"].clip.AddEvent( new AnimationEvent())
		playAnim("mdldecompiler.qc_skeleton|attack_main");
//		Debug.Log ( anim.GetClip("attack_normal").name);
	}

	public void onAttackFinished()
	{
//		goIdle ();
		Debug.Log ("Axe : onAttackFinished");
//		parent.GetComponent<Axe> ().onAttackFinished ();
//		yield return new WaitForSeconds (1);
	}
	public void goDead ()
	{
//		anim.Play ("Death");
		playAnim("mdldecompiler.qc_skeleton|death");
	}

	public void doSkill( int skillid)
	{
		if (skillid == 3) {
//			anim.Play ("attack_skill_dazhao");
			playAnim("mdldecompiler.qc_skeleton|culling_blade");
		}
//		anim.SetInteger ("Skill" , skillid );
	}

	public void getIsAttack()
	{
	}

	public void moveForward()
	{
		state = 1;
//		anim.Play ("run");
		animation ["mdldecompiler.qc_skeleton|run"].wrapMode = WrapMode.Loop;
//		animation ["mdldecompiler.qc_skeleton|run"].clip.a
		playAnim ("mdldecompiler.qc_skeleton|run");
//		anim.SetBool("Run" , true );
		isRunning = true;
//		RunningSpead = 1;
//		isHit = 1;
	}
//	public void 
}
