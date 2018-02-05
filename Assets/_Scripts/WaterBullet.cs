using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WaterBullet : MonoBehaviour 
{
	private float m_bulletSpeed = 10f;

	private Rigidbody m_Rigidbody;

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		Invoke("DestroySelf", 1.5f);
	}
	
	private void FixedUpdate()
	{
		m_Rigidbody.MovePosition(m_Rigidbody.position + transform.forward
			* m_bulletSpeed * Time.deltaTime);
	}

	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}

