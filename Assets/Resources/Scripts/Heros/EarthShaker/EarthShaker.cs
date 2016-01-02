using UnityEngine;
using System.Collections;

public class EarthShaker : MonoBehaviour {
	public GameObject _anim;
	public GameObject _coll;
	private EarthShaker_Animation hero_animation;
	private EarthShaker_Collider hero_collider;
	private Collision hitCollider = null;
	private int state = 0;
	
	void Awake()
	{
		hero_animation = _anim.GetComponent<EarthShaker_Animation> ();
		hero_collider = _coll.GetComponent<EarthShaker_Collider> ();
	}
	// Use this for initialization
	void Start () {
		StartCoroutine ("PlayerState");
	}
	
	// Update is called once per frame
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
				hero_animation.setHit(true);
//				hero_animation.goAttack();
				state++;
			}
		}
	}
	
	public void onColliderExit( Collision ll )
	{
		if (ll.transform.tag.CompareTo ("Enemy") == 0 && hitCollider == ll ) {
			hero_animation.setHit(false);		
		}
	}
	
	public void onSkillClicked()
	{
		//		anim.SetInteger ("Skill" , 3 );
		hero_animation.doSkill (3);
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
				hero_animation.moveForward();
				break;
				//running
			case 1:
				//				yield return new WaitForSeconds( 1 );
				yield return new WaitForEndOfFrame();
				break;
				//attack
			case 2:
				hero_animation.goAttack();
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
				hero_animation.goDead();
				isOut = false;
				break;
			}
		}
		StopCoroutine ("PlayerState");
		yield return null;
	}
}
