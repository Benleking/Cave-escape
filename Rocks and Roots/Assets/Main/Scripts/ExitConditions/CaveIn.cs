using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveIn : ExitCondition
{
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public override void OnPlayerEnter(PlayerScript player)
    {
        player.Defeated();
    }
}
