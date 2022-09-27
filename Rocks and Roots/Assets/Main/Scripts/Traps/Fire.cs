using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Trap
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;
    public override void OnPlayerEnter(PlayerScript player)
    {
        StartCoroutine(BounceEffect(player));
    }

    private IEnumerator BounceEffect(PlayerScript player)
    {
        Vector3 vector = player.transform.position - transform.position;
        vector.y = 0;
        player.SetCanMove(false);
        float timer = 0f;
        while (timer <= duration)
        {
            player.GetCharacterController().Move(vector.normalized * distance * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        player.SetCanMove(true);
    }
}
