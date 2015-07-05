using UnityEngine;
using System.Collections;

public class SequenceManager : MonoBehaviour {
	public CharacterTransition CharSwitch;
	public static SequenceManager Instance;

	void Awake()
	{
		Instance = this;
	}

	public IEnumerator DoCharSwitch( Character c)
	{
		int i = 0;
		while (i < 3) {
			if( i == 0 )
			{
				CharSwitch.Follower.height = CharSwitch.Height;
				while(Mathf.Round (CharSwitch.Follower.transform.position.y) != CharSwitch.Height )
				{
					yield return new WaitForEndOfFrame();
				}
			}
			if( i == 1 )
			{
				Vector3 pos = new Vector3(c.Instance.transform.position.x , CharSwitch.Height ,c.Instance.transform.position.z);
				CharSwitch.Follower.transform.position = Vector3.Lerp( CharSwitch.Follower.transform.position , pos , CharSwitch.Speed );
				if( CharSwitch.Follower.transform.position != pos )
				{
					yield return new WaitForEndOfFrame();
				}
			}
			if( i == 2 )
			{
				SmoothFollow flow = Camera.main.GetComponent ("SmoothFollow") as SmoothFollow;
				flow.target = c.Instance.transform;
				GameManager.Instance.CanShowSelected = true;
				CharSwitch.Follower.height = 2;
				if((int)CharSwitch.Follower.transform.position.y != 2 )
				{
					yield return new WaitForEndOfFrame();
				}
			}
			i++;
		}
		StopCoroutine ("DoCharSwitch");
		yield return null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class CharacterTransition
{
	public float Height;
	public float Speed;
	public SmoothFollow Follower;
}