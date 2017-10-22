using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
	float m_Timer = 0.0f;

	public void SetTimer(float time)
	{
		m_Timer = time;
	}

	public void Update(float time)
	{
		if (m_Timer > 0)
		{
			m_Timer -= time;
		}
		else
			return;
	}

	public float GetTime()
	{
		return m_Timer;
	}

	public bool HasCompleted()
	{
		return m_Timer <= 0f;
	}
}
