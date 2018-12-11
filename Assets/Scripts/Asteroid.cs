using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float Speed;
    private Rigidbody2D Body;
    private bool IsDead { get; set; }
    private new AudioSource audio;

    public void Start() {
        Body = GetComponent<Rigidbody2D>();
        Speed = 200f;
        IsDead = true;
        audio = GetComponent<AudioSource>();
    }

    public void Update() {
        if (IsDead) {
            StaticBody();
        }
        if (IsDead && (Input.GetKeyDown("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) {
            Begin();
        }
        if (!IsDead && (Input.GetKeyDown("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) {
            AddForce();
            AddAudio();
        }
        if (!IsDead) {
            DynamicBody();
        }
        if (transform.position.y < -5 || transform.position.y > 5) {
            IsDead = true;
            GameController.Instance.PlayerDied();
        }
    }

    private void Begin() {
        GameController.Instance.GameStart();
        IsDead = false;
    }

    private void AddForce()
    {
        Body.AddForce(Vector2.up * Speed);
    }

    private void AddAudio()
    {
        audio.Play();
    }
    private void StaticBody()
    {
        Body.bodyType = RigidbodyType2D.Kinematic;
        Body.position = Vector2.zero;
    }

    private void DynamicBody()
    {
        Body.bodyType = RigidbodyType2D.Dynamic;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Planet>() != null)
        {
            IsDead = true;
            GameController.Instance.PlayerDied();
        }
    }
}