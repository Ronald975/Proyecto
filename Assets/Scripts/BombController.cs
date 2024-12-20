using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.Q;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    public int bombsRemaining;

    private void OnEnable(){
        bombsRemaining = bombAmount;
    }

    private void Update(){
        if(bombsRemaining > 0 && Input.GetKeyDown(inputKey)){
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb(){

        Vector3 position = transform.position + new Vector3(0,1,0);
        position.x = Mathf.Round(position.x);
        position.z = Mathf.Round(position.z);
        
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombFuseTime);
        
        Destroy(bomb);

        bombsRemaining++;
    }

}