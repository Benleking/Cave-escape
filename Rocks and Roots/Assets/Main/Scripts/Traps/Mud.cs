using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : Trap
{
    [SerializeField] private float speedMultiplier;
    private bool isTriggered;

    private void Update()
    {
        if (isTriggered)
        {
            transform.localScale *= Time.deltaTime;
        }
    }
    public override void OnPlayerEnter(PlayerScript player)
    {
        StartCoroutine(Slowdown(player));
        GetComponent<Collider>().enabled = false;
        isTriggered = true;
    }

    private IEnumerator Slowdown(PlayerScript player)
    {
        player.SetSpeed(player.GetSpeed() * speedMultiplier);
        yield return new WaitForSeconds(2f);
        player.SetSpeed(player.GetSpeed() / speedMultiplier);
    }
}
