using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Hitboxes;

public class Hurtboxes : MonoBehaviour
{

    public Collider2D colisor;

    private Hitboxes.ColliderState _state = Hitboxes.ColliderState.Open;

    private Vector2 hurtboxSize;

    private void Start()
    {
        hurtboxSize = transform.parent.lossyScale.normalized;
        hurtboxSize.y += 0.5f;
        colisor = Physics2D.OverlapBox(transform.parent.transform.position, hurtboxSize, 0);

    }

    public bool GetHitBy(Attack attack)
    {

        if (attack.hitbox.enabled)
        {
            
            Debug.Log("AI");
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.matrix = Matrix4x4.TRS(colisor.transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector2.zero, new Vector2(hurtboxSize.x * 2, hurtboxSize.y * 2)); // Because size is halfExtents

    }

   
}
