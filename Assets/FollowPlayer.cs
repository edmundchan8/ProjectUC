using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
	[SerializeField]
	GameObject m_Player;

	float MIN_SCREEN_WIDTH = 0f;
	float MAX_SCREEN_WIDTH = 8.5f;

	Vector3 m_Offset;

	void Start()
	{
		m_Offset = transform.position - m_Player.transform.position;
	}

	void Update()
	{
		transform.position = new Vector3(Mathf.Clamp(m_Player.transform.position.x + m_Offset.x, MIN_SCREEN_WIDTH, MAX_SCREEN_WIDTH), 0, transform.position.z); 
	}
}
