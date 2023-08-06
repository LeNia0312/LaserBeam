using UnityEngine;
using UnityEngine.UI;

public class GameSceneUiController : MonoBehaviour
{
    /// <summary>�Q�[�W </summary>
    [SerializeField]
    private GameObject Gauge;

    /// <summary>�ő�G�l���M�[ </summary>
    private float maxEnergy;

    private Slider GaugeSlider;

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="max"></param>
    public void Init(float max)
    {
        this.maxEnergy = max;
        GaugeSlider = Gauge.GetComponent<Slider>();
       // GaugeSlider.maxValue = maxEnergy;

    }

    /// <summary>
    /// �Q�[�W�X�V
    /// </summary>
    /// <param name="energy"></param>
    public void UpdateGauge(float energy)
    {
        GaugeSlider.value = energy / maxEnergy;
        Debug.Log($"gauge update");
    }
}
