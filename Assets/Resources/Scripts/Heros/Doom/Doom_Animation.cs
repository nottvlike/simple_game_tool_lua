using UnityEngine;
using System.Collections;

public class Doom_Animation : MonoBehaviour {
	public GameObject parent;
	private bool isRunning = false;
	private int isHit = 1;
	private int state = 0;
	private float RunningSpead = 2;
	[HideInInspector]
	public float AttackSpeed = 0;
	private float BasicBetween = 1.7f;
	private Animation _anims;
	// Use this for initialization
	void Start () {
		_anims = GetComponent<Animation> ();
		goIdle ();
		AnimationEvent attackEvent = new AnimationEvent ();
		attackEvent.time = _anims ["mdldecompiler.qc_skeleton|attack"].length * 2 / 3;
		attackEvent.functionName = "onAttackFinished";
		_anims ["mdldecompiler.qc_skeleton|attack"].clip.AddEvent ( attackEvent );
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

	public void goIdle()
	{
		state = 0;
		_anims ["mdldecompiler.qc_skeleton|idle"].wrapMode = WrapMode.Loop;
		_anims.Play ("mdldecompiler.qc_skeleton|idle");
	}

	public void goAttack()
	{
		state = 2;
		Debug.Log ("goAttack");
		_anims ["mdldecompiler.qc_skeleton|attack"].speed = _anims ["mdldecompiler.qc_skeleton|attack"].length * (1 + AttackSpeed / 100) / BasicBetween;
		_anims.Play ("mdldecompiler.qc_skeleton|attack");
//		anim.Play ("Attack_Normal");
	}

	public void onAttackFinished()
	{

	}

	public void goDead ()
	{
//		anim.Play ("Death");
		_anims.Play ("mdldecompiler.qc_skeleton|death");
	}
	
	public void doSkill( int skillid)
	{
		if (skillid == 3) {
			_anims.Play ("mdldecompiler.qc_skeleton|cast_level_death");		
		}
		//		anim.SetInteger ("Skill" , skillid );
	}
	
	public void getIsAttack()
	{
	}
	
	public void moveForward()
	{
		state = 1;
		_anims ["mdldecompiler.qc_skeleton|run"].wrapMode = WrapMode.Loop;
		_anims.Play ("mdldecompiler.qc_skeleton|run");	
//		anim.Play ("Run");
		//		anim.SetBool("Run" , true );
		isRunning = true;
		//		RunningSpead = 1;
		//		isHit = 1;
	}
}
