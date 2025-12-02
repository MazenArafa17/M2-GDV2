using UnityEngine;

public class array : MonoBehaviour
{
    string[] names = new string[]
{
    "bal1",
    "bal2",
    "bal3",
    "bal4",
    "bal5",
    "bal6",
    "bal7",
    "bal8",
    "bal9",
    "bal10"
};

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))PrintRandomItem();
        if(Input.GetKeyDown(KeyCode.Escape))PrintAllItems();
    }
    private void PrintRandomItem() {
        Debug.Log(names[Random.Range(0, names.Length)]);

    }
    private void PrintAllItems() {
        Debug.Log(string.Join(", ", names));
    }

}