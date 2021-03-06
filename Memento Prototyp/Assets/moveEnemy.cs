﻿using UnityEngine;
using System.Collections;

public class moveEnemy : MonoBehaviour {

	private float m_MaxSpeed = 4f;
	private float m_JumpForce = 400f;
	private Transform player;
	private Rigidbody2D m_Rigidbody2D;
	private float move;
	// Rotation
	private Quaternion rotationEnemy;
	private bool left = true;
	private bool previouseLeft = true;

	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void Move()
	{
		// Check if the Caracter is Left or Right
		move = Mathf.Clamp(player.position.x - transform.position.x, -1, 1);
		// Rotate the Character
		rotationEnemy = transform.rotation;
		if(move > 0)
		{
			left = false;
		}
		else
		{
			left = true;
		}
		if(left != previouseLeft)
		{
			transform.Rotate(new Vector3(0f,180f,0f));
			previouseLeft = left;
		}
		// Move the character
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);
	}
}
