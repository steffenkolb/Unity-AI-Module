using UnityEngine;
using System.Collections;

public abstract class AIActor : MonoBehaviour
{
	public abstract void Execute(AIAction action);
}

