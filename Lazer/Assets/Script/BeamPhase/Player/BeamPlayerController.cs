using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPlayerController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    GameObject beam;

    void Update()
    {
        SpinPlayer();
    }

    /// <summary>
    /// �v���C���[�̉�]�𑀍�
    /// </summary>
    public void SpinPlayer()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public void End()
    {
        beam.SetActive(false);
    }

}
