using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float Acceleration = 10f;
    public float Jumpforce = 50f;
    public float MaxSlopeAngle = 30f;
    public LayerMask GroundLayerMask;
    public cooldown CoyoteTime;
    public float GroundCheckRadius = 1f;


    public PhysicsMaterial2D Default;
    public PhysicsMaterial2D FullFriction;
    public PhysicsMaterial2D slip;
    protected bool _disableInput = false;
    public bool IsRunning
    {
    get 
        {
        return _IsRunning;
        }
    }

    public bool FlipAnim
    {
    get 
        {
        return _FlipAnim;
        }
        set 
        { 
            _FlipAnim = value; 
        }
    }
  
    protected Rigidbody2D _rigidbody;
    protected Vector2 _InputDirection;
    public bool IsGrounded = true;
    public float _lastSlopAngle;


    private AudioSource _audioSource;
    public AudioClip _audioClip;

    protected RaycastHit2D _groundHit;
    protected RaycastHit2D _slopeHit;
    public float _slopeAngle = 0f;
    protected Health _health;

    protected Vector2 _slopeHitNormal = Vector2.zero;
    public bool _isOnSlope = false;
    public bool _canWalkOnSlope = false;

    protected bool _IsRunning = false;
    protected bool _FlipAnim = false;
    protected bool _IsJumping = false;
    protected bool _CanJump = true;

    public float Pushforce = 3f;

    void Start()
    {
        _audioSource= GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        
        if (_health != null ) 
        {
            _health.OnHit += Hit;
            _health.OnHitReset += ResetMove;
        }
    
        
    }
    private void OnDisable()
    {
        if (_health != null)
        {
            _health.OnHit -= Hit;
            _health.OnHitReset-= ResetMove;
        }
    }

    protected virtual void Hit(GameObject source)


    {
        float pushHorizontal = 0f;
        if ( source!= null ) 
        {
            if ( source.transform.position.x < transform.position.x ) 
            {
                pushHorizontal = Pushforce;
            }
            else
            {
                pushHorizontal = -Pushforce;
            }
        }


        _rigidbody.velocity = new Vector2(pushHorizontal,Pushforce);

        _disableInput= true ;
    }

    protected virtual void ResetMove()
    {
        _disableInput= false ;
    }
    void Update()
    {
        HandleInput();

        if (Input.GetKeyDown(KeyCode.F))
        {
            CoyoteTime.Startcooldown();
        }
    }
    protected virtual void FixedUpdate()
    {
        CheckGround();
        CheckSlope();
        HandleMovement();
        HandleFlip();
       
        
    }

    

   
    protected virtual void HandleInput()
    {

    }

    protected virtual void HandleMovement()
    {

        if (_disableInput)
            return;

        if (_rigidbody == null)
            return;

        _rigidbody.velocity = new Vector2(_InputDirection.x * Acceleration, _rigidbody.velocity.y);

        if (_rigidbody.velocity.x == 0 ) 
        { 
            _IsRunning= false;
        }
        else 
        { 
            _IsRunning= true;
        }
    }

    protected virtual void HandleFlip()
    {
        if (_InputDirection.x == 0) 
            return;

        if (_InputDirection.x > 0)
        {
            _FlipAnim= false;
        }
        else if (_InputDirection.x < 0 ) 
        {
            _FlipAnim= true;
        }


    }

    protected virtual void DoJump()
    {
        if ( _disableInput) 
            return;

        if (_rigidbody == null)
            return;


        if (!_CanJump) 
            return;


        if (CoyoteTime.CurrentProgress == cooldown.Progress.Finished)           
            return;


        _CanJump = false;
        _IsJumping = true;
       
        Debug.Log("Jumping");
        _audioSource.PlayOneShot(_audioClip);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Jumpforce);
        CoyoteTime.Stopcooldown();
    }

    protected void CheckSlope()
    {
        _slopeHit = Physics2D.Raycast(transform.position, Vector2.down, 2f, GroundLayerMask);

        if (_slopeHit)
        {
            _slopeHitNormal = _slopeHit.normal;
            _slopeAngle = Vector2.Angle(Vector2.up, _slopeHitNormal);

            if (_slopeAngle != _lastSlopAngle)
            {
                _isOnSlope = true;
            }

            if (_slopeAngle < 1)
            {
                _isOnSlope = false;
            }

            _lastSlopAngle = _slopeAngle;
        }
        if (_slopeAngle > MaxSlopeAngle)
        {
            _canWalkOnSlope = false;
        }
        else
        {
            _canWalkOnSlope = true;
        }
        // Debug.Log(Vector2.Angle(Vector2.up ,_slopeHit.normal));
       

        if (_isOnSlope && _canWalkOnSlope && _InputDirection.x == 0)
        {
            _rigidbody.sharedMaterial = FullFriction;
        }
        else
        {
            _rigidbody.sharedMaterial = Default;
        }
        //if (_InputDirection.x > 0)
        //{
        //    _rigidbody.sharedMaterial = slip;
        //}

    }

    protected void CheckGround()
    {
    
        //IsGrounded = Physics2D.OverlapCircle(transform.position, GroundCheckRadius , GroundLayerMask);
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, GroundLayerMask);

        if (_rigidbody.velocity.y <= 0f) 
        { 
            _IsJumping= false;
        }

        if (IsGrounded && !_IsJumping)
        {
            _CanJump= true;
            if(CoyoteTime.CurrentProgress !=cooldown.Progress.Ready ) 
                CoyoteTime.Stopcooldown();


           // DoJump();
        }

        if (!IsGrounded && !_IsJumping && CoyoteTime.CurrentProgress == cooldown.Progress.Ready)
        {
            CoyoteTime.Startcooldown();
        }


        

    }

}
