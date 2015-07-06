using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	public PlayerController Controller;
	public bool DoneHome;
	public Vector3 SourceVector = Vector3.zero;
	public Vector3 MoveVector = Vector3.zero;
	public bool GeneratedVector;
	public int Count;
	// Use this for initialization

	void Awake()
	{
		Count = 2;
		SourceVector = transform.position;
	}

	void Start () {
		StartCoroutine ("goBackFunc");
	}
	
	// Update is called once per frame
	void Update () {
//		if (Controller.CanPlay )  {
//		Debug.Log (Vector3.Distance ( transform.position , MoveVector ));
//			if( Vector3.Distance ( transform.position , MoveVector ) <= 0.3f )
//			{
//				Controller.Stop ();
//				transform.LookAt( new Vector3( 0 , 0 , 6) );
//			}
////			Debug.Log ( "Count is " , Count);
//			if( Count == 0 )
//			{
//				float width = 3.0f;
//				Debug.Log ( transform.position.z );
//				if( Mathf.Round( transform.position.z) == width )
//				{
//					Count++;
//				}
//				else
//				{
//					transform.LookAt( new Vector3( transform.position.x , 0 , width ));
//					Controller.v = 1;
//				}
//			}
//			if( Count == 1 )
//			{
//
//				float width = 0.0f;
////				Debug.Log ( transform.position.z );
//				if( Mathf.Round( transform.position.z) == width )
//				{
//					transform.LookAt( new Vector3( transform.position.x , 0 , width ));
//					Controller.Stop ();
//					transform.LookAt( new Vector3( transform.position.x , 0 , 3 ));
//					Count++;
//				}
//				else
//				{
//					transform.LookAt( new Vector3( transform.position.x , 0 , width ));
//					Controller.v = 2;
//				}
//			}
//			if( Vector3.Distance( transform.position , Controller.LocalCharacter.HomeSpawn.position ) > 1 )
//			{
//				transform.LookAt( Controller.LocalCharacter.HomeSpawn);
//				Controller.v = 1;
//			}
//			else 
//			{
//				DoneHome = true;
////				GeneratedVector = false;
////				MoveVector = Vector3.zero;
//				Controller.v = 0;
//			}
//
//			if( DoneHome )
//			{
//				transform.LookAt( MoveVector );
//				Controller.v = 2;
//
//				if( Vector3.Distance( transform.position , MoveVector ) < 0.2f )
//				{
//					GeneratedVector = false;
//				}
//
//				if( !GeneratedVector )
//				{
////					float x = Random.Range( 0 , 10 );
////					float z = Random.Range( 0 , 10 );
////					MoveVector = new Vector3( x , 0 , z );
//					GeneratedVector = true;
//					Controller.Stop ();
//				}
//			}
//		} 
	}

	public void Clear()
	{
		Count = 0;
	}

	public void StartAI()
	{
//		StopCoroutine ("goBackFunc");
//		Count = 0;
//		StartCoroutine ("goBackFunc");
	}

	public void goHead()
	{
//		float width = 3.0f;
//		MoveVector = new Vector3 ( 0 , 0 , width );
//		transform.LookAt (MoveVector);
//		Controller.v = 0;
//		Controller.Go ();
		Count = 0;
//		if( Mathf.Floor ( transform.position.z ) != width )
//		{
//			return;
//		}
		//		StopCoroutine ("goBackFunc");
//		Count = 0;
//		StartCoroutine ("goBackFunc");
	}

	public void goBack()
	{
//		float width = 0.0f;
//		MoveVector = SourceVector;
//		transform.LookAt (MoveVector);
//		Controller.v = 0;

		Count = 1;
//		StopCoroutine ("goBackFunc");
//		Count = 1;
//		StartCoroutine ("goBackFunc");
	}
	public IEnumerator goBackFunc()
	{
		while (true) {
			if( Count == 0 )
			{
				float width = 3.0f;
				MoveVector = new Vector3( 0 , 0 , width );

				transform.LookAt( MoveVector );
				Controller.v = 0;
				Controller.Go ();
				while( (Vector3.Distance( transform.position , MoveVector ) > 0.5f) && Count == 0 )
				{
					yield return new WaitForEndOfFrame();
				}
//				transform.LookAt( new Vector3( SourceVector.x , 0 , width ));
				Controller.Stop ();
//				Count = 2;
			}
			if( Count == 1 )
			{
//				float width = 0.0f;
				MoveVector = SourceVector;
				transform.LookAt( MoveVector );
				Controller.v = 0;
				Controller.Go ();
				while( (Vector3.Distance( transform.position , MoveVector ) > 0.5f) && Count == 1 )
				{
					yield return new WaitForEndOfFrame();
				}
				transform.LookAt( new Vector3( SourceVector.x , 0 , 3 ));
				Controller.Stop ();
//				Count = 2;
			}
//			Count++;
			Count = 2;
			yield return new WaitForEndOfFrame();
		}
//		StopCoroutine ("goBackFunc");
		yield return null;
	}
}
