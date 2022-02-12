/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl


using UnityEngine;

public class Background : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private BoxCollider2D groundCollider;

    /// <summary>
    /// 
    /// </summary>
    private float groundHorizontalLength;
    
    /// <summary>
    /// 
    /// </summary>
	void Awake ()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;

        transform.position = Vector2.zero;
    }
}