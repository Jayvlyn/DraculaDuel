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
	public AgentWeapon weapon2;
	public Transform spawnTransform;
	public Health health;


	private Vector3 lastPos;

	/*
	 * Observations:
	 * 0: This Agent Position
	 * 1: Enemy Position, 0 if it cant see enemy
	 * 2: closest wall hit dist
	 * 3: closest wall hit pos
	 * 4: wall count
	 * 5: this health
	 * 6: spawn location
	 * 7: distance from spawn
	 * 8: hit percent
	 */

	public override void CollectObservations(VectorSensor sensor)
	{
		base.CollectObservations(sensor);

		List<TargetHitData> hitData = perception.PerceiveTargets(transform.forward);

		// 0
		//sensor.AddObservation(transform.localPosition);

		float distance = Vector3.Distance(lastPos, transform.position);
		if (distance > 10) distance = 10;
		AddReward(Mathf.Lerp(0, 10, distance / 10));
		lastPos = transform.position;

		
		Transform enemyTransform = null;
		Vector3 closestWallHit = Vector3.zero;
		float closestWallHitDist = 10000;
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

			AddReward(10);
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
		//6
		sensor.AddObservation(spawnTransform.localPosition);

		float distFromSpawn = Vector3.Distance(spawnTransform.localPosition, transform.localPosition);
		if(distFromSpawn > 1f)
		{
			//AddReward(distFromSpawn / 10);
		}
		//7
		sensor.AddObservation(distFromSpawn);

		//8
		if (latestData != null) sensor.AddObservation((float)latestData.hits / (latestData.hits + latestData.misses));
		else sensor.AddObservation(0);

		if(health.currentHealth <= 0)
		{
			Debug.Log("End Episoe");
			AddReward(-1000);

			health.SetHealth(100);

            // move back to spawn transform
            transform.position = spawnTransform.position;

            // set rotation to be correct
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 90, 0);

            //EndEpisode();
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
		weapon.throwAngle = Mathf.Clamp(weapon.throwAngle, -30, 90);
		weapon2.throwAngle += actions.ContinuousActions[3];
		weapon2.throwAngle = Mathf.Clamp(weapon2.throwAngle, -30, 90);
		weapon.throwPower += actions.ContinuousActions[4];
		weapon.throwPower = Mathf.Clamp(weapon.throwPower, 250, 1000);
		weapon2.throwPower += actions.ContinuousActions[4];
		weapon2.throwPower = Mathf.Clamp(weapon2.throwPower, 250, 1000);

		Debug.Log("Throw Angle: " + weapon.throwAngle);
		Debug.Log("Throw Power: " + weapon.throwPower);

		characterMovement.Move(direction);
		characterMovement.Turn(turnAngle);
		//Debug.Log(actions.DiscreteActions[0].ToString());
		if (actions.DiscreteActions[0] == 1)
		{
			//AddReward(0.1f);
			Debug.Log("firing");
			weapon.FireWeapon();
        }
        if (actions.DiscreteActions[1] == 1)
        {
            //AddReward(0.1f);
            //weapon2.FireWeapon();
        }

    }

	AgentHitRecieveData latestData;
	public void HitSuccess(AgentHitRecieveData data, bool hitSuccess)
	{
		latestData = data;

		if(hitSuccess)
		{
			if(data.healthPercent <= 0)
			{
				AddReward(1000);
				health.SetHealth(100);
				EndEpisode();
			}
		}

		float reward = data.hits - (data.misses - 1) * 1.5f;
		Debug.Log(reward);
        //AddReward(reward);
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
		//Debug.Log((Input.GetButton("Jump")) ? 1 : 0);
		discreteActions[0] = (Input.GetButton("Fire1")) ? 1 : 0;
		discreteActions[1] = (Input.GetButton("Fire2")) ? 1 : 0;
	}
}