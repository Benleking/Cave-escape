using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float playerSpeed = 2.0f;
    private Animator animator;
    private bool canMove = true;
    [Header("Tools Settings")]
    [SerializeField]
    private Tool[] toolList = new Tool[2];
    private int activeToolIndex;
    [Header("Audio Settings")]
    [SerializeField]
    private AudioClip goldPickupClip;
    [SerializeField]
    private AudioSource audioSource;

    public float GetSpeed()
    {
        return playerSpeed;
    }

    public void SetSpeed(float value)
    {
        playerSpeed = value;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public CharacterController GetCharacterController()
    {
        return controller;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    private void Update()
    {
       SwapTool();
       UseTool();
       CheckForPause();
       ManageMovement();
    }

    private void ManageMovement()
    {
        if (canMove) 
        { 
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move.normalized * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
    private void Initialization()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        activeToolIndex = 0;
        toolList[activeToolIndex].OnSelection();
    }
    private void SwapTool()
    {
      if (Input.GetKeyDown(KeyCode.Q) && canMove)
        {
            toolList[activeToolIndex].OnDeselection();
            activeToolIndex++;//0,1,2
            if(activeToolIndex >= toolList.Length)
            {
                activeToolIndex = 0;
            }
            toolList[activeToolIndex].OnSelection();
        }
    }

    private void UseTool()
    {
        if (Input.GetKeyDown(KeyCode.E) && canMove)
        {
           toolList[activeToolIndex].OnUse();
           StartCoroutine(PerformingAction());
        }
    }

    private void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toolbox.GetInstance().GetLevelManager().PauseLevel();
        } 
    }

    IEnumerator PerformingAction()
    {
        canMove = false;
        yield return new WaitForSeconds(0.65f);
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        ExitCondition ec = other.GetComponent<ExitCondition>();
        if(ec != null)
        {
            ec.OnPlayerEnter(this);
        }

        Trap trap = other.GetComponent<Trap>();
        if (trap != null)
        {
            trap.OnPlayerEnter(this);
        }
        
        Gold gold = other.GetComponent<Gold>();
        if(gold != null)
        {
            Toolbox.GetInstance().GetLevelManager().AddScore(gold.GetValue());
            audioSource.clip = goldPickupClip;
            audioSource.Play();
        }
    }

    public void Defeated()
    {
        Toolbox.GetInstance().GetLevelManager().LoseLevel();
    }

    public void Victorious()
    {
        Toolbox.GetInstance().GetLevelManager().WinLevel();
    }
}
