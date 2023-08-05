
using UnityEngine;

namespace FUTADA
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// ���z�R���g���[��
        /// </summary>
        [SerializeField]
        private SunController controller;

        [SerializeField]
        private PlayerController playerController;


        // Start is called before the first frame update
        void Awake()
        {
            // �R���g���[���̏�����
            controller.Init();

            playerController.Init();

        }

        /// <summary>
        /// ������
        /// </summary>
        private void Init()
        {
            
        }


        // Update is called once per frame
        void Update()
        {
            // ���z����������
            controller.SunLightMove();


            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log($"call");
                PlayerMove(Time.deltaTime);
            }
        }

        /// <summary>
        /// �v���C���[�ړ�
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
