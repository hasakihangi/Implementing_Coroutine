using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A
{
	public class TestYieldReturn : MonoBehaviour
	{
		private IEnumerator<int> myEnumerator;
		void Start()
		{
			myEnumerator = MyCoroutineFunction2();
		}
    
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				myEnumerator.MoveNext();
				int value = myEnumerator.Current;
				print(value);
			}
		}
    
		IEnumerator<int> MyCoroutineFunction1()
		{
			Debug.Log("number: ");
			yield return 1;
			Debug.Log("number: ");
			yield return 2;
			Debug.Log("number: ");
			yield return 3;
		}

		IEnumerator<int> MyCoroutineFunction2()
		{
			return new MyCoroutineActualCode();
		}
	}

	public class MyCoroutineActualCode : IEnumerator<int>
	{
		private int index = 0;
		private int maxIndex = 3;
		
		public bool MoveNext()
		{
			index++;
			if (index > maxIndex)
				return false;
			else
				return true;
		}

		public void Reset()
		{
			index = 1;
		}

		public int Current
		{
			get
			{
				switch (index)
				{
					case 1:
						Debug.Log("number: ");
						return 1;
					case 2:
						Debug.Log("number: ");
						return 2;
					case 3:
						Debug.Log("number: ");
						return 3;
					default:
						return 3;
				}
			}
		}

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}



