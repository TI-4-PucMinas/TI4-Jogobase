using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{

    protected Rigidbody2D rb;
    private int startup;
    private int duration;
    private int cooldown;
    protected bool onGround = false;
    protected bool onAirD = false;
    protected bool onAirA = false;
    protected bool onAirW = false;
    protected bool isAttacking = false;
    public Animator animator;
    protected Attack atacante;
    protected GerenciadorDvida vida;

    //Clipe de animação
    public AnimationClipEX clipEX;

    public float jumpForce = 70f;
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
            Debug.Log("Tentando pular");
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
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackWCoroutine());
                }
                // Verifica se o binding W+D foi acionado
                else if (Keyboard.current.fKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackWDCoroutine());
                }
                // Verifica se o binding W+A foi acionado
                else if (Keyboard.current.fKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
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
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackMCoroutine());
                }
                // Verifica se o binding M+D foi acionado
                else if (Keyboard.current.gKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackMDCoroutine());
                }
                // Verifica se o binding M+A foi acionado
                else if (Keyboard.current.gKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
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
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackSCoroutine());
                }
                // Verifica se o binding s+D foi acionado
                else if (Keyboard.current.hKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackSDCoroutine());
                }
                // Verifica se o binding S+A foi acionado
                else if (Keyboard.current.hKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
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
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackSSCoroutine());
                }
                // Verifica se o binding SS+D foi acionado
                else if (Keyboard.current.jKey.isPressed && Keyboard.current.dKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackSSDCoroutine());
                }
                // Verifica se o binding SS+A foi acionado
                else if (Keyboard.current.jKey.isPressed && Keyboard.current.aKey.isPressed)
                {
                    StartCoroutine(TacaAnimation("Attack"));
                    StartCoroutine(AttackSSACoroutine());
                }
            }
        }
    }

    private IEnumerator AttackWCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque W
        Debug.Log("attackW");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            3,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        //Resto dos quadros
        for (int i = 0; i < cooldown; i++)
        {
            //Sistema de Gatling
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackWDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackWACoroutine());
                yield break;
            }
            //if ( Input.GetKey(KeyCode.F))
            //{
            //    StartCoroutine(AttackWCoroutine());
            //    yield break;
            //}
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            yield return null;
        }

       // StartCoroutine(CloseAnimation("Attack"));
        Debug.Log("Fim attackW");

    }

    private IEnumerator AttackWDCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque W
        Debug.Log("attackW");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            3,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            //if ( Input.GetKey(KeyCode.F) &&  Input.GetKey(KeyCode.D))
            //{
            //    StartCoroutine(AttackWDCoroutine());
            //    yield break;
            //}
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackWACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.F))
            {
                StartCoroutine(AttackWCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            yield return null;
        }
        Debug.Log("Fim attackWD");
        
    }

    private IEnumerator AttackWACoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque W
        Debug.Log("attackW");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            3,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackWDCoroutine());
                yield break;
            }
            //if ( Input.GetKey(KeyCode.F) &&  Input.GetKey(KeyCode.A))
            //{
            //    StartCoroutine(AttackWACoroutine());
            //    yield break;
            //}
            if (Input.GetKey(KeyCode.F))
            {
                StartCoroutine(AttackWCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            yield return null;
        }
        Debug.Log("Fim attackWA");
    }

    private IEnumerator AttackMCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackM");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            7,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();
        //Resto dos quadros
        for (int i = 0; i < cooldown; i++)
        {
            //Sistema de Gatling
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            yield return null;
        }
        //Fim do ataque M
        Debug.Log("Fim attackM");
    }

    private IEnumerator AttackMDCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackMD");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            7,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackMACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackMD");
    }

    private IEnumerator AttackMACoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackMA");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            7,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            if (Input.GetKey(KeyCode.G) &&  Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackMDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.G))
            {
                StartCoroutine(AttackMCoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H) &&  Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackMA");
    }

    private IEnumerator AttackSCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackS");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            13,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            if (Input.GetKey(KeyCode.H) &&  Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSSACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.J) &&  Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSSDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.J))
            {
                StartCoroutine(AttackSSCoroutine());
                yield break;
            }
            yield return null;
        }


        //Fim do ataque M
        Debug.Log("Fim attackS");
    }

    private IEnumerator AttackSDCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackSD");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            12,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            if ( Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSSACoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.J) &&  Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSSDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.J))
            {
                StartCoroutine(AttackSSCoroutine());
                yield break;
            }
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackSD");
    }

    private IEnumerator AttackSACoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackSA");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            12,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            if ( Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSDCoroutine());
                yield break;
            }
            if (Input.GetKey(KeyCode.H))
            {
                StartCoroutine(AttackSCoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.J) &&  Input.GetKey(KeyCode.A))
            {
                StartCoroutine(AttackSSACoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.J) &&  Input.GetKey(KeyCode.D))
            {
                StartCoroutine(AttackSSDCoroutine());
                yield break;
            }
            if ( Input.GetKey(KeyCode.J))
            {
                StartCoroutine(AttackSSCoroutine());
                yield break;
            }
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackSA");
    }

    private IEnumerator AttackSSCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackSS");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            16,
            new Vector2(transform.position.x + 1f, transform.position.y),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.8f, 0.7f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackSS");
    }

    private IEnumerator AttackSSDCoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackSSD");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            16,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackSSD");
    }

    private IEnumerator AttackSSACoroutine()
    {
        //Dados desse ataque
        startup = 6;
        duration = 10;
        cooldown = 15;

        //Inicio ataque M
        Debug.Log("attackSSA");

        //Set isAttacking como true
        isAttacking = true;

        //Quadros iniciais do ataque são aguardados
        for (int i = 0; i < startup; i++)
        {
            yield return null;
        }

        //Ataque é criado
        atacante.Ataque
        (
            17,
            new Vector2(transform.position.x + 1f, transform.position.y + 0.1f),
            duration,
            startup,
            cooldown
        );

        //Hitbox é ativada
        atacante.hitbox.SetHitbox(new Vector2(0.7f, 0.5f));
        for (int i = 0; i < duration + cooldown; i++)
        {
            //Enquanto o ataque estiver ativo, a hitbox é atualizada
            atacante.hitbox.HitboxUpdate();
            yield return null;
        }

        //Desativa a hitbox
        atacante.hitbox.StopCheckingCollision();

        for (int i = 0; i < cooldown; i++)
        {
            yield return null;
        }

        //Fim do ataque M
        Debug.Log("Fim attackSSA");
    }

    private IEnumerator TacaAnimation(string anim)
    {
        if(animator.GetBool(anim))
        {
            animator.SetBool(anim, false);
            yield return null;
        }
        animator.SetBool(anim, true);
        yield break;
    }

    public void EndAnimation(string anim)
    {
        isAttacking = false;
        animator.SetBool(anim, false);
    }

    public void TomarDano(float dano)
    {
        vida.machuca(dano);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            Debug.Log("Tomou dano");
            TomarDano(collision.GetComponentInParent<Attack>().damage);
        }
    }

}
