// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;


public class AIAgent : AIBehavior
{

	// Public Getter and Setter
	private uint m_characterId;
	public uint CharacterId
	{
		get
		{
			return m_characterId;
		}
	}
	
	private AIAgentManager.AgentId m_agentId;
	public AIAgentManager.AgentId Id
	{
		get
		{
			return m_agentId;
		}
	}

	private bool m_bActive;
	public bool Active
	{
		get
		{
			return m_bActive;
		}

		set
		{
			m_bActive = value;
		}
	}

	private AIBehavior[] m_behaviors;

	public AIAgent (uint characterId, AIAgentManager.AgentId agentId, AIBehavior[] behaviors)
	{
		m_characterId = characterId;
		m_agentId = agentId;
		m_behaviors = behaviors;
	}

	public override void Init()
	{
		m_bActive = true;
		foreach(AIBehavior behavior in m_behaviors)
			behavior.Init();
	}

	public override AIAction MakeDecision()
	{
		AIAction action = null;
		// implement harcoded "AI"
		foreach(AIBehavior behavior in m_behaviors)
		{
			action = behavior.MakeDecision();
		}

		return action;
	}
}

