using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagement : MonoBehaviour
{
    [SerializeField] float minimum_delay = 3f;
    [SerializeField] float maximum_delay = 6f;
    [SerializeField] Zombie[] zombiePrefab;

    bool spawn = true;

    IEnumerator Start(){
        while(spawn){
            yield return new WaitForSeconds(Random.Range(minimum_delay, maximum_delay));
            SpawnAttacker();
        }
    }
	
    public void StopSpawning(){
        spawn = false;
    }

    private void SpawnAttacker(){
        var attackerIndex = Random.Range(0, zombiePrefab.Length);
        Spawn(zombiePrefab[attackerIndex]);
    }

    private void Spawn (Zombie myAttacker){
        Zombie newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as Zombie;
        newAttacker.transform.parent = transform;
    }
}
