using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityManager {
	private static List<GameObject> entityList = new List<GameObject> ();

	[RuntimeInitializeOnLoadMethod]
	static void Start () {
		foreach (EntityComponent sceneObject in GameObject.FindObjectsOfType<EntityComponent> ()) {
			Add (sceneObject.gameObject);
		}
	}

	public static void Add (GameObject entity) {
		entityList.Add (entity);
	}

	public static void Remove (GameObject entity) {
		entityList.Remove (entity);
	}

	public static List<GameObject> getObjectsOfType <T> () {
		List<GameObject> returnList = new List<GameObject> ();
		foreach (GameObject objectInList in entityList) {
			if (objectInList.GetComponent<T> () != null) {
				returnList.Add (objectInList);
			}
		}
		return returnList;
	}
}
