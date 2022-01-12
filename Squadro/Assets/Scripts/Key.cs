using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

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
        DataSnapshot ds = task.Result;
        if (ds.Exists && ds.GetValue(true).ToString().Contains("-")) {
            DataSaver.saveData<KeyData>(new KeyData { key = input }, "keyData");
            reference.Child(input).SetValueAsync("+");
            SceneManager.LoadScene("OfficialScene");
        }
        else
        {
            key.image.color = new Color(0.92f,0.16f,0.12f);
        }
    }

    public void onChangeValueInputField()
    {
        key.image.color = new Color(0.78f,0.78f,0.78f);
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
