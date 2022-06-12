using UnityEngine;

public class TShuffle : MonoBehaviour
{
    private GameObject cardClone;
    public GameObject card;
    private int i = 1;

    public void FillingAnim()
    {
        while (i < 82)
        {
            cardClone = Instantiate(card);
            cardClone.transform.parent = gameObject.transform;
            cardClone.name = "TKarta_" + i.ToString();
            cardClone = GameObject.Find("TKarta_"+ i.ToString());
            cardClone.transform.position = new Vector3(6f, TInf.position, 1f);
            TInf.position += 0.005f;
            i++;
        }
    }
}