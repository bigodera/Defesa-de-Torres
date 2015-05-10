using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	private float momentoDoUltimoDisparo;

	[Range(0, 3)]
	public float tempoDeRecarga = 1f;

	// Use this for initialization
	void Start () 
	{
		Atira ();
	}

	void Atira() 
	{
		float tempoAtual = Time.time;
		if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga) {
			momentoDoUltimoDisparo = tempoAtual;
			GameObject pontoDeDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
			Instantiate (projetilPrefab, posicaoDoPontoDeDisparo, transform.rotation);
		}
	}

	void Update()
	{
		Atira ();
	}
}
