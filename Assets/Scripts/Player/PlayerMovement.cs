using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimationCurve))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")] 
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpOffset;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isAttacking;

    [Header("Settings")] 
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;

    [Header("Attack setting")] 
    [SerializeField] private float damage; 
    [SerializeField] private Transform attack1;
    [SerializeField] private float attack1Radius;

    private Rigidbody2D rb;
    private Animator anim;
    
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    private static readonly int Velocity = Animator.StringToHash("velocity");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        var overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    public void Move(float direction, bool jumpButtonDown, bool attackButonDown)
    {
        if (Mathf.Abs(direction) > 0.01f)
            HorizontalMovement(direction);

        if (jumpButtonDown)
            Jump();
        
        if(attackButonDown && !isAttacking)
            isAttacking = true;

        Animatons(direction);
    }
    
    private void Attacking()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attack1.position, attack1Radius);
        
        foreach (var hit in colliders)
        {
            if (hit.gameObject.GetComponent<HealthController>())
            {
                hit.gameObject.GetComponent<HealthController>().TakeDamage(damage);
            }
        }
    }

    private void EndAttack()
    {
        isAttacking = false;
    }
    
    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(movementCurve.Evaluate(direction), rb.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Animatons(float direction)
    {
        anim.SetBool(IsGrounded, isGrounded);
        anim.SetBool(IsAttacking, isAttacking);
        anim.SetFloat(Velocity, Mathf.Abs(movementCurve.Evaluate(direction)));
        
        //разворот персонажа по движению
        var theRotation = transform.localRotation;
        if (direction > 0.01f)
            theRotation.y = 0;
        else if (direction < -0.01f)
            theRotation.y = 180;

        transform.localRotation = theRotation;
    }
}