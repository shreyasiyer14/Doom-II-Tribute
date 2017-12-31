using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityManager : MonoBehaviour {
	public static EntityManager instance;

	private List<GameObject> entityList = new List<GameObject> ();

	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
			return;
		}
		instance = this;
	}

	void Start () {
		foreach (EntityComponent sceneObject in GameObject.FindObjectsOfType<EntityComponent> ()) {
			Add (sceneObject.gameObject);
		}
	}

	public void Add (GameObject entity) {
		entityList.Add (entity);
	}

	public void Remove (GameObject entity) {
		entityList.Remove (entity);
	}

	public List<GameObject> getObjectsOfType <T> () {
		List<GameObject> returnList = new List<GameObject> ();
		foreach (GameObject objectInList in entityList) {
			if (objectInList.GetComponent<T> () != null) {
				returnList.Add (objectInList);
			}
		}
		return returnList;
	}
}
