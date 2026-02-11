using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth: MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabilityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f; 

    float currentHealth;
    float invulnerabilityTimer;

    SpriteRenderer sprite;
    float blinkTimer;
    bool blinking;

    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>(); //GetComponent is a function hence the "()"
    }
    void Update()
    {
        if(invulnerabilityTimer > 0f )
        {
            invulnerabilityTimer-=Time.deltaTime; //countdown code
            HandleBlink();

        }
    }
    
    public bool ApplyDamage(float amount) // from IDamageable function
    {
        if(currentHealth <=0f || invulnerabilityTimer > 0f)
        return false;

        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            Die();
            return true;

        }
        invulnerabilityTimer = invulnerabilityDuration;
        StartBlink(invulnerabilityDuration);
        return true;
    }
    void StartBlink (float duration)
    {

    }
    void HandleBlink()
    {
        if(!blinking)
         {
            return;
        }
        blinkTimer -= Time.deltaTime;
        if(blinkTimer <= 0f)
        {
            blinking = false;
            sprite.enabled = true;
            return;

        }
        sprite.enabled =
        Mathf.FloorToInt(blinkTimer/blinkInterval) % 2 ==0;
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}