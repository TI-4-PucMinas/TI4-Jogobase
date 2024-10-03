using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Protag : Player
{

    protected PlayerControls controls;
    //limites da tela
    private float minX, maxX, minY, maxY;
    void Start()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        // Limitar o tamanho da c�mera
        Camera.main.orthographicSize = 5.265842f;
        // Calcular os limites da c�mera em coordenadas do mundo
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Definir os limites com base nas bordas da c�mera
        minX = bottomLeft.x;
        maxX = topRight.x;
        // Ajustar o scale da c�mera ao m�nimo poss�vel, mantendo a propor��o da tela
        AdjustCameraScale();
        UpdateCameraLimits();
    }

    void Update()
    {
        if (!onGround)
        {
            //Debug.Log("no ar");
            animator.SetBool("Pulando", true);
        }

        if (onGround)
        {
            //Debug.Log("no chao");
            animator.SetBool("Pulando", false);
        }


        if (onGround && !isAttacking)
        {

            

            if (horizontal == 0f) { animator.SetBool("Run", false); }

            if (horizontal > 0f)
            {
                animator.SetBool("Run", true);
                Debug.Log("andando pra direita");

            }
            else if (horizontal < 0f)
            {
                animator.SetBool("Run", true);
                Debug.Log("andando pra outro lado");
            }

        }


        if (!isAttacking)
        {
            if (onGround)
            {
                rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            }
            else if (onAirD)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else if (onAirA)
            {
                rb.velocity = new Vector2(-1 * moveSpeed, rb.velocity.y);
            }
        }
        //ATUALIZAR OS LIMITES DA C�MERA
        UpdateCameraLimits();
        RestrictMovement();
    }
    void RestrictMovement()
    {
        // Restringir a posi��o do personagem dentro dos limites
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);

        transform.position = position;
    }
    void UpdateCameraLimits()
    {
        // Calcular os limites da c�mera em coordenadas do mundo
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));

        // Definir os limites com base nas bordas da c�mera
        minX = bottomLeft.x;
        maxX = topRight.x;
    }
    // Ajusta a escala da c�mera mantendo a propor��o da tela
    void AdjustCameraScale()
    {
        // Obtenha a propor��o da tela (aspect ratio)
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        Camera.main.aspect = aspectRatio;

    }
}