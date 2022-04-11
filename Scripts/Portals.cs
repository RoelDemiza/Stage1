using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    private Transform destination;

	public bool isCave1;
	public float distance = 0.2f;

	void Start()
	{
		if(isCave1 == false)
		{
			destination = GameObject.FindGameObjectWithTag("Cave1").GetComponent<Transform>();
		}else
		{
			destination = GameObject.FindGameObjectWithTag("Cave2").GetComponent<Transform>();
		}
}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (Vector2.Distance(transform.position, other.transform.position) > distance)
		{
			other.transform.position = new Vector2 (destination.position.x, destination.position.y);
		}
}
}
