/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl


using UnityEngine;

public class Planet: Enemy
{
    /// <summary>
    /// 
    /// </summary>
    public EnemyStates EnemyStates;

    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D body;

    /// <summary>
    /// 
    /// </summary>
    private ParticleSystem onDeathParticles;

    /// <summary>
    /// 
    /// </summary>
    public void Start() 
    {
        EnemyStates = EnemyStates.HasNotScored;
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(GameController.Instance.scrollSpeed, 0);
        onDeathParticles = GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Player":
                ToggleEnemy();
                break;
            case "Finish":
                ToggleEnemy();
                break;
            default:
                break;
        }
    }

    private void ToggleEnemy()
    {
        switch (EnemyStates)
        {
            case EnemyStates.Scored:
                EnemyStates = EnemyStates.CannotScore;
                PlayParticle();
                break;
            case EnemyStates.HasNotScored:
                Destroy(gameObject);
                break;
        }
    }

    public void PlayParticle()
    {
        onDeathParticles.Play();
    }
}