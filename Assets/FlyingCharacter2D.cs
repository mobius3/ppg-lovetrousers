using System;
using UnityEngine;

public class FlyingCharacter2D : MonoBehaviour
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
	private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	
	private void Awake()
	{
		// Setting up references.
		m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	
	private void FixedUpdate()
	{
	}
	
	
	public void Move(float moveH, float moveV)
	{

		if (true)// may move?
		{
			// Reduce the speed if crouching by the crouchSpeed multiplier
			//move = (crouch ? move*m_CrouchSpeed : move);
			
			// The Speed animator parameter is set to the absolute value of the horizontal and vertical input.
			m_Anim.SetFloat("Speed", Mathf.Abs(moveH));
			m_Anim.SetFloat("vSpeed", Mathf.Abs(moveV));
			
			// Move the character
			m_Rigidbody2D.velocity = new Vector2(moveH*m_MaxSpeed, moveV*m_MaxSpeed);
			
			// If the input is moving the player right and the player is facing left...
			if (moveH > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (moveH < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
	}
	
	
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
