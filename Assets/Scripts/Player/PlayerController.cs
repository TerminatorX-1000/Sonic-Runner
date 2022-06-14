using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public CharacterController controller;
   private Vector3 _direction;
   public float speed = 8;
   
   public float jumpForce = 10;
   public float gravity = -20;
   public Transform groundCheck;
   public LayerMask groundLayer;
   
   public bool ableToMakeADoubleJump  = true;
   
   public Animator animator;
   public Transform model;
   
    void Update()
    {
        if (PlayerManager.GameOver)
        {
            animator.SetTrigger("die");
            this.enabled = false;
        }
        float hInput = Input.GetAxis("Horizontal");
        _direction.x = hInput * speed;
        animator.SetFloat("speed", Mathf.Abs(hInput));

        bool isGrounded = Physics.CheckSphere(groundCheck.position,0.15f,groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        _direction.y += gravity * Time.deltaTime;
        
        if (isGrounded)
        {
            //_direction.y = -2;
            ableToMakeADoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
               Jump();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("GunAttack");
            }
        }
        else
        {
            _direction.y += gravity * Time.deltaTime;
            if (ableToMakeADoubleJump && Input.GetButtonDown("Jump"))
            {
                DoubleJump();
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("gun"))
            return;
        //  Поворот Игрока
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }
        
        controller.Move(_direction * Time.deltaTime);
        
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

   
    
    
    
    
    
    
    
    
    
    
    private void DoubleJump()
    {
        //Двойной прыжок
        animator.SetTrigger("doubleJump");
        _direction.y = jumpForce;
        ableToMakeADoubleJump = false;
    }

    private void Jump()
    {
        _direction.y = jumpForce;
    }
}
