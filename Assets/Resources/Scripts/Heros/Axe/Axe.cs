using UnityEngine;
using System.Collections;

public class Axe : MonoBehaviour {
	public GameObject _anim;
	public GameObject _coll;
	private Axe_Animation axe_animation;
	private Axe_Collider axe_collider;
	private Collision hitCollider = null;
	private int state = 0;

	void Awake()
	{
		axe_animation = _anim.GetComponent<Axe_Animation> ();
		axe_collider = _coll.GetComponent<Axe_Collider> ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine ("PlayerState");
	}
	
	void Update () {

	}

	public void onColliderEnter( Collision ll )
	{
		Debug.Log ("onColliderEnter");
		if (ll.transform.tag.CompareTo ("Enemy") == 0 ) {
			if( hitCollider == null )
			{
				hitCollider = ll;
				Debug.Log ("Find Enemy");
				axe_animation.setHit(true);
//				axe_animation.goAttack();
				state++;
			}
		}
	}

	public void onColliderExit( Collision ll )
	{
		if (ll.transform.tag.CompareTo ("Enemy") == 0 && hitCollider == ll ) {
			axe_animation.setHit(false);		
		}
	}

	public void onSkillClicked()
	{
//		anim.SetInteger ("Skill" , 3 );
		axe_animation.doSkill (3);
	}

	public void onAttackFinished()
	{
//		state++;
	}

	public IEnumerator PlayerState()
	{
		bool isOut = true;
		while (isOut) {
			switch( state )
			{
				//idle
			case 0:
				yield return new WaitForSeconds( 5 );
				state++;
				axe_animation.moveForward();
				break;
				//running
			case 1:
//				yield return new WaitForSeconds( 1 );
				yield return new WaitForEndOfFrame();
				break;
				//attack
			case 2:
				axe_animation.goAttack();
//				state++;
				yield return new WaitForEndOfFrame( );
				break;
			case 3:
				break;
				//after skill
			case 4:
				break;
			case 5:
				yield return new WaitForSeconds( 10 );
				axe_animation.goDead();
				isOut = false;
				break;
			}
		}
		StopCoroutine ("PlayerState");
		yield return null;
	}
}
