using UnityEngine;

public class Grounded : MonoBehaviour
{
    [SerializeField] private Movement movement;
    private int layer;

    private void Awake()
    {
        layer = LayerMask.NameToLayer("ground");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer)
        {
            movement.ChangeGround(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layer)
        {
            movement.ChangeGround(false);
        }
    }
}
