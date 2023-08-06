
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameOption;

namespace FUTADA
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>���z�R���g���[��</summary>
        [SerializeField]
        private SunController controller;

        /// <summary>�v���C���[�R���g���[��</summary>
        [SerializeField]
        private PlayerController playerController;

        /// <summary>�Q�[���ݒ�</summary>
        [SerializeField]
        private GameOption gameOption;

        // UI�R���g���[���[
        [SerializeField]
        private GameSceneUiController uiController;

        // �A�X�e���C�h�R���g���[���[
        [SerializeField]
        private AsteroidContoller asteroidContoller;

        /// <summary>���z�����ύX���Ԍv</summary>
        private float changeTime;

        /// <summary>�Q�[������ </summary>
        private float gameTime;

        /// <summary>�A�X�e���C�h�����^�C�}�[</summary>
        private float generateTimer = 0;

        private float sunSizeTimer = 0f;

        /// <summary>�A�X�e���C�h�����|�C���g���X�g</summary>
        List<spawnPoint> point;

        /// <summary>
        ///  ���b�̑��z�̏k���l
        ///  ���z�̃X�P�[�� / �Q�[������
        /// </summary>
        private float minusScale;


        private float halfScreenHeight;

        // Start is called before the first frame update
        void Awake()
        {
            // ���z�̏�����
            controller.Init();

            // �v���C���[�̏�����
            playerController.Init();

            // ui�̏�����
            uiController.Init(playerController.GetMaxEnergy());

            // ���z�����ύX���Ԃ̏�����
            changeTime = controller.GetTimeSpan();

            // �Q�[�����ԏ�����
            gameTime = gameOption.GetGameTime();

            // �A�X�e���C�h�����|�C���g���X�g�擾
            point = gameOption.GetSpawnPoint();

            // �k���l�v�Z
            Debug.Log($"scale {controller.GetSunSize()}");
            minusScale = controller.GetSunSize() / gameTime;

            halfScreenHeight = Camera.main.orthographicSize;

        }

        // Update is called once per frame
        void Update()
        {
            // ���z���̌����ύX
            SunLightVectorChange();

            // ���z����������
            controller.SunLightMove();

            // �v���C���[����
            PlayerMove(Time.deltaTime);

            // �Q�[�����ԍX�V
            UpdateGameTime(Time.deltaTime);

            // �Q�[�W�X�V
            uiController.UpdateGauge(playerController.GetCurrentEnergy());

            // �A�X�e���C�h����
            GenerateAsteroidSpan();

            // ���z�̃T�C�Y�X�V 
            UpdateSunSize();

            // �f�o�b�O
            DebugLog();

        }

        private void SunLightVectorChange()
        {
            // ���z���f����������ύX���Ԃ��擾���đ���
            changeTime += Time.deltaTime;
            if (changeTime >= controller.GetTimeSpan())
            {
                changeTime = 0f;
                controller.ChangeVector();
            }
        }

        /// <summary>
        /// �v���C���[�ړ�
        /// </summary>
        private void PlayerMove(float time)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerController.PlayerMove(time,SunVector.LEFT);
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerController.PlayerMove(time, SunVector.RIGHT);
            }
        }

        /// <summary>
        /// �Q�[�����ԍX�V
        /// </summary>
        /// <param name="time"></param>
        private void UpdateGameTime(float time)
        {
            gameTime -= time;

            // �Q�[�����Ԑ؂�
            if(gameTime < 0f)
            {
                EndChargePhase();
            }
        }

        /// <summary>
        ///  �Q�[���I������
        /// </summary>
        private void EndChargePhase()
        {
            // �G�l���M�[�ۑ�
            PlayerData.energy = playerController.GetCurrentEnergy();
            SceneManager.LoadScene("BeamPhaseScene");
        }

        // �f�o�b�O���O
        private void DebugLog()
        {
            Debug.Log($"GameTime : {gameTime}");
        }

        /// <summary>
        /// ��莞�Ԃ��ƂɃA�X�e���C�h�𐶐�����֐������s
        /// </summary>
        private void GenerateAsteroidSpan()
        {
            // �A�X�e���C�h�̐����Ԋu���擾
            float generateSpan = gameOption.GetAsteroidSpan();
            generateTimer += Time.deltaTime;

            // �������Ԍo�߂Ő���
            if(generateTimer >= generateSpan)
            {
                SpawnObject();
                generateTimer = 0;
            }

        }

        /// <summary>
        /// �A�X�e���C�h�̐���
        /// </summary>
        void SpawnObject()
        {
            float randomY;
            Vector3 spawnPosition;

            float randomValue = Random.value; // 0����1�̃����_���Ȑ��l���擾

            randomY =  Random.Range(-halfScreenHeight, halfScreenHeight);

            int adjust = -1;
            spawnPosition = new Vector3(adjust *= 10, randomY, 0f); 

            for(int i = 0; i < 3; i++)
            {
                AsteroidContoller spawnedObject = Instantiate(asteroidContoller, spawnPosition, Quaternion.identity);
                spawnedObject.Init();
            }
        }

        /// <summary>
        /// ���z�̃T�C�Y�X�V
        /// </summary>
        private void UpdateSunSize()
        {
            sunSizeTimer += Time.deltaTime;

            if (sunSizeTimer > 1f)
            {

                // ���z�̃T�C�Y�X�V
                controller.UpdateSunSize(minusScale);

                sunSizeTimer = 0f;
            }
        }
    }
}
