using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PerceptionHitTarget : MonoBehaviour
{
    [SerializeField] private TargetType targetType;
    public TargetType TargetType => targetType;
}

public enum TargetType
{
    Player,
    Enemy,
    Team1,
    Team2,
    Projectile,
    Wall
}