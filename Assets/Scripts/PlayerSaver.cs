using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Save();
        }
    }

   private void Save()
    {
        Vector3 playerPosition = transform.position;
        Quaternion playerRotation = transform.rotation;

        PlayerPrefs.SetFloat("playerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);

        PlayerPrefs.SetFloat("playerRotX", playerRotation.eulerAngles.x);
        PlayerPrefs.SetFloat("playerRotY", playerRotation.eulerAngles.y);
        PlayerPrefs.SetFloat("playerRotZ", playerRotation.eulerAngles.z);

        PlayerPrefs.Save();
    }
}
