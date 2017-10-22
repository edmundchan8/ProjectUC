using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	Vector2 m_MousePos;
	Vector2 m_StartPos;
	Vector2 m_EndPos;

	Timer m_Timer = new Timer();

	float DURATION = 0f;

	void Start()
	{
		m_StartPos = SetToCurrentLocalPosition();
		m_EndPos = m_StartPos;
	}

	void Update () 
	{
		m_Timer.Update(Time.deltaTime);
		if (Input.GetMouseButtonUp(0))
		{
			m_StartPos = SetToCurrentLocalPosition();
			Vector2 localPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			m_MousePos = new Vector2(localPos.x, localPos.y);
			m_EndPos.x = m_MousePos.x;
			DURATION = DistBetweenStartEndPos()/3;
			m_Timer.SetTimer(DURATION);
			print(m_MousePos.x);
		}

		if (!m_Timer.HasCompleted())
		{
			transform.localPosition = Vector2.Lerp(m_StartPos, m_EndPos, (DURATION - m_Timer.GetTime()) / DURATION);
			Vector2 currentPos = SetToCurrentLocalPosition();
			currentPos.y = -3f;
			transform.localPosition = currentPos;
		}
		else
			return;
	}

	Vector2 SetToCurrentLocalPosition()
	{
		return transform.localPosition;
	}

	float DistBetweenStartEndPos()
	{
		return Mathf.Abs(m_StartPos.x - m_EndPos.x);
	}
}
