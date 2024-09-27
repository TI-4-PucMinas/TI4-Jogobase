using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Hitboxes : MonoBehaviour
{
    public LayerMask mask;

    public bool useSphere = false;

    public Vector2 hitboxSize = Vector2.one;

    public float radius = 0.5f;

    public Color inactiveColor;

    public Color collisionOpenColor;

    public Color collidingColor;

    private Collider2D[] colliders;


    private ColliderState _state;

    private void Start()
    {
        //hitboxSize = new Vector2(1, 2);
        if (useSphere)
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, radius, mask);
        }
        else
        {
            colliders = Physics2D.OverlapBoxAll(transform.position, hitboxSize, mask);
        }

    }

    private void Update()
    {

        if (_state == ColliderState.Closed) { return; }

        colliders = Physics2D.OverlapBoxAll(transform.position, hitboxSize, mask);


        if (colliders.Length > 0)
        {

            _state = ColliderState.Colliding;

            // We should do something with the colliders

        }
        else
        {

            _state = ColliderState.Open;

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(hitboxSize.x * 2, hitboxSize.y * 2)); // Because size is halfExtents

    }

    public enum ColliderState
    {

        Closed,

        Open,

        Colliding

    }

    private void checkGizmoColor()
    {
        switch (_state)
        {

            case ColliderState.Closed:

                Gizmos.color = inactiveColor;

                break;

            case ColliderState.Open:

                Gizmos.color = collisionOpenColor;

                break;

            case ColliderState.Colliding:

                Gizmos.color = collidingColor;

                break;

        }

    }

    public void startCheckingCollision()
    {
        _state = ColliderState.Open;

    }

    public void stopCheckingCollision()
    {
        _state = ColliderState.Closed;

    }
}
