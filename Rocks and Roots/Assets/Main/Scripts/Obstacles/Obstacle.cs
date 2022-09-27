using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public int Health;
    public abstract void OnToolHit(Tool tool);
}
