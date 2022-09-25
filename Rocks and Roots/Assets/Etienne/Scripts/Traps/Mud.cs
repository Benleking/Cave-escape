using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : Trap
{
    [SerializeField] private float speedMultiplier;
    public override void OnPlayerEnter(PlayerScript player)
    {
        player.Slowdown(speedMultiplier);
        Destroy(gameObject);
    }
}
