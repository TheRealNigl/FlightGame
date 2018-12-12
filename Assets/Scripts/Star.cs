using UnityEngine;

public class Star: MonoBehaviour
{
    private Rigidbody2D Body { get; set; }

    private void Awake() {
        Body = GetComponent<Rigidbody2D>();
    }

    public void AddForceWithDirection(Vector2 direction) {
        Body.AddForce(direction);
    }

    public void AddForceWithDirectionAndSpeed(Vector2 direction, float speed) {
        Body.AddForce(direction * speed);
    }

    private void SetPosition(){
        Body.position = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }
}