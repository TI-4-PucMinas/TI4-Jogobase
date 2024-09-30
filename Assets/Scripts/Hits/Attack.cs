using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour,IHitboxResponder
{
    //Propriedades de interação do ataque
    public AttackBlock attackBlock;
    public AttackRange attackRange;
    public AttackWeight attackWeight;

    //Hitbox do ataque
    public Hitboxes hitbox;
    public Vector2 hitboxSize;
    public float hitboxRadius;
    public Vector2 position;

    //Dano do ataque
    public int damage;
    //Duração do ataque
    public int duration;
    //Tempo de recarga do ataque
    public int cooldown;
    //Tempo de início do ataque
    public int startUp;
    //Velocidade do ataque se projétil
    public float projectile_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ataque(int damage, Vector2 position)
    {
        this.damage = damage;
        this.position = position;
        hitbox.SetResponder(this);
    }

    public void CollisionedWith(Collider2D collider)
    {
        if (collider.TryGetComponent<Hurtboxes>(out var hurtbox))
            hurtbox.GetHitBy(this);
    }

    //Enums para os tipos de ataques
    public enum AttackBlock
    {
        Low,
        Medium, 
        High
    }

    public enum AttackRange
    {
        Physical,
        Projectile,
    }

    public enum AttackWeight
    {
        Weak,
        Medium,
        Strong,
        SuperStrong,
    }
}
