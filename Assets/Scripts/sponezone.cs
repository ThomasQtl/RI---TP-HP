using UnityEngine;

public class sponezone : MonoBehaviour
{

    [SerializeField]
    private GameObject cubePrefabe;

    [SerializeField]
    private Vector3 zoneSize;

    float nb = 0;
    float nboiseau = 0;

    void Start()
    {
        nboiseau = zoneSize.x / 6;

        while (nb < nboiseau)
                {
                    GameObject instantiated = Instantiate(cubePrefabe);
            instantiated.transform.localScale = new Vector3Int(5, 5, 5);
                    instantiated.transform.position = new Vector3(
                        Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2), //Placement au hazard sur l'axe des x
                        transform.position.y,
                        Random.Range(transform.position.z - zoneSize.z / 2, transform.position.z + zoneSize.z / 2) //Placement au hazard sur l'axe des z
                        );
                    nb++;
                }
    }



    // Update is called once per frame
    void Update()
    {
       //on ne fait rien 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}
