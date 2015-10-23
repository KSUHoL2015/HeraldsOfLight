using UnityEngine;
using System.Collections;

public class AllyFollow : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public Movement playerMove;
	
	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			//Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			//Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			//Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, dampTime);
			if(playerMove.horizontal > 0)
				transform.eulerAngles = new Vector3(0,180,0);
			else if(playerMove.horizontal < 0)
				transform.eulerAngles = new Vector3(0,0,0);
		}
		
	}
}
