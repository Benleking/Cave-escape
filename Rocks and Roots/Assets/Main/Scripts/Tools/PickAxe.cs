using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : Tool
{
    private void Awake()
    {
        ToolIcon = Toolbox.GetInstance().GetUIManager().PickAxeIcon;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rock rock = other.GetComponent<Rock>();

        if (rock != null)
        {
            toolSound.Play();
            rock.OnToolHit(this);
        }
    }

    public override void OnUse()
    {
        animator.Play("PickAxeSwing");
    }
}
