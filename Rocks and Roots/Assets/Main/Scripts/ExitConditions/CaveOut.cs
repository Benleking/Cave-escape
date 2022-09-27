using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveOut : ExitCondition
{
    public override void OnPlayerEnter(PlayerScript player)
    {
        player.Victorious();
    }
}
