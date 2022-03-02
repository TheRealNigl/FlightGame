/// Title of class:
///     Star
/// Description:
///     Initializes and maintains state of star
///
/// Author: Alex Nigl

using UnityEngine;

public class Star: Collectable
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
    private void Start()
    {
        EnemyStates = EnemyStates.HasNotScored;
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(GameController.Instance.scrollSpeed, 0);
        onDeathParticles = GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
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

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    public void PlayParticle()
    {
        onDeathParticles.Play();
    }
}