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
	public Health health;


	/*
	 * Observations:
	 * 0: This Agent Position
	 * 1: Enemy Position, 0 if it cant see enemy
	 * 2: closest wall hit dist
	 * 3: closest wall hit pos
	 * 4: wall count
	 * 5: this health
	 */

	public override void CollectObservations(VectorSensor sensor)
	{
		base.CollectObservations(sensor);

		List<TargetHitData> hitData = perception.PerceiveTargets(transform.forward);

		// 0
		sensor.AddObservation(transform.localPosition);

		
		Transform enemyTransform = null;
		Vector3 closestWallHit = Vector3.zero;
		float closestWallHitDist = float.PositiveInfinity;
		int wallCount = 0;
		foreach (var target in hitData)
		{
			if(target.type == TargetType.Enemy)
			{
				enemyTransform = target.transform;
			}
			else if (target.type == TargetType.Wall)
			{
				wallCount++;
				float dist = Vector3.Distance(target.transform.localPosition, transform.localPosition);
				if (dist < closestWallHitDist)
				{
					closestWallHitDist = dist;
					closestWallHit = target.transform.localPosition;
				}
			}
		}

		if (enemyTransform != null)
		{
			//1
			sensor.AddObservation(enemyTransform.localPosition);
		}
		else
		{
			//1
			sensor.AddObservation(Vector3.zero);
		}

		//2
		sensor.AddObservation(closestWallHitDist);
		//3
		sensor.AddObservation(closestWallHit);
		//4
		sensor.AddObservation(wallCount);




		//5
		sensor.AddObservation(health.currentHealth);

		if(health.currentHealth <= 0)
		{
			AddReward(-10);
			EndEpisode();
		}
	}

	public override void OnActionReceived(ActionBuffers actions)
	{
		base.OnActionReceived(actions);

		UnityEngine.Vector3 direction = UnityEngine.Vector3.zero;
		float turnAngle = 0;

		direction.x = actions.ContinuousActions[0];
		direction.z = actions.ContinuousActions[1];
		turnAngle = actions.ContinuousActions[2];
		weapon.throwAngle += actions.ContinuousActions[3];
		weapon.throwPower += actions.ContinuousActions[4];

		characterMovement.Move(direction);
		characterMovement.Turn(turnAngle);
		Debug.Log(actions.DiscreteActions[0].ToString());
		if (actions.DiscreteActions[0] == 1)
		{
			AddReward(0.1f);
			weapon.FireWeapon();
		}

	}

	public void HitSuccess()
	{
		AddReward(1);
	}

	public void HitMiss()
	{
		AddReward(-0.2f);
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

		//continuousActions[0] = Mathf.CeilToInt(Input.GetAxis("Horizontal"));
		//continuousActions[1] = Mathf.CeilToInt(Input.GetAxis("Vertical"));
		//continuousActions[2] = Mathf.CeilToInt(Input.GetAxis("Yaw"));		
		continuousActions[0] = Input.GetAxis("Horizontal");
		continuousActions[1] = Input.GetAxis("Vertical");
		continuousActions[2] = Input.GetAxis("Yaw");
		continuousActions[3] = Input.GetAxis("ThrowAngle");
		continuousActions[4] = Input.GetAxis("ThrowPower");

		var discreteActions = actionsOut.DiscreteActions;
		Debug.Log((Input.GetButton("Jump")) ? 1 : 0);
		discreteActions[0] = (Input.GetButton("Jump")) ? 1 : 0;
	}
}