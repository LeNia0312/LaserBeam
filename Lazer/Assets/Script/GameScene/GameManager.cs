
using UnityEngine;

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

        /// <summary>太陽向き変更時間計</summary>
        private float changeTime;
    
        // Start is called before the first frame update
        void Awake()
        {
            // 太陽の初期化
            controller.Init();

            // プレイヤーの初期化
            playerController.Init();

            // 太陽向き変更時間の初期化
            changeTime = controller.GetTimeSpan();

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
    }
}
