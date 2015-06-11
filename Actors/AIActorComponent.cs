using UnityEngine;
using System.Collections;

public class AIActorComponent : MonoBehaviour
{
	private AIActor m_actor;
	public AIActor Actor
	{
		set
		{
			m_actor = value;
		}
		get
		{
			return m_actor;
		}
	}

	public void Execute(AIAction action)
	{
		if(m_actor != null)
			m_actor.Execute(action);
	}
}

