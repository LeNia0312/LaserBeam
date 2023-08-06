
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameOption;

namespace FUTADA
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>太陽コントローラ</summary>
        [SerializeField]
        private SunController controller;

        /// <summary>プレイヤーコントローラ</summary>
        [SerializeField]
        private PlayerController playerController;

        /// <summary>ゲーム設定</summary>
        [SerializeField]
        private GameOption gameOption;

        // UIコントローラー
        [SerializeField]
        private GameSceneUiController uiController;

        // アステロイドコントローラー
        [SerializeField]
        private AsteroidContoller asteroidContoller;

        /// <summary>太陽向き変更時間計</summary>
        private float changeTime;

        /// <summary>ゲーム時間 </summary>
        private float gameTime;

        /// <summary>アステロイド生成タイマー</summary>
        private float generateTimer = 0;

        private float sunSizeTimer = 0f;

        /// <summary>アステロイド生成ポイントリスト</summary>
        List<spawnPoint> point;

        /// <summary>
        ///  毎秒の太陽の縮小値
        ///  太陽のスケール / ゲーム時間
        /// </summary>
        private float minusScale;


        private float halfScreenHeight;

        // Start is called before the first frame update
        void Awake()
        {
            // 太陽の初期化
            controller.Init();

            // プレイヤーの初期化
            playerController.Init();

            // uiの初期化
            uiController.Init(playerController.GetMaxEnergy());

            // 太陽向き変更時間の初期化
            changeTime = controller.GetTimeSpan();

            // ゲーム時間初期化
            gameTime = gameOption.GetGameTime();

            // アステロイド生成ポイントリスト取得
            point = gameOption.GetSpawnPoint();

            // 縮小値計算
            Debug.Log($"scale {controller.GetSunSize()}");
            minusScale = controller.GetSunSize() / gameTime;

            halfScreenHeight = Camera.main.orthographicSize;

        }

        // Update is called once per frame
        void Update()
        {
            // 太陽光の向き変更
            SunLightVectorChange();

            // 太陽光うごかす
            controller.SunLightMove();

            // プレイヤー操作
            PlayerMove(Time.deltaTime);

            // ゲーム時間更新
            UpdateGameTime(Time.deltaTime);

            // ゲージ更新
            uiController.UpdateGauge(playerController.GetCurrentEnergy());

            // アステロイド生成
            GenerateAsteroidSpan();

            // 太陽のサイズ更新 
            UpdateSunSize();

            // デバッグ
            DebugLog();

        }

        private void SunLightVectorChange()
        {
            // 太陽モデルから向き変更時間を取得して測る
            changeTime += Time.deltaTime;
            if (changeTime >= controller.GetTimeSpan())
            {
                changeTime = 0f;
                controller.ChangeVector();
            }
        }

        /// <summary>
        /// プレイヤー移動
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
        /// ゲーム時間更新
        /// </summary>
        /// <param name="time"></param>
        private void UpdateGameTime(float time)
        {
            gameTime -= time;

            // ゲーム時間切れ
            if(gameTime < 0f)
            {
                EndChargePhase();
            }
        }

        /// <summary>
        ///  ゲーム終了処理
        /// </summary>
        private void EndChargePhase()
        {
            // エネルギー保存
            PlayerData.energy = playerController.GetCurrentEnergy();
            SceneManager.LoadScene("BeamPhaseScene");
        }

        // デバッグログ
        private void DebugLog()
        {
            Debug.Log($"GameTime : {gameTime}");
        }

        /// <summary>
        /// 一定時間ごとにアステロイドを生成する関数を実行
        /// </summary>
        private void GenerateAsteroidSpan()
        {
            // アステロイドの生成間隔を取得
            float generateSpan = gameOption.GetAsteroidSpan();
            generateTimer += Time.deltaTime;

            // 生成時間経過で生成
            if(generateTimer >= generateSpan)
            {
                SpawnObject();
                generateTimer = 0;
            }

        }

        /// <summary>
        /// アステロイドの生成
        /// </summary>
        void SpawnObject()
        {
            float randomY;
            Vector3 spawnPosition;

            float randomValue = Random.value; // 0から1のランダムな数値を取得

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
        /// 太陽のサイズ更新
        /// </summary>
        private void UpdateSunSize()
        {
            sunSizeTimer += Time.deltaTime;

            if (sunSizeTimer > 1f)
            {

                // 太陽のサイズ更新
                controller.UpdateSunSize(minusScale);

                sunSizeTimer = 0f;
            }
        }
    }
}
