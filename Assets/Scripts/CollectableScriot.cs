using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScriot : MonoBehaviour, ICollectable
{
	public void OnCollected()
	{
		GameManager.gameManager.OrbCollected();
		Destroy(gameObject);
	}
}
