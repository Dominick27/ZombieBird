using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
    [SerializeField] ParticleSystem prefabblood;
    [SerializeField] float fuerza = 8f;
    [SerializeField] Text score;

    private Rigidbody rb;
    private int puntuacion = 0;


	// Use this for initialization
	void Start ()
    {
        GameConfig.ArrancaJuego();
        rb = GetComponent<Rigidbody>();
        ActualizarScore();
    }

    
    // Update is called once per frame


    void Update () {
		if (Input.GetKeyDown("space"))
         {
             rb.AddForce(Vector3.up * fuerza);

            /*rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, fuerza, 0)); */

            //Debug.Log("Ha pulsado space");
        }
	}

    private void OnTriggerEnter(Collider other){
        //Debug.Log("ha pasado");
        puntuacion++;
        ActualizarScore();
        //Debug.Log("Score: " + puntuacion);
        
    }
    private void OnCollisionEnter(Collision collision) {

        //DETEN EL JUEGO

        GameConfig.ParaJuego();

        //CREAR SISTEMA DE PARTICULAS
        Instantiate(prefabblood, transform.position, Quaternion.identity);

        // DESACTIVAR EL RENDER
        gameObject.SetActive(false);

        //LLAMAR A FINALIZAR PARTIDA
        Invoke("FinalizarPartida", 2.5f);

    }
    private void FinalizarPartida() {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }
    private void ActualizarScore()
    {
        score.text = "Score: " + puntuacion.ToString();
    }
}

