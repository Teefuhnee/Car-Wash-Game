using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float m_playerSpeed = 11.0f;
	private float m_playerMove;
	public GameObject m_waterPrefab;
	public Boundary m_boundary;

	private Rigidbody m_rigidbody;

	private float nextBullet;
	public float bulletRate;

	private void Awake ()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		MovePlayer ();
	}
		
	private void Update()
	{
		Shoot();
	}

	private void Shoot()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextBullet) 
		{
			nextBullet = Time.time + bulletRate;
			Instantiate (m_waterPrefab, transform.position, transform.rotation);
		}
	}
	private void MovePlayer()
	{
		m_playerMove = Input.GetAxis("Horizontal") * Time.deltaTime * m_playerSpeed;
		transform.Translate(m_playerMove, 0, 0);

		m_rigidbody.position = new Vector3 
			(
				Mathf.Clamp (m_rigidbody.position.x, m_boundary.xMin, m_boundary.xMax), 
				0.0f, 
				0.0f
			);
	}
}

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}

