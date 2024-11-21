using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class DraculaAgent : Agent
{
	public CharacterMovement characterMovement;
	public AgentWeapon weapon;

	public override void CollectObservations(VectorSensor sensor)
	{
		base.CollectObservations(sensor);

		// add other important observations that the ai needs, like a spottedTarget position
		sensor.AddObservation(transform.localPosition);
		
	}

	public override void OnActionReceived(ActionBuffers actions)
	{
		base.OnActionReceived(actions);

		Vector3 direction = Vector3.zero;
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

	public override void OnEpisodeBegin()
	{
		base.OnEpisodeBegin();

		// set up agent for start

		// move back to spawn transform

		// set rotation to be correct
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