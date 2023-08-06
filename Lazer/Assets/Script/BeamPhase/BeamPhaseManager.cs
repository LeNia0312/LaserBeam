using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeamPhaseManager : MonoBehaviour
{
    [SerializeField]
    BeamPlayerController playerController;

    /// <summary>ゲージ </summary>
    [SerializeField]
    private GameObject Gauge;

    /// <summary>ゲージ(Sliderコンポーネント) </summary>
    private Slider GaugeSlider;

    /// <summary>チャージしたエネルギー</summary>
    float energy;

    /// <summary>現在のエネルギー</summary>
    float currentEnergy;

    /// <summary>アステロイドの生成タイマー</summary>
    private float generateTimer = 0f;

    /// <summary>アステロイドのコントローラ</summary>
    public BeamPhaseAsteroidController prefabToSpawn; // 生成するオブジェクトのプレハブ

    /// <summary>アステロイドの生成間隔(別クラスにしたかった)</summary>
    public float span = 0.2f;

    /// <summary>画面の横幅</summary>
    private float halfScreenWidth;

    /// <summary>画面の縦幅</summary>
    private float halfScreenHeight;

    /// <summary>エネルギー減らしタイマー</summary>
    private float Timer = 0;

    void Awake()
    {
        // コンポーネント取得(最初からSliderでシリアライズ化したほうがいい)
        GaugeSlider = Gauge.GetComponent<Slider>();

        // 画面の縦横幅取得
        halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        halfScreenHeight = Camera.main.orthographicSize;

        // チャージフェーズで貯めたエネルギーを保持クラスから取得
        currentEnergy = energy = PlayerData.energy;
    }

    private void Update()
    {
        // プレイヤーの回転を操作
        playerController.SpinPlayer();

        // アステロイドランダム生成
        GenerateSpan();

        // エネルギーゲージの更新
        UpdateGauge();

        // エネルギーを毎秒減らす
        minusEnergy();

    }

    
    private void GenerateSpan()
    {
        generateTimer += Time.deltaTime;

        if(generateTimer > span)
        {
            SpawnObject();
            generateTimer = 0f;
        }
    }

    /// <summary>
    /// 出現間隔に応じてアステロイドを生成
    /// </summary>
    void SpawnObject()
    {
        // 画面内の全体からランダムな出現ポイントを生成
        float randomX = Random.Range(-halfScreenWidth, halfScreenWidth);
        float randomY = Random.Range(-halfScreenHeight, halfScreenHeight);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        // アステロイドの生成と初期化
        BeamPhaseAsteroidController obj = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        obj.Init();
    }

    /// <summary>
    /// ゲージ更新
    /// </summary>
    public void UpdateGauge()
    {
        GaugeSlider.value = currentEnergy / energy;
    }

    // エネルギーを減らす
    public void minusEnergy()
    {
        Timer += Time.deltaTime;
        if(Timer >= 1f) {
            currentEnergy--;
            Timer = 0f;
        }

        // エネルギーが切れたらゲーム終了
        if(currentEnergy < 0)
        {
            playerController.End();
            GameEnd();
        }
    }

    // ゲーム終了時に呼ばれる
    private void GameEnd()
    {
        // リザルトシーンへ移動
        SceneManager.LoadScene("Result");
    }
}
