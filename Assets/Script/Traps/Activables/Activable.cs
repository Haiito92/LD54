using UnityEngine;

[SerializeField]
public class Activable : MonoBehaviour
{
    [SerializeField] protected bool _isActivated;

    public virtual void Activate() 
    {
    } 
   public virtual void Deactivate()
   {
   }
}
