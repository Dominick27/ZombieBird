using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tuberias : MonoBehaviour
{

    [SerializeField] private int speed = 3;
    [SerializeField] float limiteInf = -1;
    [SerializeField] float limiteSup = 1;
    [SerializeField] float distanciadestruccion = 20;
    void Start()
    {
        float factorPosicion = Random.Range(limiteInf, limiteSup);
        this.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + factorPosicion,
            transform.position.z);
    }

    void Update() {
        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < -20)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
    