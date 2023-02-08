using System;
using TMPro;
using UnityEngine;


public class ScrollStorageElement : MonoBehaviour
{
    public Storage Storage;

    public event Action<Storage> OnStorageSelected;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private SelectButton _selectionButton;

    private void OnEnable()
    {
        _selectionButton.OnButtomClick += StorageSelected;
    }

    private void OnDisable()
    {
        _selectionButton.OnButtomClick -= StorageSelected;
    }
    
    private void StorageSelected()
    {
        OnStorageSelected?.Invoke(Storage);
    }

    private void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        _nameText.text = Storage.Type.ToString();
        _value.text = Storage.Value.ToString();
    }
}
