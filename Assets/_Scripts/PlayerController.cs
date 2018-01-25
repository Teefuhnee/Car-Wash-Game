using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float m_carMove;
	public float m_playerSpeed = 11.0f;
	public float m_playerMove;
	public GameObject m_WaterPrefab;
	public Boundary m_boundary;

	private Rigidbody m_rigidbody;

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
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			Instantiate (m_WaterPrefab, transform.position, transform.rotation);
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

