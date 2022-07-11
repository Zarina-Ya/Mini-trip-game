using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;
namespace ZarinkinProject
{


    [CustomEditor(typeof(WayPoints))]
    public class SaveWayPoint : Editor
    {
        private static XmlSerializer _serializer;
        public List<SVector3> _savindNodes = new List<SVector3>();

       public override void OnInspectorGUI()
       {
            base.OnInspectorGUI();
            WayPoints Base = (WayPoints)target;
            if (_serializer == null)
            {
                _serializer = new XmlSerializer(typeof(SVector3[]));
               
            }
            if (GUILayout.Button("SAVE"))
            {
                if (Base._nodes.Count > 0)
                {
                    foreach (Transform transform in Base._nodes)
                    {
                        if (!_savindNodes.Contains(transform.position))
                        {
                            _savindNodes.Add(transform.position);
                        }
                    }
                }

                using (FileStream fs = new FileStream(Base.SavingPath, FileMode.Create))
                {
                    _serializer.Serialize(fs, _savindNodes.ToArray());
                }
            }
        }
    }

}