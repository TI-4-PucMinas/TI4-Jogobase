using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;


public interface IHitboxResponder
{

    void CollisionedWith(Collider2D collider);

}

public class Hitboxes : MonoBehaviour
{
    public LayerMask mask;

    public bool useSphere = false;

    private Vector2 hitboxSize = Vector2.zero;

    private Attack ataques;

    private Vector2 position;

    public float radius = 0f;

    public Color inactiveColor;

    public Color collisionOpenColor;

    public Color collidingColor;

    private Collider2D[] colliders;

    private IHitboxResponder _responder = null;


    private ColliderState _state;

    private void Start()
    {
        position = transform.parent.position;
        if (useSphere)
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, radius, mask);
        }
        else
        {
            colliders = Physics2D.OverlapBoxAll(transform.position, hitboxSize, mask);
        }
        gameObject.SetActive(false);
        ataques = GetComponentInParent<Attack>();

    }

    public void HitboxUpdate()
    {
       
        if (_state == ColliderState.Closed) { return; }

        if(!useSphere)
            colliders = Physics2D.OverlapBoxAll(position, hitboxSize, mask);
        else
            colliders = Physics2D.OverlapCircleAll(position, radius, mask);


        for (int i = 0; i < colliders.Length; i++)
        {

            Collider2D aCollider = colliders[i];

            _responder?.CollisionedWith(aCollider);

        }


        _state = colliders.Length > 0 ? ColliderState.Colliding : ColliderState.Open;

    }

    public enum ColliderState
    {

        Closed,

        Open,

        Colliding

    }

    public void StartCheckingCollision()
    {
        _state = ColliderState.Open;

    }

    public void StopCheckingCollision()
    {
        _state = ColliderState.Closed;

    }

    public void SetResponder(IHitboxResponder responder)
    {
        _responder = responder;
        
    }

    public void SetHitbox(Vector2 hitboxSize)
    {
        this.hitboxSize = hitboxSize;
        gameObject.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector2.zero, new Vector2(hitboxSize.x * 2, hitboxSize.y * 2)); // Because size is halfExtents

    }

    private void CheckGizmoColor()
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
}
