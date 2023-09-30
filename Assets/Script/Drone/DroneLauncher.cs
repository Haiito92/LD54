using UnityEngine;
using UnityEngine.InputSystem;

public class DroneLauncher : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    [SerializeField] private Drone _drone;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _drone = GetComponentInChildren<Drone>();
    }

    public void LaunchDrone(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            _drone.MoveDrone(mouseWorldPos);
        }
        
    }
}
