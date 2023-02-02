using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //============= Player Move ===============
    [Header("Player Move")]
    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float jumpPower;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector3 moveVec;
    [SerializeField] private float maxVelocity = 2;
    //=========================================
    [Space]

    //================ Attack =================
    [SerializeField] private GameObject attackCollider;
    private Coroutine attackcoroutine;
    //=========================================

    //=========== Player Controller ===========
    private Rigidbody rigid;
    private Animator anim;
    //=========================================

    [Header("Velocity And GroundCheck")]
    //======= Velocity And GroundCheck ========
    [SerializeField] private Transform groundChecker;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    //=========================================
    [Space]

    //============ Bool Checker ===============
    [SerializeField] private bool isMoving;
    [SerializeField] private bool jumpOrder;
    [SerializeField] private bool attackOrder;
    //=========================================

    //=========== Animator String =============
    private List<string> animlist;
    private string idleanim = "idle";
    private string moveanim = "isMovig";
    //=========================================

    private void Awake()
    {
        moveSpeed = 300;
        jumpPower = 10f;
        attackcoroutine = null;
        animlist = new List<string>();
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        SetAnimList();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetAnimList()
    {
        animlist.Add(idleanim);
        animlist.Add(moveanim);
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
        IsGrounded();
        HitTest();
        //AnimationUpdate();
    }

    private void FixedUpdate()
    {
        FixedMove();
        FixedJump();
        FixedAttack();
    }

    private void AnimationUpdate()
    {
        string updateAnim;
        if (isMoving)
            updateAnim = moveanim;
        else
            updateAnim = idleanim;

        for (int i=0; i< animlist.Count; i++)
        {
            bool playAnim = animlist[i] == updateAnim ? true : false;
            anim.SetBool(updateAnim, playAnim);
        }
    }

    private void Move()
    {
        Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
        Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;

        Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
        if (moveInput.sqrMagnitude > 1f) moveInput.Normalize();
        moveVec = fowardVec * moveInput.z + rightVec * moveInput.x;

        // GetAxisRaw �� �Է°��� �ִ����� ���θ� bool�� �Ǵ��Ͽ� ���� 
        bool vermove = Input.GetAxisRaw("Vertical") != 0 ? true : false;
        bool hormove = Input.GetAxisRaw("Horizontal") != 0 ? true : false;

        isMoving = vermove || hormove ? true : false;
        // ver, hor �� �� �ϳ��� true�� ��� true ����
        MaxSpeed();
    }

    private void MaxSpeed()
    {
        if (rigid.velocity.x > maxVelocity)
        {
            rigid.velocity = new Vector3(maxVelocity, rigid.velocity.y, rigid.velocity.z);
        }

        if (rigid.velocity.x < (maxVelocity * -1))
        {
            rigid.velocity = new Vector3((maxVelocity * -1), rigid.velocity.y, rigid.velocity.z);
        }

        if (rigid.velocity.z > maxVelocity)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, maxVelocity);
        }

        if (rigid.velocity.z < (maxVelocity * -1))
        {
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, (maxVelocity * -1));
        }
    }


    private void FixedMove()
    {
        rigid.AddForce(moveVec * moveSpeed);
        if (moveVec.sqrMagnitude != 0)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveVec, Time.fixedDeltaTime * 10);
        }
    }

    private void FixedJump()
    {
        if (jumpOrder)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpOrder = false;
        }

    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && isGrounded)
            attackOrder = true;
    }

    private void FixedAttack()
    {
        if(attackOrder && attackcoroutine == null)
        {
            attackCollider.SetActive(true);
            attackcoroutine = StartCoroutine(OffAttackCollier());
        }
    }

    private IEnumerator OffAttackCollier()
    {
        yield return new WaitForSeconds(0.5f);
        attackCollider.SetActive(false);
        attackOrder = false;
        attackcoroutine = null;
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
            jumpOrder = true;
    }

    private void HitTest()
    {
        if (Input.GetKeyDown(KeyCode.P))
            OnHit();
    }
    private void OnHit()
    {
        if(rigid.constraints == RigidbodyConstraints.None)
        {
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

    private void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);
    }
}