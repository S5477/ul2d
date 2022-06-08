using UnityEngine;

public class LayerCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    private Collider2D _collider;

    public bool IsTouchingLayer;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TouchCollider(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TouchCollider(other);
    }

    private void TouchCollider(Collider2D other)
    {
        IsTouchingLayer = _collider.IsTouchingLayers(_layer);
    }
}
