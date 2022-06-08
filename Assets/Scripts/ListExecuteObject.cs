using System.Collections;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ZarinkinProject
{

    public sealed class ListExecuteObject : IEnumerable,IEnumerator
    {

        private IExecute[] _interactableObject;
        private int _index = -1;

        public int Lenght => _interactableObject.Length;
        public object Current => _interactableObject[_index];



        public ListExecuteObject()
        {
            Bonus[] BonusObject = Object.FindObjectsOfType<Bonus>();
            for (int i = 0; i < BonusObject.Length; i++)
            {
               if(BonusObject[i] is IExecute intObj)
                {
                    AddExecuteObject(BonusObject[i]);
                }
                  
            }

        }
        public IExecute this[int curr]
        {
            get { return _interactableObject[curr]; }
            private set { _interactableObject[curr] = value; }
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()//?????????
        {
            return GetEnumerator();
        }

        public void AddExecuteObject(IExecute execute)
        {
            if(_interactableObject == null)
            {
                _interactableObject = new[] {execute};
                return;
            }
            Array.Resize(ref _interactableObject, Lenght + 1);
            _interactableObject[Lenght - 1] = execute;

        }

        public bool MoveNext()
        {
            if( _index == Lenght -1)
            {
                Reset();
                return false;
            }

             _index++;
              return true;

        }   

        public void Reset()// устанавливает указатель на начало массива
        {
            _index = -1;
        }

    }
}