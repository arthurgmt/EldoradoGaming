using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Key : MonoBehaviour
{
    public DatabaseReference reference;
    public Button submit;
    public InputField key;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        submit.onClick.AddListener(OnSubmit);
    }

    private IEnumerator Submit()
    {
        string input = key.text.Trim();
        
        var task = reference.Child(input).GetValueAsync();
        yield return new WaitUntil(predicate: () => task.IsCompleted);
        if (task.Result.Exists) Debug.Log("Exist");
        else Debug.Log("Zebi");
    }

    private void OnSubmit()
    {
        StartCoroutine(Submit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
