/// Title of class:
///     Asteroid
///     
/// Description:
///     Controls player state and movement
///
/// Author: Alex Nigl


using UnityEngine;

public class Asteroid : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private float Speed;

    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D Body;

    /// <summary>
    /// 
    /// </summary>
    private bool IsDead { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private new AudioSource audio;

    /// <summary>
    /// 
    /// </summary>
    public void Start() 
    {
        Body = GetComponent<Rigidbody2D>();
        Speed = 200f;
        IsDead = true;
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Update() 
    {
        if (IsDead) 
        {
            StaticBody();
        }
        if (IsDead && (Input.GetKeyDown("space") || 
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) 
        {
            Begin();
        }
        if (!IsDead && (Input.GetKeyDown("space") || 
            (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) 
        {
            AddForce();
            AddAudio();
        }
        if (!IsDead) 
        {
            DynamicBody();
        }
        if (transform.position.y < -5 || transform.position.y > 5) 
        {
            IsDead = true;
            GameController.Instance.PlayerDied();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Begin() 
    {
        GameController.Instance.StartGame();
        IsDead = false;
    }

    /// <summary>
    /// 
    /// </summary>
    private void AddForce()
    {
        Body.velocity = Vector2.zero;
        Body.AddForce(Vector2.up * Speed);
    }

    /// <summary>
    /// 
    /// </summary>
    private void AddAudio()
    {
        audio.Play();
    }

    /// <summary>
    /// 
    /// </summary>
    private void StaticBody()
    {
        Body.bodyType = RigidbodyType2D.Kinematic;
        Body.position = Vector2.zero;
    }

    /// <summary>
    /// 
    /// </summary>
    private void DynamicBody()
    {
        Body.bodyType = RigidbodyType2D.Dynamic;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Planet>() != null)
        {
            IsDead = true;
            GameController.Instance.PlayerDied();
        }
    }
}