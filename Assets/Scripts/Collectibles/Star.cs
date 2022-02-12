/// Title of class:
///     Star
/// Description:
///     Initializes and maintains state of star
///
/// Author: Alex Nigl

using UnityEngine;

public class Star: MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public PlanetStates PlanetStates;
    
    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D body;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        PlanetStates = PlanetStates.HasNotScored;
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(GameController.Instance.scrollSpeed, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if (PlanetStates == PlanetStates.HasNotScored && transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x)
        {
            PlanetStates = PlanetStates.Scored;
        }
        switch (PlanetStates)
        {
            case PlanetStates.Scored:
                GameController.Instance.PlayerScored();
                PlanetStates = PlanetStates.CannotScore;
                Destroy(this.gameObject);
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void PlayParticle()
    {
        GetComponent<ParticleSystem>().Play();
    }
}