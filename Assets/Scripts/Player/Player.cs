using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    //public Animator animator;  
    private float _currentSpeed;

    private Animator _currentPlayer;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    private void Update()
    {
        HandleJump();
        HandleMovemnt();
    }

    private void HandleMovemnt()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 1.5f;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, soPlayerSetup.playerSwapDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //myRigidBody.MovePosition(myRigidBody.position - velocity * Time.deltaTime);
            myRigidBody.velocity = new Vector2(-_currentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, soPlayerSetup.playerSwapDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if (myRigidBody.velocity.x > 0f)
        {
            myRigidBody.velocity += soPlayerSetup.friction;
        }
        if (myRigidBody.velocity.x < 0f)
        {
            myRigidBody.velocity -= soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //myRigidBody.MovePosition(myRigidBody.position + velocity * Time.deltaTime);
            myRigidBody.velocity = Vector2.up * soPlayerSetup.jumpForce;
            myRigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidBody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);    
    }
}
