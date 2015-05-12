using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	private float momentoDoUltimoDisparo;

	[SerializeField]
	private float raioDeAlcance;

	[Range(0, 3)]
	public float tempoDeRecarga = 1f;

	// Use this for initialization
	void Start () 
	{
		Inimigo alvo = EscolheAlvo ();
		if (alvo != null) {
			Atira (alvo);
		}
	}

	void Atira(Inimigo inimigo) 
	{
		float tempoAtual = Time.time;
		if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga) {
			momentoDoUltimoDisparo = tempoAtual;
			GameObject pontoDeDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
			GameObject projetilObject = (GameObject)Instantiate 
				(projetilPrefab, posicaoDoPontoDeDisparo, transform.rotation);
			Missil missil = projetilObject.GetComponent<Missil>();
			missil.DefineAlvo(inimigo);
		}
	}

	void Update()
	{
		Inimigo alvo = EscolheAlvo ();
		if (alvo != null) {
			Atira (alvo);
		}
	}

	private Inimigo EscolheAlvo()
	{
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");
		foreach (GameObject inimigo in inimigos) {
			if (EstaNoRaioDeAlcance(inimigo)) {
				return inimigo.GetComponent<Inimigo>();
			}
		}
		return null;
	}

	private bool EstaNoRaioDeAlcance(GameObject inimigo)
	{
		Vector3 posicaoDoInimigoNoPlano = Vector3.ProjectOnPlane (inimigo.transform.position, Vector3.up);
		Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane (this.transform.position, Vector3.up);

		float distanciaParaInimigo = Vector3.Distance (posicaoDaTorreNoPlano, posicaoDoInimigoNoPlano);

		return distanciaParaInimigo <= raioDeAlcance;
	}
}
