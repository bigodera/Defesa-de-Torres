using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	[SerializeField] 
	private int vida;

	// Use this for initialization
	void Start () {
		NavMeshAgent agente = GetComponent<NavMeshAgent> ();
		GameObject fimDoCaminho = GameObject.Find ("FimDoCaminho");
		Vector3 posicaoDoFimDoCaminho = fimDoCaminho.transform.position;
		agente.SetDestination ( posicaoDoFimDoCaminho );
	}

	public void RecebeDano(int pontosDeDano)
	{
		vida -= pontosDeDano;
		if (vida <= 0) {
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
