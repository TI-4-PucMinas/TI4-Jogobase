using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;



public class Player : MonoBehaviour
{

    protected Rigidbody2D rb;
    protected bool onGround = false;
    protected bool onAirD = false;
    protected bool onAirA = false;
    protected bool onAirW = false;
    protected bool isAttacking = false;
    public Animator animator;
    protected Attack atacante;
    private int anim = 0;

    //Clipe de animação
    public AnimationClipEX clipEX;


    public float jumpForce = 30f;
    public float moveSpeed = 5f;
    public float attackDuration = 3f;
    public float horizontal = 0f;

    protected Vector2 moveInput;

    void Start()
    {
        
    }

    void Update()
    {

        

    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            onAirD = false;
            onAirA = false;
            onAirW = false;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;
        //Debug.Log(horizontal);

      


    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && onGround && !isAttacking)
        {
            
            moveInput = context.ReadValue<Vector2>();

            // Verifica se apenas 'W' está pressionado
            if (moveInput.x == 0 && moveInput.y > 0 && !onAirD && !onAirA)
            {
                Debug.Log("pulo");
                rb.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
                
            }
            // Verifica se 'W + D' está pressionado
            else if (moveInput.x > 0 && moveInput.y > 0 && !onAirA && !onAirW)
            {
                Debug.Log("W+D");
                rb.AddForce(new Vector2(1, 1) * jumpForce, ForceMode2D.Impulse);
                onAirD = true;
                
            }
            // Verifica se 'W + A' está pressionado
            else if (moveInput.x < 0 && moveInput.y > 0 && !onAirD && !onAirW)
            {
                Debug.Log("W+A");
                rb.AddForce(new Vector2(-1, 1) * jumpForce, ForceMode2D.Impulse);
                onAirA = true;
               
            }

            
        }
    }

    public void AttackW(InputAction.CallbackContext context)
    {
        if (context.performed) // Apenas quando a ação for completada
        {
            var control = context.control;

            if (!isAttacking && onGround)
            {
                // Verifica se o binding de apenas W foi acionado
                if (control == Keyboard.current.fKey && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackWCoroutine());
                }
                // Verifica se o binding W+D foi acionado
                else if (Keyboard.current.fKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(AttackWDCoroutine());
                }
                // Verifica se o binding W+A foi acionado
                else if (Keyboard.current.fKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackWACoroutine());
                }
            }
        }
    }

    public void AttackM(InputAction.CallbackContext context)
    {
        if (context.performed) // Apenas quando a ação for completada
        {
            var control = context.control;

            if (!isAttacking && onGround)
            {
                // Verifica se o binding de apenas M foi acionado
                if (control == Keyboard.current.gKey && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackMCoroutine());
                }
                // Verifica se o binding M+D foi acionado
                else if (Keyboard.current.gKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(AttackMDCoroutine());
                }
                // Verifica se o binding M+A foi acionado
                else if (Keyboard.current.gKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackMACoroutine());
                }
            }

        }
    }

    public void AttackS(InputAction.CallbackContext context)
    {
        if (context.performed) // Apenas quando a ação for completada
        {
            var control = context.control;

            if (!isAttacking && onGround)
            {
                // Verifica se o binding de apenas S foi acionado
                if (control == Keyboard.current.hKey && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackSCoroutine());
                }
                // Verifica se o binding s+D foi acionado
                else if (Keyboard.current.hKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(AttackSDCoroutine());
                }
                // Verifica se o binding S+A foi acionado
                else if (Keyboard.current.hKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackSACoroutine());
                }
            }
        }
    }

    public void AttackSS(InputAction.CallbackContext context)
    {
        if (context.performed) // Apenas quando a ação for completada
        {
            var control = context.control;

            if (!isAttacking && onGround)
            {
                // Verifica se o binding de apenas SS foi acionado
                if (control == Keyboard.current.jKey && !Keyboard.current.dKey.isPressed && !Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackSSCoroutine());
                }
                // Verifica se o binding SS+D foi acionado
                else if (Keyboard.current.jKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(AttackSSDCoroutine());
                }
                // Verifica se o binding SS+A foi acionado
                else if (Keyboard.current.jKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(AttackSSACoroutine());
                }
            }
        }
    }

    private IEnumerator AttackWCoroutine()
    {
        Debug.Log("AttackW");
        isAttacking = true;
        clipEX.clip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        clipEX.animatorStateName = clipEX.clip.name;
        clipEX.Initialize();
        animator.SetBool("Attack",true);
        anim = clipEX.TotalFrames();

        atacante.Ataque(50, new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),20,5,6,new Vector2(0.7f,0.5f),clipEX);

        for(int i = 0; i < anim; i++)
        {
            atacante.hitbox.HitboxUpdate();
            atacante.frameChecker.CheckFrames();
            yield return null;
        }

        

        // Bloqueia todas as ações por um tempo determinado
        //yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackWDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackWACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.F))
            {
                StartCoroutine(AttackWCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackW");
        isAttacking = false;
    }

    private IEnumerator AttackWDCoroutine()
    {
        Debug.Log("AttackWD");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackWDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackWACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.F))
            {
                StartCoroutine(AttackWCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackWD");
        isAttacking = false;
    }

    private IEnumerator AttackWACoroutine()
    {
        Debug.Log("AttackWA");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackWDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.F) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackWACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.F))
            {
                StartCoroutine(AttackWCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackWA");
        isAttacking = false;
    }

    private IEnumerator AttackMCoroutine()
    {
        Debug.Log("AttackM");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackM");
        isAttacking = false;
    }

    private IEnumerator AttackMDCoroutine()
    {
        Debug.Log("AttackMD");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackMD");
        isAttacking = false;
    }

    private IEnumerator AttackMACoroutine()
    {
        Debug.Log("AttackMA");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.G) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackMA");
        isAttacking = false;
    }

    private IEnumerator AttackSCoroutine()
    {
        Debug.Log("AttackS");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J))
            {
                StartCoroutine(AttackSSCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackS");
        isAttacking = false;
    }

    private IEnumerator AttackSDCoroutine()
    {
        Debug.Log("AttackSD");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J))
            {
                StartCoroutine(AttackSSCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackSD");
        isAttacking = false;
    }

    private IEnumerator AttackSACoroutine()
    {
        Debug.Log("AttackSA");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        float timer = 3f;

        while (timer > 0)
        {
            yield return null;
            if (UnityEngine.Input.GetKey(KeyCode.H) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J) && UnityEngine.Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSSACoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSSDCoroutine());
                yield break;
            }
            if (UnityEngine.Input.GetKey(KeyCode.J))
            {
                StartCoroutine(AttackSSCoroutine());
                yield break;
            }
            timer -= Time.deltaTime;
        }

        Debug.Log("Fim attackSA");
        isAttacking = false;
    }

    private IEnumerator AttackSSCoroutine()
    {
        Debug.Log("AttackSS");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);

        Debug.Log("Fim attackSS");
        isAttacking = false;
    }

    private IEnumerator AttackSSDCoroutine()
    {
        Debug.Log("AttackSSD");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);


        Debug.Log("Fim attackSSD");
        isAttacking = false;
    }

    private IEnumerator AttackSSACoroutine()
    {
        Debug.Log("AttackSSA");
        isAttacking = true;

        // Bloqueia todas as ações por um tempo determinado
        yield return new WaitForSeconds(3);


        Debug.Log("Fim attackSSA");
        isAttacking = false;
    }

}
