using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (FlyingCharacter2D))]
public class Flying2DUserControl : MonoBehaviour
{
	private FlyingCharacter2D m_Character;
	
	private void Awake()
	{
		m_Character = GetComponent<FlyingCharacter2D>();
	}
	
	private void FixedUpdate()
	{
		// Read the inputs.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		// Pass all parameters to the character control script.
		m_Character.Move(h, v);
	}
}
