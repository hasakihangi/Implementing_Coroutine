using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A
{
	public class TestEnumerable: MonoBehaviour
	{
		private MyEnumerable myEnumerable;
		private IEnumerator<int> myEnumerator;

		private void Awake()
		{
			myEnumerable = new MyEnumerable(1, 2, 3);
		}

		private void Start()
		{
			foreach (var value in myEnumerable)
			{
				print(value);
			}
			
			// 生成一个enumerator给update使用
			myEnumerator = myEnumerable.GetEnumerator();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (!myEnumerator.MoveNext())
				{
					myEnumerator.Reset();
				}

				print(myEnumerator.Current);
			}
		}
	}

	public class MyEnumerable : IEnumerable<int>
	{
		private LinkedList<int> myLinkedList = new();

		public MyEnumerable(params int[] values)
		{
			if (values != null)
				for (int i = 0; i < values.Length; i++)
				{
					myLinkedList.AddLast(values[i]);
				}			
		}

		public IEnumerator<int> GetEnumerator()
		{
			return new MyEnumerator(myLinkedList);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public class MyEnumerator : IEnumerator<int>
	{
		private LinkedList<int> myLinkedList;
		private LinkedListNode<int> node;

		public MyEnumerator(LinkedList<int> linkedList)
		{
			myLinkedList = linkedList;
		}
		
		public bool MoveNext()
		{
			if (node == null)
				node = myLinkedList.First;
			else
				node = node.Next;

			return node != null;
		}

		public void Reset()
		{
			node = myLinkedList.First;
		}

		public int Current
		{
			get
			{
				return node.Value;
			}
		}

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			
		}
	}
}