using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 2.0f;
    public GameObject _target;
    private Animator animator;
    private bool _canMove = true;
    [SerializeField]
    private float _longueurDuBras = 2f;
    [Header("Tools Settings")]
    [SerializeField]
    private GameObject _pickaxeIcon;
    [SerializeField]
    private GameObject _AxeIcon;
    [SerializeField]
    private GameObject _pickaxeInHand;
    [SerializeField]
    private GameObject _AxeInHand;
    private bool _hasPickaxeRightNow;
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
       DestroyObstacle();
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
        _pickaxeIcon.SetActive(true);
        _AxeIcon.SetActive(false);
        _pickaxeInHand.SetActive(true);
        _AxeInHand.SetActive(false);
        _hasPickaxeRightNow = true;
    }
    private void SwapTool()
    {
      if ((Input.GetKeyDown(KeyCode.Q)) && (_hasPickaxeRightNow))
        {
            _pickaxeIcon.SetActive(false);
            _AxeIcon.SetActive(true);
            _pickaxeInHand.SetActive(false);
            _AxeInHand.SetActive(true);
            _hasPickaxeRightNow = false;
        } else if ((Input.GetKeyDown(KeyCode.Q)) && (!_hasPickaxeRightNow))
        {
            _pickaxeIcon.SetActive(true);
            _AxeIcon.SetActive(false);
            _pickaxeInHand.SetActive(true);
            _AxeInHand.SetActive(false);
            _hasPickaxeRightNow = true;
        }
    }

    private void DestroyObstacle()
    {   
        if ((_target != null) && (Input.GetKeyDown(KeyCode.E)) && (_canMove))
        {
            if ((_target.tag == "Rocks") && _hasPickaxeRightNow)
            {
                StartCoroutine(PerformingAction());
            }else if ((_target.tag == "Roots") && !_hasPickaxeRightNow)
                {
                    StartCoroutine(PerformingAction());
                }
        }
        
        if ((_target == null) || ((_target.tag == "Rocks") && !_hasPickaxeRightNow) || ((_target.tag == "Roots") && _hasPickaxeRightNow))
        {
            _breakIconImage.color = new Color(1f, 1f, 1f, 0.3f);
        } else
        {
            _breakIconImage.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    IEnumerator PerformingAction()
    {
        _canMove = false;
        animator.SetBool("isMining", true);
        yield return new WaitForSeconds(2.8f);
        animator.SetBool("isMining", false);
        _target.SetActive(false);
        _canMove = true;
    }
}
