using FUTADA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidContoller : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>�p���[(��)</summary>
    [SerializeField]
    private float power;


    [SerializeField]
    private BoomController boom;

    /// <summary>model</summary>
    private AsteroidModel model;

    private float halfScreenHeight;

    public void Awake()
    {
        model = new AsteroidModel(moveSpeed, power);
        model.SetVector(CheckVector());
    }

    public void Init()
    {
        this.gameObject.SetActive(true);

        halfScreenHeight = Camera.main.orthographicSize;
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    public void UpdateMove()
    {
        SunVector vector = model.GetVector();
        float speed = model.GetSpeed();

        switch (vector)
        {
            case SunVector.RIGHT:
                // �E�����Ɉړ�
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;

                case SunVector.LEFT:
                // �������Ɉړ�
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
        }
       
    }

    private void Update()
    {
        UpdateMove();

        CheckForOutOfBoundsObjects();
    }

    /// <summary>
    /// �i�s����������
    /// �������ꂽ���W�ɂ���ĕύX����
    /// </summary>
    /// <returns></returns>
    private SunVector CheckVector()
    {
        SunVector vec = SunVector.LEFT;

        if(this.gameObject.transform.position.x < 0)
        {
            vec = SunVector.RIGHT;
        }

        return vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "player")
        {
            // �΂��Ӂ[
            var obj = Instantiate(boom, this.transform.position, Quaternion.identity);
            obj.Init();

            // �v���C���[
            Destroy(this.gameObject);

        }
    }

    void CheckForOutOfBoundsObjects()
    {
        if (this.transform.position.y < -halfScreenHeight)
        {
            Destroy(this.gameObject);
        }
        
    }
}
