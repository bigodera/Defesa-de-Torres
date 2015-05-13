using UnityEngine;
using System.Collections;

public class DetectorDeCruzamento : MonoBehaviour {

	[SerializeField] 
	private Jogador jogador;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) 
	{
		Debug.Log ("chegou no fim do caminho!");
		Destroy (collider.gameObject);
		jogador.PerdeVida ();
	}

}
