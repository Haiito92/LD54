using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    #region Properties
    public bool IsActivated
    {
        get { return _isActivated; }
        set 
        { 
            _isActivated = value;
            if (_isActivated)
            {
                _fillingEnergy = FillingEnergy();
                StartCoroutine(_fillingEnergy);
            }
            else if (!_isActivated)
            { 
                if(_fillingEnergy != null)
                {
                    StopFillingEnergy();
                    _activable.Deactivate();
                }
            }
        }
    }
    public float EnergyLevel
    {
        get { return _energyLevel; }
        set 
        { 
            _energyLevel = value; 
            if (_energyLevel >= 100)
            {
                _activable.Activate();
            }
        }
    }
    #endregion

    #region IEnumeratoHolders
    private IEnumerator _fillingEnergy;
    #endregion
    
    [SerializeField] private bool _isActivated;

    [SerializeField] private float _maxEnergyLevel = 100;
    [SerializeField] private float _energyLevel = 0;


    [SerializeField] private float _fillValue;
    [SerializeField] private float _fillRate;

    [SerializeField] private Activable _activable;

    private void Awake()
    {
        EnergyLevel = 0;
    }

    private IEnumerator FillingEnergy()
    {
        while (_isActivated)
        {
            EnergyLevel = Mathf.Clamp(_energyLevel += _fillValue, 0, _maxEnergyLevel);
            yield return new WaitForSeconds(1/_fillRate);
        }
        yield return null;
    }

    private void StopFillingEnergy()
    {
        StopCoroutine(_fillingEnergy);
    }
}
