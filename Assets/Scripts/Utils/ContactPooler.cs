using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPooler : MonoBehaviour
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];

        private int _contactCount;
        private Collider2D _collider2D;
        private float _treshold;

        public bool IsGrounded { get; private set; }
        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider2D = collider;
        }

        public void Update()
        {
            IsGrounded = false;
            LeftContact = false;
            RightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);

            for(int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _treshold) IsGrounded = true;

                if (_contacts[i].normal.x > _treshold) LeftContact = true;

                if (_contacts[i].normal.x > _treshold) RightContact = true;
            }
        }
    }
}
