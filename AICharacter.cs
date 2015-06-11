using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (AIActorComponent))]
public class AICharacter : MonoBehaviour
{

	private AIManager m_aiManager;

	// AIAgentId is specified by the level editor
	public AIAgentManager.AgentId AgentId;

	private AIActor m_actor;
	public AIActor Actor
	{
		get
		{
			return m_actor;
		}
	}

	private uint m_characterId;
	public uint Id
	{
		get
		{
			return m_characterId;
		}
		
		set
		{
			m_characterId = value;
		}
	}

	void Start ()
	{
		m_aiManager = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<AIManager>();
		m_actor = this.GetComponent<AIActor>();
		m_characterId = m_aiManager.RegisterAICharacter(this);

		if(m_actor == null)
		{
			throw new UnityException("All GameObject must contain an AICharacter AND an AIActor.");
			//m_actor = (AIActor)(this.gameObject.AddComponent("AIActorAggressive"));
		}
	}

	void OnEnable()
	{

	}

	void OnDisable()
	{
	}

	void OnDestroy()
	{
		if(m_aiManager != null)
			m_aiManager.UnregisterAICharacter(m_characterId);
	}
}

