using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    int camerasToSpawn = 0;
    [SerializeField]
    int generatorsToSpawn = 0;
    [SerializeField]
    int greenSrcsToSpawn = 0;
    [SerializeField]
    int lightsToSpawn = 0;
    [SerializeField]
    GameObject[] collectibleGameObjectArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spawnObjects();
    }

    UnityEngine.Vector2 randomPosition(){
        UnityEngine.Vector2 randPos = new UnityEngine.Vector2(Random.Range(-57,58)+.5f, Random.Range(-38,46)+.5f);
        return randPos;
    }

    public void spawnObjects(){
        for(int i = 0; i <= collectibleGameObjectArray.Length-1; i++){
            switch (i){
                case 0:
                    camerasToSpawn = Random.Range(0, 10);
                    for (int j = 0; j < camerasToSpawn; j++){
                        GameObject.Instantiate(collectibleGameObjectArray[i], randomPosition(), Quaternion.identity);
                    }
                    break;
                case 1:
                    generatorsToSpawn = Random.Range(0, 6);
                    for (int j = 0; j < generatorsToSpawn; j++){
                        GameObject.Instantiate(collectibleGameObjectArray[i], randomPosition(), Quaternion.identity);
                    }
                    break;
                case 2:
                    greenSrcsToSpawn = Random.Range(0, 6);
                    for (int j = 0; j < greenSrcsToSpawn; j++){
                        GameObject.Instantiate(collectibleGameObjectArray[i], randomPosition(), Quaternion.identity);
                    }
                    break;
                case 3:
                    lightsToSpawn = Random.Range(0, 6);
                    for (int j = 0; j < lightsToSpawn; j++){
                        GameObject.Instantiate(collectibleGameObjectArray[i], randomPosition(), Quaternion.identity);
                    }
                    break;
            }
             
        }
    }
}
