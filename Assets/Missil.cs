using UnityEngine;
using System.Collections;

public class Missil : MonoBehaviour {

	[Range(0, 5)]
	private float velocidade = 10;

	[SerializeField]
	private int pontosDeDano;
	
	private GameObject alvo;

	// Use this for initialization
	void Start () {
		alvo = GameObject.Find ("Inimigo");	
		AutoDestroiDepoisDeSegundos (10);
	}

	private void AutoDestroiDepoisDeSegundos(float segundos)
	{
		Destroy (this.gameObject, segundos);
	}
	
	// Update is called once per frame
	void Update () {
		Anda ();
		if (alvo != null) {
			AlteraDirecao ();
		}
	}

	private void Anda()
	{
		Vector3 posicaoAtual = transform.position;

		Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
		transform.position = posicaoAtual + deslocamento;
	}

	private void AlteraDirecao ()
	{
		Vector3 posicaoAtual = transform.position;

		Vector3 posicaoDoAlvo = alvo.transform.position;

		Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual;
		transform.rotation = Quaternion.LookRotation (direcaoDoAlvo);
	}

	void OnTriggerEnter(Collider elementoColidido)
	{
		if (elementoColidido.CompareTag("Inimigo"))
	    {
			Destroy (this.gameObject);
			Inimigo inimigo = elementoColidido.GetComponent<Inimigo>();
			inimigo.RecebeDano(pontosDeDano);
		}
	}


}
	