using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeamPhaseManager : MonoBehaviour
{
    [SerializeField]
    BeamPlayerController playerController;

    /// <summary>�Q�[�W </summary>
    [SerializeField]
    private GameObject Gauge;

    private Slider GaugeSlider;

    float energy;

    float currentEnergy;

    private float generateTimer = 0f;

    public BeamPhaseAsteroidController prefabToSpawn; // ��������I�u�W�F�N�g�̃v���n�u

    public float span = 0.2f; // �ŏ������Ԋu�i�b�j

    private float halfScreenWidth;
    private float halfScreenHeight;

    private float Timer = 0;

    void Awake()
    {
        GaugeSlider = Gauge.GetComponent<Slider>();

        halfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        halfScreenHeight = Camera.main.orthographicSize;

        currentEnergy = energy = PlayerData.energy;
    }

    private void Update()
    {
        // �v���C���[�̉�]�𑀍�
        playerController.SpinPlayer();

        // �A�X�e���C�h�����_������
        GenerateSpan();

        UpdateGauge();

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


    void SpawnObject()
    {
        float randomX = Random.Range(-halfScreenWidth, halfScreenWidth);
        float randomY = Random.Range(-halfScreenHeight, halfScreenHeight);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        BeamPhaseAsteroidController obj = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        obj.Init();
    }


    /// <summary>
    /// �Q�[�W�X�V
    /// </summary>
    public void UpdateGauge()
    {
        GaugeSlider.value = currentEnergy / energy;
    }

    public void minusEnergy()
    {
        Timer += Time.deltaTime;
        if(Timer >= 1f) {
            currentEnergy--;
            Timer = 0f;
        }

        if(currentEnergy < 0)
        {
            playerController.End();
            GameEnd();
        }
    }

    private void GameEnd()
    {
        SceneManager.LoadScene("Result");
    }
}
