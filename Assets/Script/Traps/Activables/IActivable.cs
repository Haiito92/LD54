using UnityEngine;

[SerializeField]
public class Activable : MonoBehaviour
{
    [SerializeField] protected bool _isActivated;

    public virtual void Activate() 
    {
        _isActivated = true;
    } 
   public virtual void Deactivate()
   {
        _isActivated = false;
   }
}
