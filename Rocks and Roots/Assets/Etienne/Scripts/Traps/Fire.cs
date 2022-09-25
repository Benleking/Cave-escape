using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Trap
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;
    public override void OnPlayerEnter(PlayerScript player)
    {
        Vector3 vector = player.transform.position - transform.position;
        vector.y = 0;
        player.Bounce(vector.normalized * distance,duration);
    }
}
