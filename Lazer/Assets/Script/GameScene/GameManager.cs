
using UnityEngine;

namespace FUTADA
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// 太陽コントローラ
        /// </summary>
        [SerializeField]
        private SunController controller;

        [SerializeField]
        private PlayerController playerController;


        // Start is called before the first frame update
        void Awake()
        {
            // コントローラの初期化
            controller.Init();

            playerController.Init();

        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Init()
        {
            
        }


        // Update is called once per frame
        void Update()
        {
            // 太陽光うごかす
            controller.SunLightMove();


            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log($"call");
                PlayerMove(Time.deltaTime);
            }
        }

        /// <summary>
        /// プレイヤー移動
        /// </summary>
        private void PlayerMove(float time)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playerController.PlayerMove(time);
                System.Diagnostics.Debug.Print("call");
            }
        }
    }
}
