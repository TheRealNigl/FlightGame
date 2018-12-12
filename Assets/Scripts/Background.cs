using UnityEngine;

public class Background : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    
	void Awake ()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;

        transform.position = Vector2.zero;
    }
}