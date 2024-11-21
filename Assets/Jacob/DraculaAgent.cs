using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using System.Collections.Generic;

public class DraculaAgent : Agent
{
	public CharacterMovement characterMovement;
	public AIPerception perception;
	public AgentWeapon weapon;
	public Transform spawnTransform;

	public override void CollectObservations(VectorSensor sensor)
	{
		base.CollectObservations(sensor);

		List<TargetHitData> hitData = perception.PerceiveTargets(transform.forward);

		// add other important observations that the ai needs, like a spottedTarget position
		sensor.AddObservation(transform.localPosition);


		Transform enemyTransform = null;
		foreach (var target in hitData)
		{
			if(target.type == TargetType.Enemy)
			{
				enemyTransform = target.transform;
			}
		}

		sensor.AddObservation(enemyTransform.position);
		
	}

	public override void OnActionReceived(ActionBuffers actions)
	{
		base.OnActionReceived(actions);

		UnityEngine.Vector3 direction = UnityEngine.Vector3.zero;
		float turnAngle = 0;

		direction.x = actions.ContinuousActions[0];
		direction.z = actions.ContinuousActions[1];
		turnAngle = actions.ContinuousActions[2];

		characterMovement.Move(direction);
		characterMovement.Turn(turnAngle);
		if (actions.DiscreteActions[0] == 1) weapon.FireWeapon();

		// here you can:
		// set reward
		// end episode
	}

	public void OnSucessfulHit()
	{
		SetReward(1);
	}

	public override void OnEpisodeBegin()
	{
		base.OnEpisodeBegin();

		// set up agent for start : 

		// move back to spawn transform
		transform.position = spawnTransform.position;

		// set rotation to be correct
		transform.localRotation = UnityEngine.Quaternion.Euler(0, 90, 0);
	}

	public override void Heuristic(in ActionBuffers actionsOut)
	{
		base.Heuristic(actionsOut);

		var continuousActions = actionsOut.ContinuousActions;
		continuousActions[0] = Input.GetAxis("Horizontal");
		continuousActions[1] = Input.GetAxis("Vertical");
		continuousActions[2] = Input.GetAxis("Yaw");

		var discreteActions = actionsOut.DiscreteActions;

		int shoot = 0;
		if (Input.GetButton("Jump")) shoot = 1;
		discreteActions[0] = shoot;
	}
}