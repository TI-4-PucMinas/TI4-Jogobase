using UnityEngine;

public class Hurtboxes : MonoBehaviour
{

    public Collider2D colisor;

    private Vector2 hurtboxSize;

    private Player player;

    private void Start()
    {
        hurtboxSize = transform.parent.lossyScale.normalized;
        hurtboxSize.y += 0.5f;
        colisor = Physics2D.OverlapBox(transform.parent.transform.position, hurtboxSize, 0);
        player = GetComponentInParent<Player>();
    }

    public bool GetHitBy(Attack attack)
    {
        if (player != null)
        {
            player.TomarDano(attack.damage);
            return true;
        }
        return false;
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.matrix = Matrix4x4.TRS(colisor.transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector2.zero, new Vector2(hurtboxSize.x * 2, hurtboxSize.y * 2)); // Because size is halfExtents

    }

    public void Crouch()
    {
        hurtboxSize.y /= 2;
        colisor = Physics2D.OverlapBox(transform.parent.transform.position, hurtboxSize, 0);
    }

    public void Stand()
    {
        hurtboxSize.y *= 2;
        colisor = Physics2D.OverlapBox(transform.parent.transform.position, hurtboxSize, 0);
    }


}
