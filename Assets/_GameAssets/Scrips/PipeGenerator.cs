using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour {

    [SerializeField] Transform prefabTuberia;
    [SerializeField] float ratioGeneracionTuberias = 0.75f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("GeneratePipe", 0, ratioGeneracionTuberias);
	}
	
	// Update is called once per frame

	void GeneratePipe () {
        //Debug.Log("tuberia");

        // GENERAMOS TUBERIAS
        if (GameConfig.IsPlaying())
        {
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);
        }
	}
  }
