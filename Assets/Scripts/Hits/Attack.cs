using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour,IHitboxResponder, IFrameCheckHandler
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

    //Frame Checker
    public FrameChecker frameChecker;

    

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
        frameChecker = new FrameChecker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para uso do ataque
    public void Ataque(int damage, Vector2 position,int duration, int cooldown, int startUp, Vector2 hitboxSize, AnimationClipEX clipEX)
    {
        this.duration = duration;
        this.cooldown = cooldown;
        this.startUp = startUp;
        this.damage = damage;
        this.position = position;
        transform.position = position;
        this.hitboxSize = hitboxSize;
        frameChecker.hitFrameStart = startUp;
        frameChecker.hitFrameEnd = startUp + duration;
        hitbox.SetResponder(this);
        frameChecker.Initialize(this, clipEX);
    }

    //Interface de resposta de hitbox
    public void CollisionedWith(Collider2D collider)
    {
        if (collider.TryGetComponent<Hurtboxes>(out var hurtbox))
            hurtbox.GetHitBy(this);
    }

    //Interface de resposta de frames
    public void OnHitFrameStart()
    {
        hitbox.SetHitbox(hitboxSize);
    }

    public void OnHitFrameEnd()
    {
        hitbox.StopCheckingCollision();
    }

    public void OnLastFrameStart()
    {
       return;
    }

    public void OnLastFrameEnd()
    {
       return;
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
