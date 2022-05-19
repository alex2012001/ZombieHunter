using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieHunter.ClimbingSystem
{
    public class Hand : MonoBehaviour
    {
        public Climber Climber = null;
        public OVRInput.Controller Controller = OVRInput.Controller.None;

        public Vector3 Delta { private set; get; } = Vector3.zero;

        private Vector3 _lastPosition = Vector3.zero;

        private GameObject _currentPoint = null;
        private List<GameObject> _contactPoints = new List<GameObject>();

        private MeshRenderer _meshRenderer = null;

        private void Awake()
        {
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        private void Start()
        {
            _lastPosition = transform.position;
        }

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, Controller))
            {
                GridPoint();
            }
            
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, Controller))
            {
               RealisePoint();
            }
        }

        private void FixedUpdate()
        {
            _lastPosition = transform.position;
        }

        private void LateUpdate()
        {
            Delta = (_lastPosition - transform.position)*Time.deltaTime;
        }

        private void GridPoint()
        {
            _currentPoint = Utility.GetNearest(transform.position, _contactPoints);

            if (_currentPoint)
            {
                Climber.SetHand(this);
                _meshRenderer.enabled = false;
            }
        }

        public void RealisePoint()
        {
            if (_currentPoint)
            {
                Climber.ClearHand();
                _meshRenderer.enabled = true;
            }

            _currentPoint = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            AddPoint(other.gameObject);
        }

        private void AddPoint(GameObject newObject)
        {
            if (newObject.CompareTag("ClimbPoint"))
            {
                _contactPoints.Add(newObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            RemovePoint(other.gameObject);
        }

        private void RemovePoint(GameObject newObject)
        {
            if (newObject.CompareTag("ClimbPoint"))
            {
                _contactPoints.Remove(newObject);
            }
        }
    }
}