using UnityEngine;
using System.Collections.Generic;

public class AIManager : MonoBehaviour
{
	private Dictionary<uint, AICharacter> m_aiCharacters;					// Reference to all AICharacters
	private Dictionary<uint, AIAgent> m_aiAgents;							// Reference to all AIAgents of the characters
	private AIScheduler m_scheduler = AIScheduler.Instance;					// Singleton Scheduler
	private AIExtractor m_extractor = AIExtractor.Instance;					// Singleton Extractor
	private AIAgentManager m_aiAgentManager = AIAgentManager.Instance;		// Singleton AgentManager

	private uint m_currentCharacterId;
	private bool m_bPaused = true;

	public AIManager()
	{
		m_currentCharacterId = 0;
		m_aiCharacters = new Dictionary<uint, AICharacter>();
		m_aiAgents = new Dictionary<uint, AIAgent>();
	}

	// Use this for initialization
	void Start ()
	{
		foreach(AIAgent agent in m_aiAgents.Values)
		{
			agent.Init();
		}

		m_bPaused = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if(!m_bPaused)
		{
			if(m_scheduler.Schedule(m_aiAgents, m_aiCharacters) != 0)
			{
				Debug.LogError("AIScheduler run into an Error.");
			}
		}
	}

	public AIAgent GetAgentWithId(uint id)
	{
		if(m_aiAgents.ContainsKey(id))
			return m_aiAgents[id];
		else
			return null;
	}

	/**
	 * Register a character with its ID
	 */
	public uint RegisterAICharacter(AICharacter character)
	{
		if(character == null)
		{
			throw new System.ArgumentException("Parameter character cannot be null", "character");
		}

		try
		{
			// create agent
			AIAgent agent = new AIAgent(m_currentCharacterId, character.AgentId, m_aiAgentManager.GetBehaviorsForCharacter(character));

			// register character with character and agent
			m_aiCharacters.Add(m_currentCharacterId, character);
			m_aiAgents.Add(m_currentCharacterId, agent);

			Debug.Log("Character with id " + m_currentCharacterId + " has been registered");
			return m_currentCharacterId++;
		}
		catch (System.ArgumentException)
		{
			throw new System.ArgumentException("An element with Key = "+character.Id+" already exists.", "character");
		}
	}

	public void UnregisterAICharacter(uint id)
	{
		if(m_aiCharacters.ContainsKey(id))
		{
			m_aiCharacters.Remove(id);
			m_aiAgents.Remove(id);
			Debug.Log("Character with id " + id + " has been unregistered");			
			m_currentCharacterId--;
		}
	}
}

