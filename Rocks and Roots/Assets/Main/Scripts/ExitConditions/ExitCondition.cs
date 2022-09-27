using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExitCondition : MonoBehaviour
{
    public abstract void OnPlayerEnter(PlayerScript player);
}
