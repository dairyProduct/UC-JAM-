using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float baseHorizontalSpeedGrounded = 100.0f;
    [SerializeField] private float baseHorizontalSpeedAerial = 50.0f;
    [SerializeField] private float minVelocity = 1.0f;
    [SerializeField] private float baseMaxVelocity = 10.0f;
    
    [Header("Gravity")]
    [SerializeField] private float fallingGravity = 10.0f;
    [SerializeField] private float risingGravity = 3.0f;
    
    [Header("Jump")]
    [SerializeField] private float baseJumpStrengthGrounded = 1000.0f;
    [SerializeField] private float baseJumpStrengthAerial = 750.0f;
    [SerializeField] private int maxMidairJumpCount = 1;

    private bool isAerial = false;
    private bool isRising = false;
    
    private int midairJumpCount = 0;
    private Rigidbody2D rb;
    private float lastY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        var package = Stat.GS.InputManager.LatestInputPackage;
        if (package.Contains(InputManager.InputValues.Jump, out InputManager.InputPackageElement outJumpElement))
        {
            TryJump();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Ground") && hit.distance < .01f)
        {
            Debug.Log(hit.distance);
            OnHitGround();
        }
        
        float horizontal = 0;
        var package = Stat.GS.InputManager.LatestInputPackage;
        if (package.Contains(InputManager.InputValues.Left, out InputManager.InputPackageElement outLeftElement))
        {
            horizontal += outLeftElement.Magnitude;
        }
        
        if (package.Contains(InputManager.InputValues.Right, out InputManager.InputPackageElement outRightElement))
        {
            horizontal += outRightElement.Magnitude;
        }

        if (horizontal != 0)
        {
            if (!isAerial)
            {
                if (Mathf.Abs(rb.linearVelocityX) < minVelocity)
                {
                    rb.linearVelocityX = (horizontal/Mathf.Abs(horizontal)) * minVelocity;
                }
            }
            
            rb.AddForce(
                isAerial
                    ? new Vector2(horizontal * baseHorizontalSpeedAerial * Time.fixedDeltaTime, 0)
                    : new Vector2(horizontal * baseHorizontalSpeedGrounded * Time.fixedDeltaTime, 0),
                ForceMode2D.Impulse);
        }

        if (!isAerial)
        {
            rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -baseMaxVelocity, baseMaxVelocity);
        }
        
        Debug.LogError(rb.linearVelocityX);
        isRising = isAerial && transform.position.y >= lastY;
        rb.gravityScale = isRising ? risingGravity : fallingGravity;
        lastY = transform.position.y;
    }

    private void TryJump()
    {
        if (!isAerial)
        {
            rb.AddForce(new Vector2(0, baseJumpStrengthGrounded * Time.fixedDeltaTime), ForceMode2D.Impulse);
            isAerial = true;
        }
        else if(midairJumpCount + 1 <= maxMidairJumpCount)
        {
            midairJumpCount++;
            rb.AddForce(new Vector2(0, baseJumpStrengthAerial * Time.fixedDeltaTime), ForceMode2D.Impulse);
            isAerial = true;
        }
    }

    private void OnHitGround()
    {
        if (isAerial)
        {
            isAerial = false;
            midairJumpCount = 0;
        }
    }
}