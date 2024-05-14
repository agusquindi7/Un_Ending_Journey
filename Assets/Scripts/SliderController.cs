using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private CheloEnemyLife cEnemyLife;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        cEnemyLife = cEnemyLife.GetComponentInParent<CheloEnemyLife>();
    }
    void Update()
    {
        UpdateEnemyHealth( cEnemyLife._objectLife, cEnemyLife.objectMaxLife);
        if (_slider.value <= 0) Destroy(this.gameObject);
    }

    void UpdateEnemyHealth (float currentValue, float maxValue)
    {
        _slider.value = currentValue / maxValue;
    }


}
