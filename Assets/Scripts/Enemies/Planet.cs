/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl


using UnityEngine;

public enum PlanetStates
{
    HasNotScored, Scored, CannotScore
}

public class Planet: MonoBehaviour
{
    public PlanetStates PlanetStates;
    private Rigidbody2D body;

    public void Start() 
    {
        PlanetStates = PlanetStates.HasNotScored;
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(GameController.Instance.scrollSpeed, 0);
    }

    public void PlayParticle()
    {
        GetComponent<ParticleSystem>().Play();
    }
    
    public void Update() 
    {
        if (PlanetStates == PlanetStates.HasNotScored && transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x) {
            PlanetStates = PlanetStates.Scored;
        }
        switch (PlanetStates){
            case PlanetStates.Scored:
                GameController.Instance.PlayerScored();
                PlanetStates = PlanetStates.CannotScore;
                break;
        }
    }
}