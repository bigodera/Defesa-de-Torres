using UnityEngine;
using System.Collections;

public class Jogo : MonoBehaviour {

	[SerializeField]
	private GameObject torrePrefab;

	[SerializeField]
	private GameObject gameOver;

	[SerializeField]
	private Jogador jogador;

	// Use this for initialization
	void Start () {
		gameOver.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (JogoAcabou ()) {
			gameOver.SetActive (true);
		} else {
			if (ClicouComOBotaoPrimario ()) {
				ConstroiTorre ();
			}
		}
	}

	private bool JogoAcabou() 
	{
		return !jogador.EstaVivo ();
	}

	private void ConstroiTorre()
	{
		Vector3 posicaoDoClique = Input.mousePosition;
		RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto (posicaoDoClique);
		if (elementoAtingidoPeloRaio.collider != null) {
			Vector3 posicaoDoElemento = elementoAtingidoPeloRaio.point;
			Instantiate(torrePrefab, posicaoDoElemento, Quaternion.identity);
		}
	}

	private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 ponto)
	{
		Ray raio = Camera.main.ScreenPointToRay (ponto);
		RaycastHit elementoAtingidoPeloRaio;
		float comprimentoMaximoDoRaio = 100.0f;
		Physics.Raycast (raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);
		return elementoAtingidoPeloRaio;
	}

	private bool ClicouComOBotaoPrimario()
	{
		return Input.GetMouseButtonDown(0);
	}
}
