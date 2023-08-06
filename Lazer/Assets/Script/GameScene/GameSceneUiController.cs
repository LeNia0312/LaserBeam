using UnityEngine;
using UnityEngine.UI;

public class GameSceneUiController : MonoBehaviour
{
    /// <summary>ゲージ </summary>
    [SerializeField]
    private GameObject Gauge;

    /// <summary>最大エネルギー </summary>
    private float maxEnergy;

    private Slider GaugeSlider;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="max"></param>
    public void Init(float max)
    {
        this.maxEnergy = max;
        GaugeSlider = Gauge.GetComponent<Slider>();
       // GaugeSlider.maxValue = maxEnergy;

    }

    /// <summary>
    /// ゲージ更新
    /// </summary>
    /// <param name="energy"></param>
    public void UpdateGauge(float energy)
    {
        GaugeSlider.value = energy / maxEnergy;
        Debug.Log($"gauge update");
    }
}
