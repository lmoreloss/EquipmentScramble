using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int generators = 0;
    public int greenscrs = 0;
    public int cameras = 0;
    public int lights = 0;
    [SerializeField]
    AudioSource audioSource;

    public void IncreaseCollectible(string tagToIncrement){
        var field = this.GetType().GetField(tagToIncrement);
        if (field != null && field.FieldType == typeof(int))
        {
            audioSource.pitch = Random.Range(0.9f, 1.11f);
            audioSource.Play();
            int currentValue = (int)field.GetValue(this);
            field.SetValue(this, currentValue + 1);
        }
    }

    public void SetToZero(){
        generators = 0;
        greenscrs = 0;
        cameras = 0;
        lights = 0;
    }

    public void ResetPosition(){
        transform.position = new Vector3(5f,9.49f, 0f);
    }
}
