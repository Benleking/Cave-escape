using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{
    private void Awake()
    {
        ToolIcon = Toolbox.GetInstance().GetUIManager().AxeIcon;
    }

    private void OnTriggerEnter(Collider other)
    {
        Root root = other.GetComponent<Root>();

        if (root != null)
        {
            root.OnToolHit(this);
        }
    }


    public override void OnUse()
    {
        animator.Play("AxeSwing");
    }

    public override void OnSelection()
    {
        base.OnSelection();
    }

    public override void OnDeselection()
    {
        base.OnDeselection();
    }

}
