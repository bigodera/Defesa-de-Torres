using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	[SerializeField] 

	private int vida;
	public int GetVida () {
		return vida;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PerdeVida()
	{
		vida--;
	}
}
