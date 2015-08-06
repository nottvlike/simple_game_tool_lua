using UnityEngine;
using System.Collections;

public class Axe_Animation : MonoBehaviour {
	public GameObject parent;
	public Animator anim;
	private bool isRunning = false;
	private int isHit = 1;
	private int state = 0;
	private float RunningSpead = 2;

	//int isHit = 1;
	// Use this for initialization
	void Start () {
	
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
		} else {
//			isHit = 1;	
			isRunning = true;
		}
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
			anim.Play ("Idle");
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

	public void goAttack()
	{
		state = 2;
		Debug.Log ("goAttack");
		anim.Play ("attack_normal");
	}

	public void goDead ()
	{
		anim.Play ("Death");
	}

	public void doSkill( int skillid)
	{
		if (skillid == 3) {
			anim.Play ("attack_skill_dazhao");			
		}
//		anim.SetInteger ("Skill" , skillid );
	}

	public void getIsAttack()
	{
	}

	public void moveForward()
	{
		state = 1;
		anim.Play ("run");
//		anim.SetBool("Run" , true );
		isRunning = true;
//		RunningSpead = 1;
//		isHit = 1;
	}

//	public void 
}
