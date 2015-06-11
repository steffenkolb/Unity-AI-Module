using UnityEngine;
using System.Collections;

public class AIAgentManager
{
	private static AIAgentManager instance;

	public enum AgentId
	{
		DefensivePatrol,
		AggressivePatrol,
		ParanoidPatrol
	};

	public enum ActionId
	{
		Shoot,
		Patrol,
		Chase,
		Flee,
		Die
	};

	private AIAgentManager(){}

	public static AIAgentManager Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new AIAgentManager();
			}
			return instance;
		}
	}

	public AIBehavior[] GetBehaviorsForCharacter(AICharacter character)
	{
		AIBehavior[] behaviors = new AIBehavior[1];
		switch(character.AgentId)
		{
		case AgentId.AggressivePatrol:
			behaviors[0] = new AIBehaviorAggressive(character);
			break;

		case AgentId.DefensivePatrol:
			behaviors[0] = new AIBehaviorDefensive(character);
			break;

		case AgentId.ParanoidPatrol:
			behaviors[0] = new AIBehaviorParanoid(character);
			break;

		default:
			throw new UnityException("AgentId not found.");
		}

		return behaviors;
	}
}
