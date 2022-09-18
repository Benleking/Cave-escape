using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool _playerIsMining;
    private bool _playerIsCutting;
    private float playerSpeed = 2.0f;
    private float _actionCooldown = 1f;
    private Animator animator;
    private bool _canMove;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        ManageMovement();
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
}
