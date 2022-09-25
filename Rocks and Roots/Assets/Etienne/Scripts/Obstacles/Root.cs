using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : Obstacle
{
    public override void OnToolHit(Tool tool)
    {
        Health -= tool.Damage;
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
