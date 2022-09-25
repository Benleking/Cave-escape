using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public GameObject ToolIcon;
    public GameObject ToolModel;
    [SerializeField] protected Animator animator;
    public int Damage;

    public abstract void OnUse();

    public virtual void OnSelection()
    {
        ToolIcon.SetActive(true);
        ToolModel.SetActive(true);
    }

    public virtual void OnDeselection()
    {
        ToolIcon.SetActive(false);
        ToolModel.SetActive(false);
    }
}
