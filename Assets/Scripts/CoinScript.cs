using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour, ICollectable
{
	public void OnCollected()
	{
		GameManager.gameManager.CoinCollected();
		Destroy(gameObject);
	}
}
