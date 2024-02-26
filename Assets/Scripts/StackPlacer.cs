using System;
using UnityEngine;

public class StackPlacer : MonoBehaviour
{
    [SerializeField] private StackManager _stackManager;
    [SerializeField] private float _tolerance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.GameEnded)
        {
            StackPlace();
        }
    }

    private void StackPlace()
    {
        if(_stackManager.LastStack == null) return;
        if (_stackManager.CurrentStack == null )
        {
            GameEvents.Instance.SpawnStack();
            return;
        }
        
        _stackManager.CurrentStack.Stop();

        var currentTransform = _stackManager.CurrentStack.transform;
        var lastTransform = _stackManager.LastStack.transform;

        float xDif = currentTransform.position.x - lastTransform.position.x;
        float newXSize = currentTransform.localScale.x;
        float newXPos = currentTransform.position.x - (xDif / 2f);

        float fallingStackXPos = currentTransform.position.x;
        float fallingStackXSize = currentTransform.localScale.x;

        if (Mathf.Abs(xDif) <= _tolerance)
        {
            newXPos = lastTransform.position.x;
            GameEvents.Instance.StackPerfect(true);

        }
        else if (Mathf.Abs(xDif) > _tolerance && Mathf.Abs(xDif) <= lastTransform.localScale.x)
        {
            float modifier = (xDif < 0) ? -1f : 1f;
            newXSize = currentTransform.localScale.x - modifier * xDif;

            fallingStackXPos = newXPos + modifier * (lastTransform.localScale.x /2f);
            fallingStackXSize = lastTransform.localScale.x - newXSize;

            SpawnCutStack(fallingStackXPos, fallingStackXSize);
        }
        else
        {
            SpawnCutStack(fallingStackXPos, fallingStackXSize);

            _stackManager.CurrentStack.gameObject.SetActive(false);
            _stackManager.SetLastStack(null);
            return;
        }

        currentTransform.localScale =
            new Vector3(newXSize, currentTransform.localScale.y, currentTransform.localScale.z);
        currentTransform.position = new Vector3(newXPos, currentTransform.position.y, currentTransform.position.z);

        _stackManager.CurrentStack.transform.localScale = currentTransform.localScale;
        _stackManager.CurrentStack.transform.position = currentTransform.position;

        _stackManager.SetLastStack(_stackManager.CurrentStack);
        
        GameEvents.Instance.SpawnStack();
    }

    private void SpawnCutStack(float xPos, float xSize)
    {
        GameObject cutStack = Instantiate(_stackManager.CurrentStack.DropStack);
        cutStack.GetComponent<MeshRenderer>().sharedMaterial = _stackManager.CurrentStack.MeshRenderer.material;

        cutStack.transform.position = new Vector3(xPos, cutStack.transform.position.y,
            _stackManager.CurrentStack.transform.position.z);
        cutStack.transform.localScale =
            new Vector3(xSize, cutStack.transform.localScale.y, cutStack.transform.localScale.z);
        
        GameEvents.Instance.StackPerfect(false);
    }
}