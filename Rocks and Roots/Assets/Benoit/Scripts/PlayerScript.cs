using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 2.0f;
    public GameObject _target;
    private Animator animator;
    private bool _canMove = true;
    [SerializeField]
    private float _longueurDuBras = 2f;
    [Header("Tools Settings")]
    [SerializeField]
    private Tool[] toolList = new Tool[2];
    private int activeToolIndex;
    [Header("UI Settings")]
    [SerializeField]
    private Image _breakIconImage;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
       SwapTool();
       UseTool();
    }
    private void FixedUpdate()
    {
        ManageMovement();
        WhatIsTheTarget();
    }

    private void ManageMovement()
    {
        if (_canMove) { 
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetBool("isMoving", true);
        }else
        {
            animator.SetBool("isMoving", false);
        }
        controller.Move(playerVelocity * Time.deltaTime);
        }
    }
    private void WhatIsTheTarget()
    {
        RaycastHit hit;
        Ray forwardaBit = new Ray(transform.position, transform.forward);
       

        Debug.DrawRay(transform.position, transform.forward * _longueurDuBras);

        if (Physics.Raycast(forwardaBit, out hit, _longueurDuBras))
            {
            if (hit.collider.tag == "Rocks" || hit.collider.tag == "Roots")
            {
                _target = hit.transform.gameObject;
            } 
        } else
        {
            _target = null;
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
      if ((Input.GetKeyDown(KeyCode.Q)))
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
        if (Input.GetKeyDown(KeyCode.E) && _canMove)
        {
           toolList[activeToolIndex].OnUse();
           StartCoroutine(PerformingAction());
        }
    }

    IEnumerator PerformingAction()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.5f);
        _canMove = true;
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
        /*
        Gold gold = other.GetComponent<Gold>();
        if(gold != null)
        {
            gold.OnPlayerPickup(this);
        }*/
    }

    public void Slowdown(float multiplier)
    {
        StartCoroutine(SlowEffect(multiplier));
    }

    private IEnumerator SlowEffect(float multiplier)
    {
        playerSpeed *= multiplier;
        yield return new WaitForSeconds(2f);
        playerSpeed /= multiplier;
    }

    public void Bounce(Vector3 vector, float duration)
    {
        StartCoroutine(BounceEffect(vector,duration));
    }

    private IEnumerator BounceEffect(Vector3 vector, float duration)
    {
        _canMove = false;
        float timer = 0f;
        while(timer <= duration)
        {
            controller.Move(vector * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        _canMove = true;
    }

    public void Defeated()
    {
        Toolbox.GetInstance().GetUIManager().RetryOverlay.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Victorious()
    {
        Toolbox.GetInstance().GetUIManager().WinOverlay.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
}
