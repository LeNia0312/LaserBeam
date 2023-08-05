
using UnityEngine;

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

        /// <summary>���z�����ύX���Ԍv</summary>
        private float changeTime;
    
        // Start is called before the first frame update
        void Awake()
        {
            // ���z�̏�����
            controller.Init();

            // �v���C���[�̏�����
            playerController.Init();

            // ���z�����ύX���Ԃ̏�����
            changeTime = controller.GetTimeSpan();

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
    }
}
