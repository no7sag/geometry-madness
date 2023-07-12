using UnityEngine;

public class ChangeInfoPanel : MonoBehaviour
{
    [SerializeField] GameObject _activeInfoPanel, _newInfoPanel;
    bool _triggered;

    void OnTriggerEnter(Collider other)
    {
        if (_triggered)
            return;

        _triggered = true;

        if (_activeInfoPanel != null)
            _activeInfoPanel.SetActive(false);

        _newInfoPanel.SetActive(true);
    }
}
