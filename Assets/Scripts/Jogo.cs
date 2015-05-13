using UnityEngine;
using System.Collections;

public class Jogo : MonoBehaviour {

	[SerializeField]
	private GameObject torrePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ClicouComOBotaoPrimario ()) {
			ConstroiTorre();
		}
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
